using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.View;
using SemestralProject.View.Components;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SemestralProject.ViewModel.Pages
{
    /// <summary>
    /// Class which handles behaviour of page with users data.
    /// </summary>
    public partial class MyPageViewModel: ObservableObject
    {
        /// <summary>
        /// User which data will be displayed.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private User? user;

        /// <summary>
        /// Role of actual user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeRoleCommand))]
        private Role? role;

        /// <summary>
        /// Image of actual user.
        /// </summary>
        private UserImage? image;

        /// <summary>
        /// Address of actual address.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private Address? address;
        
        /// <summary>
        /// Source of image of actual user.
        /// </summary>
        [ObservableProperty]
        private ImageSource? imageSource;

        /// <summary>
        /// Name of actual user.
        /// </summary>
        [ObservableProperty]
        private string name = string.Empty;

        /// <summary>
        /// Surname of actual user.
        /// </summary>
        [ObservableProperty]
        private string surname = string.Empty;

        /// <summary>
        /// Personal number of actual user.
        /// </summary>
        [ObservableProperty]
        private int personalNumber;

        /// <summary>
        /// Phone of actual user.
        /// </summary>
        [ObservableProperty]
        private string phone = string.Empty;

        /// <summary>
        /// Email of actual user.
        /// </summary>
        [ObservableProperty]
        private string email = string.Empty;

        /// <summary>
        /// Date and time of registration of actual user.
        /// </summary>
        [ObservableProperty]
        private DateTime registration;

        /// <summary>
        /// Date and time of start of employment of actual user.
        /// </summary>
        [ObservableProperty]
        private DateTime employment;

        /// <summary>
        /// Flag of data should be read only.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private bool readonlyData = true;

        /// <summary>
        /// Flag gathered from user, whether data should be read only.
        /// </summary>
        private bool userReadOnlyData = true;

        /// <summary>
        /// Flag of registration should be editable.
        /// </summary>
        [ObservableProperty]
        private bool editableRegistration = false;

        /// <summary>
        /// Flag gathered from user, whether registration should be editable.
        /// </summary>
        private bool userEditableRegistration = false;

        /// <summary>
        /// Flag, whether employment date should be editable;
        /// </summary>
        [ObservableProperty]
        private bool editableEmployment = false;

        /// <summary>
        /// Flag gathered from user, whether employment date should be editable.
        /// </summary>
        private bool userEditableEmployement = false;

        /// <summary>
        /// Flag, whether personal number should be editable.
        /// </summary>
        [ObservableProperty]
        private bool editablePersonalNumber = false;

        /// <summary>
        /// Flag gathered from user, whether personal number should be editable.
        /// </summary>
        private bool userEditablePersonalNumber = false;

        /// <summary>
        /// Flag, whether image should be editable.
        /// </summary>
        [ObservableProperty]
        private bool editableImage = false;

        /// <summary>
        /// Flag gathered from user, whether image should be editable.
        /// </summary>
        private bool userEditableImage = false;

        /// <summary>
        /// Visibility of save button.
        /// </summary>
        [ObservableProperty]
        private Visibility saveVisibility = Visibility.Hidden;

        /// <summary>
        /// Flag, whether saving process is running.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private bool saving = false;

        /// <summary>
        /// Visibility of role select button.
        /// </summary>
        [ObservableProperty]
        private Visibility roleSelectVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of text in save button.
        /// </summary>
        [ObservableProperty]
        private Visibility saveTextVisibility = Visibility.Visible;

        /// <summary>
        /// Visibility of progress in save button.
        /// </summary>
        [ObservableProperty]
        private Visibility saveProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Actually selected role.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private Role? selectedRole;

        /// <summary>
        /// Text representation of actually selected role.
        /// </summary>
        [ObservableProperty]
        private string selectedRoleText = string.Empty;

        /// <summary>
        /// Flag, whether role of user should be changed when message
        /// informing about change of user is recevied.
        /// </summary>
        private bool changeRole = true;

        /// <summary>
        /// Lastly updated image.
        /// </summary>
        private ImageFile? imageFile;

        /// <summary>
        /// Creates new handler of page with users data.
        /// </summary>
        public MyPageViewModel()
        {
            WeakReferenceMessenger.Default.Register<LoggedUserChangedMessage>(this, (sender, args) =>
            {
                this.User = args.Value;
                this.UserChanged();
            });
            WeakReferenceMessenger.Default.Register<LoggedRoleChangedMessage>(this, (sender, args) =>
            {
                this.Role = args.Value;
                this.RoleChanged();
            });

        }

        /// <summary>
        /// Handles load of page.
        /// </summary>
        [RelayCommand]
        private void PageLoaded()
        {
            if (this.User != null)
            {
                WeakReferenceMessenger.Default.Send<SelectedAddressChangedMessage>(new SelectedAddressChangedMessage(this.User.Employee.Residence));
            }
            WeakReferenceMessenger.Default.Register<SelectedAddressChangedMessage>(this, (sender, args) =>
            {
                this.Address = args.Value;
            });
        }
        
        /// <summary>
        /// Handles change of user.
        /// </summary>
        private void UserChanged()
        {
            if (this.User != null)
            {
                WeakReferenceMessenger.Default.Send<SelectedAddressChangedMessage>(new SelectedAddressChangedMessage(this.User.Employee.Residence));
                this.Name = this.User.Employee.PersonalData.Name;
                this.Surname = this.User.Employee.PersonalData.Surname;
                this.Email = this.User.Employee.PersonalData.Email;
                this.Phone = this.User.Employee.PersonalData.Phone;
                this.PersonalNumber = this.User.Employee.PersonalNumber;
                this.image = UserImage.FromImageFile(this.User.Image);
                this.ImageSource = this.image.ToImage();
                this.Registration = this.User.Registration;
                this.Employment = this.User.Employee.EmploymentDate;
                this.SelectedRole = this.User.Role;
                this.SelectedRoleText = this.SelectedRole.Name;
                this.Address = this.User.Employee.Residence;
            }
        }

        /// <summary>
        /// Hanldes change of role.
        /// </summary>
        private async void RoleChanged()
        {
            if (this.changeRole == true)
            {

                this.ReadonlyData = true;
                this.EditableImage = false;
                this.EditableEmployment = false;
                this.EditablePersonalNumber = false;
                this.EditableRegistration = false;
                this.RoleSelectVisibility = Visibility.Collapsed;
                this.SaveVisibility = Visibility.Hidden;
                if (this.Role != null)
                {
                    await this.Role.LoadPermissionsAsync();
                    bool editPerm = this.Role.HasPermission(PermissionNames.UserModifyOwn);
                    bool changePersonalPerm = this.Role.HasPermission(PermissionNames.EmployeePersonal_numberModifyOwn);
                    bool changeRegPerm = this.Role.HasPermission(PermissionNames.UserDateModifyOwn);
                    bool changeEmplPerm = this.Role.HasPermission(PermissionNames.EmployeeDateModifyOwn);
                    bool changeRolePerm = this.Role.HasPermission(PermissionNames.RoleModifyOwn);
                    if (changeRolePerm)
                    {
                        this.RoleSelectVisibility = Visibility.Visible;
                    }
                    this.EditableEmployment = (editPerm && changeEmplPerm);
                    this.EditablePersonalNumber = (editPerm && changePersonalPerm);
                    this.EditableRegistration = (editPerm && changeRegPerm);
                    this.ReadonlyData = !editPerm;
                    this.EditableImage = editPerm;

                    this.userEditableEmployement = this.EditableEmployment;
                    this.userEditablePersonalNumber = this.EditablePersonalNumber;
                    this.userEditableRegistration = this.EditableRegistration;
                    this.userEditableImage = this.EditableImage;
                    this.userReadOnlyData = this.ReadonlyData;
                    if (editPerm == true)
                    {
                        this.SaveVisibility = Visibility.Visible;
                    }
                }
            }
        }

        /// <summary>
        /// Handles click on 'search picture' button.
        /// </summary>
        [RelayCommand]
        private async Task SearchPicture()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Všechny obrázky | *.bmp;*.gif;*jpg;*.jpeg;*.png";
            bool? result = dialog.ShowDialog();
            if (result != null && result == true)
            {
                this.image = UserImage.FromFile(dialog.FileName);
                this.ImageSource = this.image.ToImage();
                this.imageFile = await ImageFile.FromFileAsync(dialog.FileName);
            }
        }

        /// <summary>
        /// Disables all controls.
        /// </summary>
        private void Disable()
        {
            this.ReadonlyData = true;
            this.EditableRegistration = false;
            this.EditableEmployment = false;
            this.EditableImage = false;
            this.EditablePersonalNumber = false;
        }

        /// <summary>
        /// Re-enables all controls.
        /// </summary>
        private void ReEnable()
        {
            this.ReadonlyData = this.userReadOnlyData;
            this.EditableRegistration = this.userEditableRegistration;
            this.EditableEmployment = this.userEditableEmployement;
            this.EditableImage = this.userEditableImage;
            this.EditablePersonalNumber = this.userEditablePersonalNumber;
        }

        /// <summary>
        /// Checks, whether save button should be enabled.
        /// </summary>
        /// <returns>
        /// TRUE if save button should be enabled,
        /// FALSE otherwise.
        /// </returns>
        private bool IsSaveEnabled()
        {
            bool isNotReadOnly = false,
                 isNotSaving = false,
                 userIsNotNull = false,
                 roleIsNotNull = false,
                 nameIsNotEmpty = false,
                 surnameIsNotEmpty = false,
                 emailIsNotEmpty = false,
                 phoneIsNotEmpty = false;
            isNotReadOnly = this.ReadonlyData == false;
            isNotSaving = this.Saving == false;
            userIsNotNull = this.User != null;
            roleIsNotNull = this.SelectedRole != null;
            nameIsNotEmpty = this.Name != null && this.Name.Length > 0;
            surnameIsNotEmpty = this.Surname != null && this.Surname.Length > 0;
            emailIsNotEmpty = this.Email != null && this.Email.Length > 0;
            phoneIsNotEmpty = this.Phone != null && this.Phone.Length > 0;
            return (isNotReadOnly && isNotSaving && userIsNotNull && roleIsNotNull &&
                nameIsNotEmpty && surnameIsNotEmpty && emailIsNotEmpty && phoneIsNotEmpty);
        }

        /// <summary>
        /// Checks, whtether user can change its role.
        /// </summary>
        /// <returns>TRUE if user can change its role, FALSE otherwise.</returns>
        private bool CanChangeRole() => this.Role != null && this.Role.HasPermission(PermissionNames.RoleModifyOwn);

        /// <summary>
        /// Handles click on change role button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(CanChangeRole))]
        private void ChangeRole()
        {
            RoleSelectionWindow window = new RoleSelectionWindow();
            if (this.SelectedRole != null)
            {
                this.changeRole = false;
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.SelectedRole));
                this.changeRole = true;
            }
            WeakReferenceMessenger.Default.Register<SelectedRoleChangedMessage>(this, (sender, args) =>
            {
                this.SelectedRole = args.Value;
                this.SelectedRoleText = this.SelectedRole.Name;
            });
            window.ShowDialog();
            WeakReferenceMessenger.Default.Unregister<SelectedRoleChangedMessage>(this);
        }

        /// <summary>
        /// Handles click on save button.
        /// </summary>
        [RelayCommand(CanExecute = nameof(IsSaveEnabled))]
        private async Task Save()
        {
            this.SaveTextVisibility = Visibility.Collapsed;
            this.SaveProgressVisibility = Visibility.Visible;
            this.Saving = true;
            this.Disable();
            if (this.User != null && this.Address != null)
            {
                Person p = this.User.Employee.PersonalData;
                p.Name = this.Name;
                p.Email = this.Email;
                p.Phone = this.Phone;
                p.Surname = this.Surname;
                await p.UpdateAsync();
                Employee e = this.User.Employee;
                e.Residence = this.Address;
                e.EmploymentDate = this.Employment;
                e.PersonalNumber = this.PersonalNumber;
                await e.UpdateAsync();
                if (this.imageFile != null)
                {
                    this.User.Image = this.imageFile;
                }
                this.User.Registration = this.Registration;
                await this.User.UpdateAsync();
                WeakReferenceMessenger.Default.Send<LoggedUserChangedMessage>(new LoggedUserChangedMessage(this.User));
            }
            this.Saving = false;
            this.ReEnable();
            this.SaveTextVisibility = Visibility.Visible;
            this.SaveProgressVisibility = Visibility.Collapsed;
        }
    }
}
