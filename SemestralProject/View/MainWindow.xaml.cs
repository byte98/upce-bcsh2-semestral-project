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

namespace SemestralProject.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Flag, whether installer window is visible.
        /// </summary>
        private bool installerVisible = false;

        /// <summary>
        /// Window with installer of the application.
        /// </summary>
        private InstallerWindow? installerWindow;

        public MainWindow()
        {
            InitializeComponent();
            this.LabelVersion.Content = Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.installerVisible == false)
            {
                this.installerVisible = true;
                this.installerWindow = new InstallerWindow();
                this.installerWindow.Show();
                this.installerWindow.Closed += InstallerWindow_Closed;
            }
            else
            {
                this.installerWindow?.Activate();
            }
        }

        private void InstallerWindow_Closed(object? sender, EventArgs e)
        {
            this.installerVisible = false;
        }
    }
}
