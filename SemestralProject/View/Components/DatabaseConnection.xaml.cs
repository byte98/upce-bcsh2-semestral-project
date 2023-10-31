using SemestralProject.View.Events;
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

namespace SemestralProject.View.Components
{
    /// <summary>
    /// Interaction logic for DatabaseConnection.xaml
    /// </summary>
    public partial class DatabaseConnection : UserControl
    {
        /// <summary>
        /// Flag, whether form is filled.
        /// </summary>
        private bool isFilled;

        /// <summary>
        /// Event triggered when state of form filling has changed.
        /// </summary>
        public event FormFilledEventHandler? FormFilled;

        public DatabaseConnection()
        {
            InitializeComponent();
            this.isFilled = false;
        }

        /// <summary>
        /// Checks, whether form is filled.
        /// </summary>
        private void CheckFilled()
        {
            if (
                this.TextBoxUsername.Text.Length > 0 &&
                this.TextBoxDatabase.Text.Length > 0 &&
                this.TextBoxPort.Text.Length > 0 &&
                this.TextBoxServer.Text.Length > 0 &&
                this.PasswordBox.Password.Length > 0)
            {
                if (this.isFilled == false)
                {
                    this.isFilled = true;
                    this.FormFilled?.Invoke(this, new FormFilledEventArgs(this.isFilled));
                }
            }
            else
            {
                if (this.isFilled == true)
                {
                    this.isFilled = false;
                    this.FormFilled?.Invoke(this, new FormFilledEventArgs(this.isFilled));
                }
            }
        }

        /// <summary>
        /// Clears all data in form.
        /// </summary>
        public void ClearForm()
        {
            this.TextBoxDatabase.Text = string.Empty;
            this.TextBoxPort.Text = string.Empty;
            this.TextBoxServer.Text = string.Empty;
            this.TextBoxUsername.Text = string.Empty;
            this.PasswordBox.Password = string.Empty;
            this.isFilled = false;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
            this.CheckFilled();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.CheckFilled();
        }
    }
}
