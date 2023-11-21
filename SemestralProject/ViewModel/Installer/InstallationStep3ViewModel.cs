using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.Model.Entities;
using SemestralProject.View.Installer;
using SemestralProject.View.Navigation;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media;

namespace SemestralProject.ViewModel.Installer
{
    /// <summary>
    /// View model of third step of installation process.
    /// </summary>
    [ObservableObject]
    public partial class InstallationStep3ViewModel : NavigationDynamicContent<InstallationModel>, IDynamicTarget<InstallationModel>
    {
        /// <summary>
        /// Model of installation process.
        /// </summary>
        private InstallationModel model;

        /// <summary>
        /// Content of user image.
        /// </summary>
        [ObservableProperty]
        private ImageSource image;

        /// <summary>
        /// Image of user
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private UserImage userImage;

        /// <summary>
        /// Path to image source.
        /// </summary>
        [ObservableProperty]
        private string imageSource;

        /// <summary>
        /// Name of created user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string name;

        /// <summary>
        /// Surname of created user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string surname;

        /// <summary>
        /// E-mail of created user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string email;

        /// <summary>
        /// Phone number of created user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string phone;

        /// <summary>
        /// Personal number of created user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private int personalNumber;

        /// <summary>
        /// Password of created user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private string password;

        /// <summary>
        /// Address of user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextCommand))]
        private Address? address;

        /// <summary>
        /// Creates new view model for third step of installation process.
        /// </summary>
        public InstallationStep3ViewModel()
        {
            if (InstallationProcessViewModel.Instance != null)
            {
                InstallationProcessViewModel.Instance.RegisterDynamicSource(this);
                InstallationProcessViewModel.Instance.RegisterTarget(this);
            }
            this.UserImage = UserImage.Default;
            this.Image = this.userImage.ToImage();
            this.ImageSource = "<výchozí obrázek>";
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Email = string.Empty;
            this.Phone = string.Empty;
            this.PersonalNumber = 100000;
            this.Password = string.Empty;
            WeakReferenceMessenger.Default.Register<SelectedAddressChangedMessage>(this, (sender, args) =>
            {
                this.Address = args.Value;
            });
        }

        /// <summary>
        /// Finds image of user.
        /// </summary>
        [RelayCommand]
        private void FindImage()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Všechny obrázky | *.bmp;*.gif;*jpg;*.jpeg;*.png";
            bool? result = dialog.ShowDialog();
            if (result != null && result == true)
            {
                this.UserImage = UserImage.FromFile(dialog.FileName);
                this.Image = this.UserImage.ToImage();
                this.ImageSource = dialog.FileName;
            }
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

        /// <summary>
        /// Handles initialization procedure after control is loaded.
        /// </summary>
        [RelayCommand]
        private void ControlLoaded()
        {
            this.UserImage = UserImage.Default;
            this.Image = this.UserImage.ToImage();
            this.ImageSource = "<výchozí obrázek>";
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
        /// Redirects user to the next step of installation process.
        /// </summary>
        [RelayCommand(CanExecute =nameof(CanContinue))]
        private void Next()
        {
            if (this.model.Database != null)
            {
                this.ChangeContent(new InstallationStep4(), new InstallationModel(
                    this.model.Database,
                    this.Name,
                    this.Surname,
                    this.Email,
                    this.Phone,
                    this.Password,
                    this.PersonalNumber,
                    this.UserImage,
                    this.Address
                ));
            }
        }

        /// <summary>
        /// Redirects user to the previous step of installation process.
        /// </summary>
        [RelayCommand]
        private void Previous()
        {
            this.ChangeContent(new InstallationStep1());
        }

        /// <summary>
        /// Checks, whether user can continue to the next step of installation.
        /// </summary>
        /// <returns>
        /// TRUE if user can continue to the next step of installation,
        /// FALSE otherwise.
        /// </returns>
        public bool CanContinue()
        {
            bool reti = false;
            if (this.Name.Length > 0 &&
                this.Surname.Length > 0 &&
                this.PersonalNumber >= 100000 && this.PersonalNumber <= 999999 &&
                this.Email.Length > 0 && 
                this.Phone.Length > 0 &&
                this.Password.Length > 0 &&
                this.Address != null)
            {
                reti = true;
            }
            return reti;
        }

        public void SetData(InstallationModel data)
        {
            this.model = data;
        }
    }
}
