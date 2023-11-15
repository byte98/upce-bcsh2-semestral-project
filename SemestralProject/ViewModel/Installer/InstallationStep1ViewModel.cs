using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model;
using SemestralProject.View.Installer;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SemestralProject.ViewModel.Installer
{
    /// <summary>
    /// Class which handles first step of installation process.
    /// </summary>
    [ObservableObject]
    public partial class InstallationStep1ViewModel : NavigationDynamicContent<InstallationModel>
    {
        /// <summary>
        /// Server on which database runs.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string server;

        /// <summary>
        /// Port on which database runs.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string port;

        /// <summary>
        /// Name of database.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string database;

        /// <summary>
        /// Username of user with access to database.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string username;

        /// <summary>
        /// Password of user. 
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string password;

        /// <summary>
        /// Creates new handler of first step of installation process.
        /// </summary>
        public InstallationStep1ViewModel() : base()
        {
            this.server = string.Empty;
            this.port = string.Empty;
            this.database = string.Empty;
            this.username = string.Empty;
            this.password = string.Empty;
            if (InstallationProcessViewModel.Instance != null)
            {
                InstallationProcessViewModel.Instance.RegisterDynamicSource(this);
            }
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
        /// Handles click on back button.
        /// </summary>
        [RelayCommand]
        private void BackClicked()
        {
            this.NavigateBack();
        }

        /// <summary>
        /// Continues to next step of installation.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanContinue))]
        private void Next()
        {
            this.ChangeContent(new InstallationStep2(), new InstallationModel(
                this.Server, this.Port, this.Database, this.Username, this.Password
                ));
        }

        /// <summary>
        /// Returns to previous step of installation.
        /// </summary>
        [RelayCommand(CanExecute = nameof(ConstantFalse))]
        private void Previous()
        {
            // NOP
        }

        /// <summary>
        /// Function which returns FALSE.
        /// </summary>
        /// <returns>Always FALSE.</returns>
        private bool ConstantFalse() => false;

        /// <summary>
        /// Checks, whether user can continue to the next step of installation.
        /// </summary>
        /// <returns>
        /// TRUE, if user can continue to the next step of installation,
        /// FALSE otherwise.
        /// </returns>
        private bool CanContinue()
        {
            return (
                this.Server.Length *
                this.Port.Length *
                this.Database.Length *
                this.Username.Length *
                this.Password.Length
                ) > 0;
        }
    }
}
