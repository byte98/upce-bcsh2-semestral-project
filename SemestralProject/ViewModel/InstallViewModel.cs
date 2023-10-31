using SemestralProject.Common;
using SemestralProject.Data;
using SemestralProject.Model;
using SemestralProject.View.Events;
using SemestralProject.View.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SemestralProject.ViewModel
{
    /// <summary>
    /// Class which handles whole installation process.
    /// </summary>
    public class InstallViewModel
    {
        /// <summary>
        /// Actual stage of the installation.
        /// </summary>
        private short stage = 0;

        /// <summary>
        /// First stage of the installation.
        /// </summary>
        private readonly Install1 install1;

        /// <summary>
        /// Second stage of the installation.
        /// </summary>
        private readonly Install2 install2;

        /// <summary>
        /// Connection to the database.
        /// </summary>
        private IConnection? connection;

        /// <summary>
        /// Data model of connection.
        /// </summary>
        private ConnectionModel? connectionModel;

        /// <summary>
        /// Event which will be triggered when property 'enabled' of 'next' button should be changed.
        /// </summary>
        public event ButtonEnabledEventHandler? ButtonNextEnabledChanged;

        /// <summary>
        /// Event which will be triggered when property 'enabled' of 'previous' button should be changed.
        /// </summary>
        public event ButtonEnabledEventHandler? ButtonPreviousEnabledChanged;

        /// <summary>
        /// Creates new handler of the whole installation process.
        /// </summary>
        public InstallViewModel()
        {
            this.install1 = new Install1(this);
            int drops = (
                from obj in InstallerScript.Drops
                from inner in obj.Value
                select inner
            ).Count();
            this.install2 = new Install2(
                this,
                drops,
                InstallerScript.Sequences.Length,
                InstallerScript.Tables.Length,
                InstallerScript.Relations.Length,
                0
            );
            this.install1.DatabaseFilled += (sender, args) =>
            {
                this.ButtonNextEnabledChanged?.Invoke(sender, new ButtonEnabledEventArgs(args.IsFilled));
            };
            this.stage = 0;
        }

        /// <summary>
        /// Creates whole database structure.
        /// </summary>
        private void CreateDatabase()
        {
            this.install1.Dispatcher.Invoke(() =>
            {
                this.install2.Initialize();
                this.install2.SwitchStep(View.Enums.Install2Step.Connection);
                this.connectionModel = this.install1.GetConnectionModel();
                this.Connection();
            });
            
        }

        /// <summary>
        /// Handles connection to the database
        /// </summary>
        private void Connection()
        {
            Task.Run(async () =>
            {
                if (this.connectionModel != null)
                {
                    await this.connectionModel.Save();
                    this.connection = await OracleConnector.Load();
                    bool result = await this.connection.ConnectAsync();
                    if (result == true)
                    {
                        this.install2.Dispatcher.Invoke(() =>
                        {
                            this.install2.Success();
                            this.install2.SwitchStep(View.Enums.Install2Step.Deletion);
                        });
                        this.RunDrops();
                    }
                    else
                    {
                        this.install2.Dispatcher.Invoke(() =>
                        {
                            this.install2.Fail();
                        });
                        this.install1.Dispatcher.Invoke(() =>
                        {
                            this.install1.ClearForm();
                        });
                        this.ButtonPreviousEnabledChanged?.Invoke(this, new ButtonEnabledEventArgs(true));
                    }
                }
            });
        }

        /// <summary>
        /// Runs SQL Drop statements.
        /// </summary>
        private async void RunDrops()
        {
            bool failed = false;
            if (this.connection != null)
            {
                foreach(IConnection.DatabaseObject dbObj in InstallerScript.Drops.Keys)
                {
                    foreach(string objName in InstallerScript.Drops[dbObj].Keys)
                    {
                        bool exists = await this.connection.ObjectExistsAsync(dbObj, objName);
                        if (exists)
                        {
                           bool result = await this.connection.ExecuteAsync(InstallerScript.Drops[dbObj][objName]);
                           if (result == false)
                           {
                                failed = true;
                                this.install2.Dispatcher.Invoke(() =>
                                {
                                    this.install2.Fail();
                                });
                                this.ButtonPreviousEnabledChanged?.Invoke(this, new ButtonEnabledEventArgs(true));
                            }
                        }
                        this.install2.Dispatcher.Invoke(() =>
                        {
                            this.install2.IncrementCounter();
                        });
                    }
                }
            }
            else
            {
                failed = true;
                this.install2.Dispatcher.Invoke(() =>
                {
                    this.install2.Fail();
                });
                this.ButtonPreviousEnabledChanged?.Invoke(this, new ButtonEnabledEventArgs(true));
            }
            if (failed == false)
            {
                this.install2.Dispatcher.Invoke(() =>
                {
                    this.install2.Success();
                    this.install2.SwitchStep(View.Enums.Install2Step.Sequences);
                });
                this.InstallSequences();
            }
        }

        /// <summary>
        /// Performs installation of objects to the database.
        /// </summary>
        /// <param name="sql">Array with SQL statements.</param>
        /// <param name="next">Next step visible to the user.</param>
        /// <param name="nextAction">Next performed action.</param>
        private async void Install(string[] sql, View.Enums.Install2Step next, Action nextAction)
        {
            bool failed = false;
            if (this.connection == null)
            {
                failed = true;
            }
            else
            {
                foreach (string s in sql)
                {
                    bool result = await this.connection.ExecuteAsync(s);
                    if (result == false)
                    {
                        failed = true;
                        break;
                    }
                    else
                    {
                        this.install2.Dispatcher.Invoke(() =>
                        {
                            this.install2.IncrementCounter();
                        });
                    }
                }
            }
            if (failed)
            {
                this.install2.Dispatcher.Invoke(() =>
                {
                    this.install2.Fail();
                });
                this.install1.Dispatcher.Invoke(() =>
                {
                    this.install1.ClearForm();
                });
                this.ButtonPreviousEnabledChanged?.Invoke(this, new ButtonEnabledEventArgs(true));
            }
            else
            {
                this.install2.Dispatcher.Invoke(() =>
                {
                    this.install2.Success();
                    this.install2.SwitchStep(next);
                });
                nextAction();
            }
        }

        /// <summary>
        /// Installs all necessary sequences.
        /// </summary>
        private void InstallSequences()
        {
            this.Install(
                InstallerScript.Sequences,
                View.Enums.Install2Step.Tables,
                this.InstallTables
            );
        }

        /// <summary>
        /// Install all necessary tables to the database.
        /// </summary>
        private void InstallTables()
        {
            this.Install(
                InstallerScript.Tables,
                View.Enums.Install2Step.Relations,
                this.InstallRelations
            );
        }

        /// <summary>
        /// Creates all relations between tables.
        /// </summary>
        private void InstallRelations()
        {
            this.Install(
                InstallerScript.Relations,
                View.Enums.Install2Step.Data,
                this.InstallData
            );
        }

        /// <summary>
        /// Installs all default data to the database.
        /// </summary>
        private void InstallData()
        {

        }

        /// <summary>
        /// Goes to the next stage of the installation.
        /// </summary>
        /// <returns>User control representing next stage of the installation.</returns>
        public UserControl GoNext()
        {
            UserControl reti = this.install1;
            this.ButtonNextEnabledChanged?.Invoke(this, new ButtonEnabledEventArgs(false));
            this.ButtonPreviousEnabledChanged?.Invoke(this, new ButtonEnabledEventArgs(false));
            switch (this.stage)
            {
                case 0:
                    {
                        this.stage = 1;
                        reti = this.install1;
                        break;
                    }
                case 1:
                    {
                        this.stage = 2;
                        this.install2.SwitchStep(View.Enums.Install2Step.Connection);
                        reti = this.install2;
                        Task.Run(() =>
                        {
                            this.CreateDatabase();
                        });
                        break;
                    }
                default:
                    {
                        this.stage = 5;
                        break;
                    }
            }
            return reti;
        }

        /// <summary>
        /// Goes to the previous stage of the installation.
        /// </summary>
        /// <returns>User control representing previous stage of the application.</returns>
        public UserControl GoPrevious()
        {
            UserControl reti = this.install1;
            switch(this.stage)
            {
                case 2:
                    {
                        this.stage = 1;
                        reti = this.install1;
                        break;
                    }
            }
            return reti;
        }
    }
}
