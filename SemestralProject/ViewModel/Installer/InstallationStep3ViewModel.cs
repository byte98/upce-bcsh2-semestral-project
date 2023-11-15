using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.View.Installer;
using SemestralProject.View.Navigation;
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
        private string name;

        /// <summary>
        /// Surname of created user.
        /// </summary>
        [ObservableProperty]
        private string surname;

        /// <summary>
        /// E-mail of created user.
        /// </summary>
        [ObservableProperty]
        private string email;

        /// <summary>
        /// Phone number of created user.
        /// </summary>
        [ObservableProperty]
        private string phone;

        /// <summary>
        /// Personal number of created user.
        /// </summary>
        [ObservableProperty]
        private int personalNumber;

        /// <summary>
        /// Password of created user.
        /// </summary>
        private string password;

        /// <summary>
        /// String representation of address.
        /// </summary>
        [ObservableProperty]
        private string addressString;

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
            this.userImage = UserImage.Default;
            this.Image = this.userImage.ToImage();
            this.ImageSource = "<výchozí obrázek>";
            this.name = string.Empty;
            this.surname = string.Empty;
            this.email = string.Empty;
            this.phone = string.Empty;
            this.personalNumber = 100000;
            this.password = string.Empty;
            this.addressString = string.Empty;
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
                this.userImage = UserImage.FromFile(dialog.FileName);
                this.Image = this.userImage.ToImage();
                this.ImageSource = dialog.FileName;
            }
        }

        /// <summary>
        /// Finds address of user.
        /// </summary>
        [RelayCommand]
        private void FindCommand()
        {

        }

        /// <summary>
        /// Handles change of password.
        /// </summary>
        /// <param name="pb">Password box containing actual password.</param>
        [RelayCommand]
        private void PasswordChanged(PasswordBox pb)
        {
            this.password = pb.Password;
        }

        /// <summary>
        /// Handles initialization procedure after control is loaded.
        /// </summary>
        [RelayCommand]
        private void ControlLoaded()
        {
            this.userImage = UserImage.Default;
            this.Image = this.userImage.ToImage();
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
        [RelayCommand]
        private void Next()
        {

        }

        /// <summary>
        /// Redirects user to the previous step of installation process.
        /// </summary>
        [RelayCommand]
        private void Previous()
        {
            this.ChangeContent(new InstallationStep1());
        }

        public void SetData(InstallationModel data)
        {
            this.model = data;
        }
    }
}
