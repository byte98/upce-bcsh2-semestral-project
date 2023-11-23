using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
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
    /// Class which handles behaviour of registration form.
    /// </summary>
    [ObservableObject]
    public partial class RegisterViewModel: NavigationSource
    {
        /// <summary>
        /// Name of user which will be registered.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        private string name = string.Empty;

        /// <summary>
        /// Surname of user which will be registered.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        private string surname = string.Empty;

        /// <summary>
        /// E-mail of user which will be registered.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        private string email = string.Empty;

        /// <summary>
        /// Phone of user which will be registered.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        private string phone = string.Empty;

        /// <summary>
        /// Password of user which will be registered.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        private string password = string.Empty;

        /// <summary>
        /// Address of residence of user which will be registered.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        private Address? address;

        /// <summary>
        /// Flag, whether controls are enabled.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private bool controlsEnabled = true;

        /// <summary>
        /// Visibility of text in 'register' button.
        /// </summary>
        [ObservableProperty]
        private Visibility buttonTextVisibility = Visibility.Visible;

        /// <summary>
        /// Visibility of progress ring in 'register' button.
        /// </summary>
        [ObservableProperty]
        private Visibility buttonProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Creates new view model for registration form.
        /// </summary>
        public RegisterViewModel()
        {
            WeakReferenceMessenger.Default.Register<SelectedAddressChangedMessage>(this, (sender, args) =>
            {
                this.Address = args.Value;
            });
        }

        /// <summary>
        /// Handles click on 'register' button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(CanRegister))]
        private void Register()
        {
            this.ControlsEnabled = false;
            this.ButtonTextVisibility = Visibility.Collapsed;
            this.ButtonProgressVisibility = Visibility.Visible;

        }

        /// <summary>
        /// Restarts state of form to initialized one.
        /// </summary>
        private void RestartForm()
        {
            this.ButtonTextVisibility = Visibility.Visible;
            this.ButtonProgressVisibility = Visibility.Collapsed;
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Email = string.Empty;
            this.Phone = string.Empty;
            this.Password = string.Empty;
        }

        /// <summary>
        /// Checks, whether controls are enabled.
        /// </summary>
        /// <returns>
        /// TRUE if controls are enabled,
        /// FALSE otherwise.
        /// </returns>
        private bool IsEnabled() => this.ControlsEnabled;

        /// <summary>
        /// Checks, whether user can register.
        /// </summary>
        /// <returns>
        /// TRUE if registration is allowed,
        /// FALSE otherwise.
        /// </returns>
        private bool CanRegister()
        {
            return (
                this.Name.Length > 0 &&
                this.Surname.Length > 0 &&
                this.Email.Length > 0 &&
                this.Phone.Length > 0 &&
                this.Password.Length > 0 &&
                this.Address != null &&
                this.IsEnabled() == true
                );
        }

        /// <summary>
        /// Handles change of password.
        /// </summary>
        /// <param name="pb">Password box containing password.</param>
        [RelayCommand]
        private void PasswordChanged(PasswordBox pb)
        {
            this.Password = pb.Password;
        }

        /// <summary>
        /// Handles click on 'login' button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(IsEnabled))]
        private void Login()
        {
            this.NavigateBack();
        }
    }
}
