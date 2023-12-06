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
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles click on cancel button in flyout.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Arguments of event.</param>
        private void ButtonFlyoutCancel_Click(object sender, RoutedEventArgs e)
        {
            this.FlyoutChange.Hide();
        }

        /// <summary>
        /// Handles click on cancel button in role flyout.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Arguments of event.</param>
        private void ButtonFlyoutRoleCancel_Click(object sender, RoutedEventArgs e)
        {
            this.FlyoutRole.Hide();
        }
    }
}
