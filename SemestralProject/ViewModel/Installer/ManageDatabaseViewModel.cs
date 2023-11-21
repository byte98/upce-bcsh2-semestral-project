using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SemestralProject.ViewModel.Installer
{
    /// <summary>
    /// Class which manages 'manage database' page.
    /// </summary>
    [ObservableObject]
    public partial class ManageDatabaseViewModel : NavigationSource
    {
        /// <summary>
        /// Server on which database runs.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(TestCommand))]
        private string server = string.Empty;

        /// <summary>
        /// Port on which database runs.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(TestCommand))]
        private string port = string.Empty;

        /// <summary>
        /// Name of database.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(TestCommand))]
        private string database = string.Empty;

        /// <summary>
        /// Username of user with access to database.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(TestCommand))]
        private string username = string.Empty;

        /// <summary>
        /// Password of user. 
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(TestCommand))]
        private string password = string.Empty;

        /// <summary>
        /// Visibility of unknown connection state.
        /// </summary>
        [ObservableProperty]
        private Visibility unknownVisibility;

        /// <summary>
        /// Visibility of successfull connection.
        /// </summary>
        [ObservableProperty]
        private Visibility successVisibility;

        /// <summary>
        /// Visibility of failed connection.
        /// </summary>
        [ObservableProperty]
        private Visibility failVisibility;

        /// <summary>
        /// Visibility of progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility progressVisibility;

        /// <summary>
        /// Visibility of text in 'save' button.
        /// </summary>
        [ObservableProperty]
        private Visibility saveTextVisibility;

        /// <summary>
        /// Visibility of progress in 'save' button.
        /// </summary>
        [ObservableProperty]
        private Visibility saveProgressVisibility;

        /// <summary>
        /// Flag, whether testing procedure is running.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(TestCommand))]
        [NotifyCanExecuteChangedFor(nameof(BackClickedCommand))]
        private bool isRunning;

        /// <summary>
        /// Creates new view model for 'manage database' page.
        /// </summary>
        public ManageDatabaseViewModel()
        {
            Connection conn = OracleConnector.Load().ConnectionModel;
            this.Server = conn.Server;
            this.Port = conn.Port;
            this.Username = conn.Username;
            this.Database = conn.Database;
            this.UnknownVisibility = Visibility.Visible;
            this.FailVisibility = Visibility.Collapsed;
            this.SuccessVisibility = Visibility.Collapsed;
            this.ProgressVisibility = Visibility.Collapsed;
            this.SaveProgressVisibility = Visibility.Collapsed;
            this.SaveTextVisibility = Visibility.Visible;
            this.IsRunning = false;
        }

        /// <summary>
        /// Handles change of password.
        /// </summary>
        /// <param name="source">Source of event.</param>
        [RelayCommand]
        private void PasswordChanged(PasswordBox source)
        {
            this.Password = source.Password;
        }

        /// <summary>
        /// Handles click on 'save' button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(CanSave))]
        private async Task Save()
        {
            this.IsRunning = true;
            this.SaveProgressVisibility = Visibility.Visible;
            this.SaveTextVisibility = Visibility.Collapsed;
            Connection conn = new Connection(
                this.Server,
                this.Port,
                this.Database,
                this.Username,
                this.Password
                );
            this.IsRunning = false;
            await conn.SaveAsync();
            await OracleConnector.ReloadAsync();
            this.IsRunning = false;
            this.SaveProgressVisibility = Visibility.Collapsed;
            this.SaveTextVisibility = Visibility.Visible;
            this.NavigateBack();
        }

        /// <summary>
        /// Handles click on 'test' button.
        /// </summary>t
        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task Test()
        {
            this.IsRunning = true;
            this.UnknownVisibility = Visibility.Collapsed;
            this.FailVisibility = Visibility.Collapsed;
            this.SuccessVisibility = Visibility.Collapsed;
            this.ProgressVisibility = Visibility.Visible;
            IConnection connection = await OracleConnector.ReloadAsync();
            Connection original = new Connection(
                connection.ConnectionModel.Server,
                connection.ConnectionModel.Port,
                connection.ConnectionModel.Database,
                connection.ConnectionModel.Username,
                connection.ConnectionModel.Password);
            await original.SaveAsync();
            Connection newData = new Connection(this.Server, this.Port, this.Database, this.Username, this.Password);
            await newData.SaveAsync();
            connection = await OracleConnector.ReloadAsync();
            bool connected = await connection.ConnectAsync();
            await original.SaveAsync();
            connection = await OracleConnector.ReloadAsync();
            this.ProgressVisibility = Visibility.Collapsed;
            if (connected == true)
            {
                this.SuccessVisibility = Visibility.Visible;
            }
            else
            {
                this.FailVisibility = Visibility.Visible;
            }
            this.IsRunning = false;
        }

        /// <summary>
        /// Checks, whether user can save the connection settings.
        /// </summary>
        /// <returns>
        /// TRUE, if user can save the connection settings
        /// FALSE otherwise.
        /// </returns>
        private bool CanSave()
        {
            return (
                this.Server.Length *
                this.Port.Length *
                this.Database.Length *
                this.Username.Length *
                this.Password.Length
                ) > 0
                && this.NotRunning();
        }

        /// <summary>
        /// Checks, whether test is NOT running.
        /// </summary>
        /// <returns>
        /// TRUE if test is NOT running,
        /// FALSE otherwise.
        /// </returns>
        private bool NotRunning() => !this.IsRunning;

        /// <summary>
        /// Handles click on 'back' button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(NotRunning))]
        private void BackClicked()
        {
            this.NavigateBack();
        }
    }
}
