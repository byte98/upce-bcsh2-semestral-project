using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View;
using SemestralProject.View.Components;
using SemestralProject.View.Navigation;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// Model view of log in form.
    /// </summary>
    [ObservableObject]
    public partial class LoginViewModel : NavigationSource
    {
        /// <summary>
        /// Personal number of user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private int personalNumber = new Random().Next(100000,1000000);

        /// <summary>
        /// Password of user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string? password;

        /// <summary>
        /// Flag, whether controls in form should be enabled.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        private bool controlsEnabled = true;

        /// <summary>
        /// Visibility of log in progress.
        /// </summary>
        [ObservableProperty]
        private Visibility loginVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of error message.
        /// </summary>
        [ObservableProperty]
        private Visibility errorVisibility = Visibility.Collapsed;

        /// <summary>
        /// Checks, whether user can logi n.
        /// </summary>
        /// <returns>
        /// TRUE, if user can log in,
        /// FALSE otherwise.
        /// </returns>
        private bool CanLogin()
        {
            return (
                this.PersonalNumber >= 100000 &&
                this.PersonalNumber <= 999999 &&
                this.Password != null &&
                this.Password.Length > 0 &&
                this.IsEnabled() == true
            );
        }

        /// <summary>
        /// Performs log in of user.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task Login()
        {
            this.ControlsEnabled = false;
            this.LoginVisibility = Visibility.Visible;
            this.ErrorVisibility = Visibility.Collapsed;
            Model.Login login = new Model.Login(this.Password ?? string.Empty, this.PersonalNumber);
            User? user = await login.CheckAsync();
            this.ControlsEnabled = true;
            this.LoginVisibility = Visibility.Collapsed;
            if (user == null)
            {
                this.ErrorVisibility = Visibility.Visible;
                this.ControlsEnabled = true;
            }
            else
            {
                WeakReferenceMessenger.Default.Send<LoggedUserChangedMessage>(
                    new LoggedUserChangedMessage(user)
                    );
                WeakReferenceMessenger.Default.Send<LoggedRoleChangedMessage>(
                    new LoggedRoleChangedMessage(user.Role)
                );
                WindowUtils.CloseForModel(typeof(MainWindowViewModel));
            }
        }

        /// <summary>
        /// Checks, whether controls should be enabled.
        /// </summary>
        /// <returns>
        /// TRUE, if controls should be enabled,
        /// FALSE otherwise.
        /// </returns>
        private bool IsEnabled() => this.ControlsEnabled;

        /// <summary>
        /// Navigates user to register page.
        /// </summary>
        [RelayCommand(CanExecute =nameof(IsEnabled))]
        private void Register()
        {
            this.Navigate(new Register());
        }

        /// <summary>
        /// Handles change of password.
        /// </summary>
        /// <param name="pb">Password box containing actual password.</param>
        [RelayCommand]
        private void PasswordChanged(PasswordBox pb)
        {
            this.Password = pb.Password;
        }

    }
}
