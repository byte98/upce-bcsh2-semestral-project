using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SemestralProject.View.Pages
{
    /// <summary>
    /// Interaction logic for PermissionsPage.xaml
    /// </summary>
    public partial class PermissionsPage : Page
    {
        public PermissionsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles click on close add new role cancel button.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Arguments of event.</param>
        private void ButtonFlyoutCancel_Click(object sender, RoutedEventArgs e)
        {
            this.FlyoutNewRole.Hide();
        }
    }
}
