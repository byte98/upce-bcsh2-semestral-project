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
        /// <summary>
        /// Currently set password.
        /// </summary>
        public static string Password = string.Empty;

        /// <summary>
        /// Instance of this page.
        /// </summary>
        private static UsersPage? instance;

        public UsersPage()
        {
            InitializeComponent();
            UsersPage.instance = this;
        }

        /// <summary>
        /// Clears entered password.
        /// </summary>
        public static void ClearPassword()
        {
            if (UsersPage.instance != null)
            {
                UsersPage.instance.passwordBox.Password = string.Empty;
                UsersPage.Password = string.Empty;
            }
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

        /// <summary>
        /// Handles click on cancel button in password flyout.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Arguments of event.</param>
        private void ButtonFlyoutPasswordCancel_Click(object sender, RoutedEventArgs e)
        {
            this.FlyoutPassword.Hide();
        }

        /// <summary>
        /// Handles change of password.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Arguments of event.</param>
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UsersPage.Password = this.passwordBox.Password;
        }
    }
}
