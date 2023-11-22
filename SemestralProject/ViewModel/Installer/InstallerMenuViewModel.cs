using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.View;
using SemestralProject.View.Installer;
using SemestralProject.View.Installer.Truncate;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace SemestralProject.ViewModel.Installer
{
    /// <summary>
    /// Class which handles behaviour of installer menu.
    /// </summary>
    [ObservableObject]
    public partial class InstallerMenuViewModel: NavigationSource
    {
        /// <summary>
        /// Creates new handler of behaviour of installer menu.
        /// </summary>
        public InstallerMenuViewModel() : base() { }

        /// <summary>
        /// Actual version of program.
        /// </summary>
        [ObservableProperty]
        private string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "<neznámý údaj>";

        /// <summary>
        /// Address of server on which database runs.
        /// </summary>
        [ObservableProperty]
        private string server = Connection.Unknown.Server;

        /// <summary>
        /// Port on which database runs.
        /// </summary>
        [ObservableProperty]
        private string port = Connection.Unknown.Port;

        /// <summary>
        /// Username of user with access to the database.
        /// </summary>
        [ObservableProperty]
        private string username = Connection.Unknown.Username;

        /// <summary>
        /// Name of database.
        /// </summary>
        [ObservableProperty]
        private string database = Connection.Unknown.Database;

        /// <summary>
        /// Visibility of connection progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility connectionProgressRingVisibility = Visibility.Visible;

        /// <summary>
        /// Visibility of connection information.
        /// </summary>
        [ObservableProperty]
        private Visibility connectionInfoVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of connection state progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility connectionStateProgressRingVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of connection success.
        /// </summary>
        [ObservableProperty]
        private Visibility connectionSuccessVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of connection fail.
        /// </summary>
        [ObservableProperty]
        private Visibility connectionFailVisibility = Visibility.Collapsed;

        /// <summary>
        /// Handles initialization after loading of page.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            IConnection conn = await OracleConnector.ReloadAsync();
            this.Server = conn.ConnectionModel.Server;
            this.Port = conn.ConnectionModel.Port;
            this.Database = conn.ConnectionModel.Database;
            this.Username = conn.ConnectionModel.Username;
            this.ConnectionProgressRingVisibility = Visibility.Collapsed;
            this.ConnectionInfoVisibility = Visibility.Visible;
            if (conn.ConnectionModel.IsUnknown())
            {
                this.ConnectionStateProgressRingVisibility = Visibility.Collapsed;
                this.ConnectionFailVisibility = Visibility.Visible;
            }
            else
            {
                this.ConnectionStateProgressRingVisibility = Visibility.Visible;
                bool connected = await conn.ConnectAsync();
                this.ConnectionStateProgressRingVisibility = Visibility.Collapsed;
                if (connected)
                {
                    this.ConnectionSuccessVisibility = Visibility.Visible;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    conn.DisconnectAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                }
                else
                {
                    this.ConnectionFailVisibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Handles click on 'install' button.
        /// </summary>
        [RelayCommand]
        private void ButtonInstallClicked()
        {
            this.Navigate(new InstallationProcess());
        }

        /// <summary>
        /// Handles click on 'manage database' button.
        /// </summary>
        [RelayCommand]
        private void ButtonManageDatabaseClicked()
        {
            this.Navigate(new ManageDatabase());
        }

        /// <summary>
        /// Handles click on 'delete data' button.
        /// </summary>
        [RelayCommand]
        private void ButtonDeleteDataClicked()
        {
            this.Navigate(new TruncateProcess());
        }
    }
}
