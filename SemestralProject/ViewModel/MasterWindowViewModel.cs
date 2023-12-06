using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.Utils;
using SemestralProject.View;
using SemestralProject.View.Components;
using SemestralProject.View.Navigation;
using SemestralProject.View.Pages;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SemestralProject.ViewModel
{
    /// <summary>
    /// Class which handles behaviour of master window.
    /// </summary>
    [ObservableObject]
    public partial class MasterWindowViewModel : NavigationSource
    {

        /// <summary>
        /// Actually logged user.
        /// </summary>
        private User? user;

        /// <summary>
        /// Actually displayed role of user.
        /// </summary>
        private Role? role;

        /// <summary>
        /// Content of user image.
        /// </summary>
        [ObservableProperty]
        private ImageSource image;

        /// <summary>
        /// Name of user.
        /// </summary>
        [ObservableProperty]
        private string name = string.Empty;

        /// <summary>
        /// Displayed role of user.
        /// </summary>
        [ObservableProperty]
        private string displayRole = string.Empty;

        /// <summary>
        /// Visibility of change role button.
        /// </summary>
        [ObservableProperty]
        private Visibility changeRoleVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of role management.
        /// </summary>
        [ObservableProperty]
        private Visibility rolesVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of users menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility usersVisibility = Visibility.Collapsed;

        /// <summary>
        /// Page with users details.
        /// </summary>
        private MyPage myPage;

        /// <summary>
        /// Page with permissions manager.
        /// </summary>
        private PermissionsPage permPage;

        /// <summary>
        /// Page with all users in system.
        /// </summary>
        private UsersPage usersPage;

        /// <summary>
        /// Flag, whether my page menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool myPageCheck;

        /// <summary>
        /// Flag, whether permissions menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool permCheck;

        /// <summary>
        /// Flag, whether users menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool usersCheck;

        /// <summary>
        /// Visibility of wait window.
        /// </summary>
        [ObservableProperty]
        private Visibility waitVisibility;

        /// <summary>
        /// Creates new handler of master window.
        /// </summary>
        public MasterWindowViewModel() : base()
        {
            this.user = null;
            this.role = null;
            WeakReferenceMessenger.Default.Register<LoggedUserChangedMessage>(this, (sender, args) =>
            {
                this.UserChanged(args.Value);
            });
            WeakReferenceMessenger.Default.Register<LoggedRoleChangedMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
            this.image = UserImage.Default.ToImage();
            this.waitVisibility = Visibility.Visible;
            this.myPageCheck = false;
            this.permCheck = false;
            this.usersCheck = false;
            this.myPage = new MyPage();
            this.permPage = new PermissionsPage();
            this.usersPage = new UsersPage();
        }

        /// <summary>
        /// Handles change of logged user.
        /// </summary>
        /// <param name="user">New logged user.</param>
        private async void UserChanged(User user)
        {
            this.WaitVisibility = Visibility.Visible;
            this.ChangeRoleVisibility = Visibility.Collapsed;
            this.user = user;
            this.Image = this.user.Image.ToImage();
            this.Name = this.user.Employee.PersonalData.Name + " " + this.user.Employee.PersonalData.Surname;
            bool canChangeRole = await this.CanChangeRoleAsync();
            if (canChangeRole == true)
            {
                this.ChangeRoleVisibility = Visibility.Visible;
            }
            WeakReferenceMessenger.Default.Send<InfoUserMessage>(new InfoUserMessage(user));
            this.WaitVisibility = Visibility.Collapsed;
        }
        
        /// <summary>
        /// Handles change of role of user.
        /// </summary>
        /// <param name="role">New role of user.</param>
        private void RoleChanged(Role role)
        {
            this.WaitVisibility = Visibility.Visible;
            this.role = role;
            this.DisplayRole = role.Name;
            this.RoleMenu();
            WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(role));
            this.WaitVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Displays menu items according to the actual role.
        /// </summary>
        private async void RoleMenu()
        {
            if (this.role != null)
            {
                this.WaitVisibility = Visibility.Visible;
                this.RolesVisibility = (await this.role.HasPermissionAsync(PermissionNames.RolesRead) ? Visibility.Visible : Visibility.Collapsed);
                this.UsersVisibility = (await this.role.HasPermissionAsync(PermissionNames.UsersRead) ? Visibility.Visible : Visibility.Collapsed);

                this.ResetChecks();


                this.MyPage();
                this.WaitVisibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Handles procedure after window has been loaded.
        /// </summary>
        [RelayCommand]
        private void WindowLoaded()
        {
            WindowUtils.MinimizeForModel(this);
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
            if (this.user == null)
            {
                App.Current.Shutdown();
            }
            else
            {
                WindowUtils.MaximizeForModel(this);
                if (this.user != null)
                {
                    WeakReferenceMessenger.Default.Send<InfoUserMessage>(new InfoUserMessage(this.user));
                }
                if (this.role != null)
                {
                    WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
                    this.RoleMenu();
                }
                
            }
        }

        /// <summary>
        /// Handles logout of user.
        /// </summary>
        [RelayCommand]
        private void Logout()
        {
            MainWindow main = new MainWindow();
            main.Show();
            WindowUtils.HideForModel(this);
        }

        /// <summary>
        /// Checks, whether user can change role.
        /// </summary>
        /// <returns>TRUE if user can change role, FALSE otherwise.</returns>
        private bool CanChangeRole()
        {
            bool reti = false;
            if (this.user != null)
            {
                if (user.Role.HasPermission(Model.Enums.PermissionNames.RoleModifyRuntime))
                {
                    reti = true;
                }
            }
            return reti;
        }

        /// <summary>
        /// Checks, whether user can change role asynchronously.
        /// </summary>
        /// <returns>Task which resolves into TRUE if user can change role, FALSE otherwise.</returns>
        private Task<bool> CanChangeRoleAsync()
        {
            return Task<bool>.Run(() =>
            {
                return this.CanChangeRole();
            });
        }

        /// <summary>
        /// Handles change of role.
        /// </summary>
        [RelayCommand]
        private void ChangeRole()
        {
            WeakReferenceMessenger.Default.Register<SelectedRoleChangedMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
            RoleSelectionWindow roleSelection = new RoleSelectionWindow();
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
                this.RoleMenu();
            }
            roleSelection.ShowDialog();
            WeakReferenceMessenger.Default.Unregister<SelectedRoleChangedMessage>(this);
        }

        /// <summary>
        /// Resets all checks from menu items.
        /// </summary>
        private void ResetChecks()
        {
            this.MyPageCheck = false;
            this.PermCheck = false;
        }

        /// <summary>
        /// Handles click on 'my page' menu item.
        /// </summary>
        [RelayCommand]
        private void MyPage()
        {
            this.ResetChecks();
            this.MyPageCheck = true;
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
            }
            this.Navigate(this.myPage);
        }

        /// <summary>
        /// Handles click on 'permissions' menu item.
        /// </summary>
        [RelayCommand]
        private void Permission()
        {
            this.ResetChecks();
            this.PermCheck = true;
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
            }
            this.Navigate(this.permPage);
        }

        /// <summary>
        /// Handles click on 'users' menu item.
        /// </summary>
        [RelayCommand]
        private void Users()
        {
            this.ResetChecks();
            this.UsersCheck = true;
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
            }
            this.Navigate(this.usersPage);
        }
    }
}
