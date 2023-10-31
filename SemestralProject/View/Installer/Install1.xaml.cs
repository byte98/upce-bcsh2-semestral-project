using SemestralProject.Model;
using SemestralProject.View.Events;
using SemestralProject.ViewModel;
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

namespace SemestralProject.View.Installer
{
    /// <summary>
    /// Interaction logic for Install1.xaml
    /// </summary>
    public partial class Install1 : UserControl
    {
        /// <summary>
        /// Handler of the whole installation process.
        /// </summary>
        private readonly InstallViewModel install;

        /// <summary>
        /// Event triggered when form fill state has changed.
        /// </summary>
        public event FormFilledEventHandler? DatabaseFilled;

        /// <summary>
        /// Creates first stage of the installation.
        /// </summary>
        /// <param name="install">Handler of the whole installation process.</param>
        public Install1(InstallViewModel install)
        {
            InitializeComponent();
            this.install = install;
            this.DatabaseConnection.FormFilled += (sender, args) =>
            {
                this.DatabaseFilled?.Invoke(sender, args);
            };
        }

        /// <summary>
        /// Gets connection model entered by user.
        /// </summary>
        /// <returns>Connection model with values from user.</returns>
        public ConnectionModel GetConnectionModel()
        {
            return (ConnectionModel)this.DatabaseConnection.DataContext;
        }

        /// <summary>
        /// Clears all inputs entered by user.
        /// </summary>
        public void ClearForm()
        {
            this.DatabaseConnection.ClearForm();
        }
    }
}
