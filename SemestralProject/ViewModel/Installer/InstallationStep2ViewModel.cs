using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Common.StringProviders;
using SemestralProject.Data;
using SemestralProject.Model;
using SemestralProject.View.Installer;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace SemestralProject.ViewModel.Installer
{

    /// <summary>
    /// Class which handles second step of installation process.
    /// </summary>
    [ObservableObject]
    public partial class InstallationStep2ViewModel : NavigationDynamicContent<InstallationModel>, IDynamicTarget<InstallationModel>
    {
        /// <summary>
        /// Data model of installation.
        /// </summary>
        private InstallationModel model;

        /// <summary>
        /// Flag, whether second step of installation finished in some way.
        /// </summary>
        [ObservableProperty]
        private bool finished;

        /// <summary>
        /// Flag, whether second step of installation finished successfully.
        /// </summary>
        [ObservableProperty]
        private bool successfull;

        /// <summary>
        /// Actual stage of second step of installation process.
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Stage1FontWeight))]
        private ushort stage = 1;

        /// <summary>
        /// Font weight of text in first stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage1FontWeight = FontWeights.Bold;

        /// <summary>
        /// Font weight of text in second stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage2FontWeight = FontWeights.Normal;

        /// <summary>
        /// Font weight of text in third stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage3FontWeight = FontWeights.Normal;

        /// <summary>
        /// Font weight of text in fourth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage4FontWeight = FontWeights.Normal;

        /// <summary>
        /// Font weight of text in fifth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage5FontWeight = FontWeights.Normal;

        /// <summary>
        /// Font weight of text in sixth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage6FontWeight = FontWeights.Normal;

        /// <summary>
        /// Font weight of text in seventh stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage7FontWeight = FontWeights.Normal;

        /// <summary>
        /// Font weight of text in eighth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage8FontWeight = FontWeights.Normal;

        /// <summary>
        /// Visibility of progress ring in first stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage1ProgressVisibility = Visibility.Visible;

        /// <summary>
        /// Visibility of progress ring in second stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage2ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring in third stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage3ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring in fourth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage4ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring in fifth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage5ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring in sixth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage6ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring in seventh stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage7ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring in eighth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage8ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Counter of second stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint counterStage2 = 0;

        /// <summary>
        /// Counter of third stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint counterStage3 = 0;

        /// <summary>
        /// Counter of fourth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint counterStage4 = 0;

        /// <summary>
        /// Counter of fifth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint counterStage5 = 0;

        /// <summary>
        /// Counter of sixth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint counterStage6 = 0;

        /// <summary>
        /// Counter of seventh stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint counterStage7 = 0;

        /// <summary>
        /// Counter of eighth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint counterStage8 = 0;

        /// <summary>
        /// Total of second stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint totalStage2 = 0;

        /// <summary>
        /// Total of third stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint totalStage3 = 0;

        /// <summary>
        /// Total of fourth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint totalStage4 = 0;

        /// <summary>
        /// Total of fifth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint totalStage5 = 0;

        /// <summary>
        /// Total of sixth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint totalStage6 = 0;

        /// <summary>
        /// Total of seventh stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint totalStage7 = 0;

        /// <summary>
        /// Total of eighth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private uint totalStage8 = 0;

        /// <summary>
        /// Visibility of fail icon of first stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage1 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of second stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage2 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of third stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage3 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of fourth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage4 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of fifth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage5 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of sixth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage6 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of seventh stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage7 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of eight stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage8 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of first stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage1 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of second stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage2 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of third stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage3 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of fourth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage4 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of fifth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage5 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of sixth stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage6 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of seventh stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage7 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of eight stage of second step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage8 = Visibility.Collapsed;

        /// <summary>
        /// Creates new second step of installation.
        /// </summary>
        public InstallationStep2ViewModel()
        {
            if (InstallationProcessViewModel.Instance != null)
            {
                InstallationProcessViewModel.Instance.RegisterDynamicSource(this);
                InstallationProcessViewModel.Instance.RegisterTarget(this);
            }
            this.TotalStage2 = (uint)(
                from obj in InstallerScript.Drops
                from inner in obj.Value
                select inner
                ).Count();
            this.TotalStage3 = (uint)InstallerScript.Sequences.Count();
            this.totalStage4 = (uint)InstallerScript.Tables.Count();
            this.TotalStage5 = (uint)InstallerScript.Relations.Count();
            this.TotalStage6 = (uint)InstallerScript.Packages.Count();
            this.TotalStage7 = (uint)InstallerScript.Triggers.Count();
            this.TotalStage8 = (uint)InstallerScript.Data.Count();
            this.Finished = false;
            this.Successfull = false;
            this.Stage = 1;
        }

        /// <summary>
        /// Handles start of installation after control is loaded.
        /// </summary>
        [RelayCommand]
        private void ControlLoaded()
        {
            this.DispatchStage();
        }

        /// <summary>
        /// Handles click on back button.
        /// </summary>
        [RelayCommand]
        private void BackClicked()
        {
            this.NavigateBack();
        }

        /// <summary>
        /// Handles command which should send user to the next step of installation.
        /// </summary>
        [RelayCommand]
        private void Next()
        {
            this.ChangeContent(new InstallationStep3(), this.model);
        }

        /// <summary>
        /// Handles command which should send user to the next step of installation.
        /// </summary>
        [RelayCommand]
        private void Previous()
        {
            this.ChangeContent(new InstallationStep1());
        }

        /// <summary>
        /// Fails actual stage.
        /// </summary>
        private void Fail()
        {
            this.HideProgressRings();
            switch (this.Stage)
            {
                case 1: this.FailStage1 = Visibility.Visible; break;
                case 2: this.FailStage2 = Visibility.Visible; break;
                case 3: this.FailStage3 = Visibility.Visible; break;
                case 4: this.FailStage4 = Visibility.Visible; break;
                case 5: this.FailStage5 = Visibility.Visible; break;
                case 6: this.FailStage6 = Visibility.Visible; break;
                case 7: this.FailStage7 = Visibility.Visible; break;
                case 8: this.FailStage8 = Visibility.Visible; break;
            }
            this.Finished = true;
            this.Stage = 9;
            this.UpdateFontWeights();
        }

        /// <summary>
        /// Marks actual stage as successfull.
        /// </summary>
        private void Success()
        {
            this.HideProgressRings();
            switch (this.Stage)
            {
                case 1: this.SuccessStage1 = Visibility.Visible; break;
                case 2: this.SuccessStage2 = Visibility.Visible; break;
                case 3: this.SuccessStage3 = Visibility.Visible; break;
                case 4: this.SuccessStage4 = Visibility.Visible; break;
                case 5: this.SuccessStage5 = Visibility.Visible; break;
                case 6: this.SuccessStage6 = Visibility.Visible; break;
                case 7: this.SuccessStage7 = Visibility.Visible; break;
                case 8: this.SuccessStage8 = Visibility.Visible; break;
            }
            if (
                this.SuccessStage1 == Visibility.Visible &&
                this.SuccessStage2 == Visibility.Visible &&
                this.SuccessStage3 == Visibility.Visible &&
                this.SuccessStage4 == Visibility.Visible &&
                this.SuccessStage5 == Visibility.Visible &&
                this.SuccessStage6 == Visibility.Visible &&
                this.SuccessStage7 == Visibility.Visible &&
                this.SuccessStage8 == Visibility.Visible
            )
            {
                this.Successfull = true;
                this.Finished = true;
            }
        }

        /// <summary>
        /// Hides all progress rings.
        /// </summary>
        private void HideProgressRings()
        {
            this.Stage1ProgressVisibility = Visibility.Collapsed;
            this.Stage2ProgressVisibility = Visibility.Collapsed;
            this.Stage3ProgressVisibility = Visibility.Collapsed;
            this.Stage4ProgressVisibility = Visibility.Collapsed;
            this.Stage5ProgressVisibility = Visibility.Collapsed;
            this.Stage6ProgressVisibility = Visibility.Collapsed;
            this.Stage7ProgressVisibility = Visibility.Collapsed;
            this.Stage8ProgressVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Runs correct method according to the actual stage.
        /// </summary>
        private void DispatchStage()
        {
            this.HideProgressRings();
            this.UpdateFontWeights();
            if (this.IsFinished() == false)
            {
                this.UpdateProgressVisibility();
                Action? action = null;
                switch (this.Stage)
                {
                    case 1: action = this.Stage1; break;
                    case 2: action = this.Stage2; break;
                    case 3: action = this.Stage3; break;
                    case 4: action = this.Stage4; break;
                    case 5: action = this.Stage5; break;
                    case 6: action = this.Stage6; break;
                    case 7: action = this.Stage7; break;
                    case 8: action = this.Stage8; break;
                }
                if (action != null)
                {
                    action();
                }
            }
        }

        /// <summary>
        /// Runs first stage of second step of installation.
        /// </summary>
        private void Stage1()
        {
            Task.Run(async () =>
            {
                Connection connectionModel = new Connection(
                    this.model.Connection.Server,
                    this.model.Connection.Port,
                    this.model.Connection.Database,
                    this.model.Connection.Username,
                    this.model.Connection.Password
                );
                
                await connectionModel.SaveAsync();
                IConnection connection = await OracleConnector.ReloadAsync();
                bool result = await connection.ConnectAsync();
                if (result == true)
                {
                    this.model = new InstallationModel(connection, this.model.Connection);
                    this.Success();
                    this.Stage = 2;
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Runs second stage of second step of installation.
        /// </summary>
        private void Stage2()
        {
            Task.Run(async () =>
            {
                if (this.model.Database != null)
                {
                    bool result = true;
                    foreach (IConnection.DatabaseObject obj in InstallerScript.Drops.Keys)
                    {
                        if (result == true)
                        {
                            foreach (string objName in InstallerScript.Drops[obj].Keys)
                            {
                                bool exists = await this.model.Database.ObjectExistsAsync(obj, objName);
                                if (exists == true)
                                {
                                    foreach(string sql in InstallerScript.Drops[obj][objName])
                                    {
                                        result = await this.model.Database.ExecuteAsync(sql);
                                        if (result == false)
                                        {
                                            break;
                                        }
                                    }
                                    if (result == false)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        this.IncrementCounter();
                                    }
                                }
                                else
                                {
                                    this.IncrementCounter();
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    if (result == true)
                    {
                        this.Success();
                        this.Stage = 3;
                    }
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Runs third stage of second step of installation.
        /// </summary>
        private void Stage3()
        {
            Task.Run(async () =>
            {
                bool result = await this.RunScriptsAsync(InstallerScript.Sequences);
                if (result == true)
                {
                    this.Success();
                    this.Stage = 4;
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Runs fourth stage of second step of installation.
        /// </summary>
        private void Stage4()
        {
            Task.Run(async () =>
            {
                bool result = await this.RunScriptsAsync(InstallerScript.Tables);
                if (result == true)
                {
                    this.Success();
                    this.Stage = 5;
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Runs fifth stage of second step of installation.
        /// </summary>
        private void Stage5()
        {
            Task.Run(async () =>
            {
                bool result = await this.RunScriptsAsync(InstallerScript.Relations);
                if (result == true)
                {
                    this.Success();
                    this.Stage = 6;
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Runs sixth stage of second step of installation.
        /// </summary>
        private void Stage6()
        {
            Task.Run(async () =>
            {
                bool result = await this.RunScriptsAsync(InstallerScript.Packages);
                if (result == true)
                {
                    this.Success();
                    this.Stage = 7;
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Runs seventh stage of second step of installation.
        /// </summary>
        private void Stage7()
        {
            Task.Run(async () =>
            {
                bool result = await this.RunScriptsAsync(InstallerScript.Triggers);
                if (result == true)
                {
                    this.Success();
                    this.Stage = 8;
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Runs eighth stage of second step of installation.
        /// </summary>
        private void Stage8()
        {
            Task.Run(async () =>
            {
                bool result = await this.RunScriptsAsync(InstallerScript.Data);
                if (result == true)
                {
                    this.Success();
                    this.Stage = 9;
                }
                else
                {
                    this.Fail();
                }
                this.DispatchStage();
            });
        }

        /// <summary>
        /// Increments counter of actual stage.
        /// </summary>
        private void IncrementCounter()
        {
            switch (this.Stage)
            {
                case 2: this.CounterStage2++; break;
                case 3: this.CounterStage3++; break;
                case 4: this.CounterStage4++; break;
                case 5: this.CounterStage5++; break;
                case 6: this.CounterStage6++; break;
                case 7: this.CounterStage7++; break;
                case 8: this.CounterStage8++; break;
            }
        }

        /// <summary>
        /// Runs SQL scripts.
        /// </summary>
        /// <param name="scripts">SQL scripts which will be run.</param>
        /// <param name="increment">Flag, whether actual counter of stage should be incremented (TRUE) or not (FALSE).</param>
        /// <returns>
        /// TRUE, if all scripts has been successfully run,
        /// FALSE otherwise.
        /// </returns>
        private bool RunScripts(IStringProvider scripts, bool increment = true)
        {
            bool reti = true;
            if (this.model.Database == null)
            {
                reti = false;
            }
            else
            {
                foreach (string script in scripts)
                {
                    if (this.model.Database.Execute(script) == false)
                    {
                        reti = false;
                        break;
                    }
                    else
                    {
                        this.IncrementCounter();
                    }
                }
            }
            return reti;
        }

        /// <summary>
        /// Runs SQL scripts asynchronously
        /// </summary>
        /// <param name="scripts">SQL scripts which will be run.</param>
        /// <param name="increment">Flag, whether actual counter of stage should be incremented (TRUE) or not (FALSE).</param>
        /// <returns>
        /// Task which resolves into:
        /// TRUE, if all scripts has been successfully run,
        /// FALSE otherwise.
        /// </returns>
        private Task<bool> RunScriptsAsync(IStringProvider scripts, bool increment = true)
        {
            return Task<bool>.Run(() =>
            {
                return this.RunScripts(scripts, increment);
            });
        }

        /// <summary>
        /// Checks, whether second step of installation process finished in some way.
        /// </summary>
        /// <returns>
        /// TRUE, if second step of installation finished in some way,
        /// FALSE otherwise.
        /// </returns>
        private bool IsFinished() => this.Finished;

        /// <summary>
        /// Checks, whether second step of installation process finished successfully.
        /// </summary>
        /// <returns>
        /// TRUE if second step of installation finished successfully,
        /// FALSE otherwise.
        /// </returns>
        private bool IsSuccessfull() => this.Successfull;

        /// <summary>
        /// Updates font weights of text of all stages.
        /// </summary>
        private void UpdateFontWeights()
        {
            Func<short, FontWeight> fw = s => s == this.Stage ? FontWeights.Bold : FontWeights.Normal;
            this.Stage1FontWeight = fw.Invoke(1);
            this.Stage2FontWeight = fw.Invoke(2);
            this.Stage3FontWeight = fw.Invoke(3);
            this.Stage4FontWeight = fw.Invoke(4);
            this.Stage5FontWeight = fw.Invoke(5);
            this.Stage6FontWeight = fw.Invoke(6);
            this.Stage7FontWeight = fw.Invoke(7);
            this.Stage8FontWeight = fw.Invoke(8);
        }

        /// <summary>
        /// Updates visibility of progress rings of all stages.
        /// </summary>
        private void UpdateProgressVisibility()
        {
            Func<short, Visibility> vis = s => s == this.Stage ? Visibility.Visible : Visibility.Collapsed;
            this.Stage1ProgressVisibility = vis.Invoke(1);
            this.Stage2ProgressVisibility = vis.Invoke(2);
            this.Stage3ProgressVisibility = vis.Invoke(3);
            this.Stage4ProgressVisibility = vis.Invoke(4);
            this.Stage5ProgressVisibility = vis.Invoke(5);
            this.Stage6ProgressVisibility = vis.Invoke(6);
            this.Stage7ProgressVisibility = vis.Invoke(7);
            this.Stage8ProgressVisibility = vis.Invoke(8);
        }

        public void SetData(InstallationModel data)
        {
            this.model = data;
        }
    }
}
