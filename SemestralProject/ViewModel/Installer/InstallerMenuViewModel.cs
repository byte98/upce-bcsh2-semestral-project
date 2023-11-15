using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.View;
using SemestralProject.View.Installer;
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
        /// Connection to the database.
        /// </summary>
        [ObservableProperty]
        private Connection connection = Connection.Unknown;

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
            this.Connection = conn.ConnectionModel;
            this.ConnectionProgressRingVisibility = Visibility.Collapsed;
            this.ConnectionInfoVisibility = Visibility.Visible;
            if (this.Connection.IsUnknown())
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
    }
}
