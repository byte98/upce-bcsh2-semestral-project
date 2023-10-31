using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SemestralProject.View.Installer
{
    /// <summary>
    /// Interaction logic for InstallerTitle.xaml
    /// </summary>
    public partial class InstallerTitle : Page
    {
        public InstallerTitle()
        {
            InitializeComponent();
            this.LabelVersion.Content = Assembly.GetExecutingAssembly().GetName().Version;
            Task.Run(async () =>
            {
                IConnection conn = await OracleConnector.Load();
                Dispatcher.Invoke(() =>
                {
                    this.ProgressRingDBLoader.Visibility = Visibility.Collapsed;
                    this.LabelDBServer.Content = conn.ConnectionModel.Server;
                    this.LabelDBPort.Content = conn.ConnectionModel.Port;
                    this.LabelDBUsername.Content = conn.ConnectionModel.Username;
                    this.LabelDBName.Content = conn.ConnectionModel.Database;
                    this.GridDBInfo.Visibility = Visibility.Visible;
                });
                if (conn.ConnectionModel.IsUnknown())
                {
                    Dispatcher.Invoke(() =>
                    {
                        this.ProgressRingDBState.Visibility = Visibility.Collapsed;
                        this.StackPanelDBStateDisconnected.Visibility = Visibility.Visible;
                    });
                }
                else
                {
                    bool connected = await conn.ConnectAsync();
                    Dispatcher.Invoke(() =>
                    {
                        this.ProgressRingDBState.Visibility = Visibility.Collapsed;
                        if (connected == true)
                        {
                            this.StackPanelDBStateConnected.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            this.StackPanelDBStateDisconnected.Visibility = Visibility.Visible;
                        }
                    });
                }
            });
        }

        private void ButtonInstall_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Install());
        }
        
    }
}
