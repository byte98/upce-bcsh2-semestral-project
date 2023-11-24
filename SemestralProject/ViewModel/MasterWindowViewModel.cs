using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
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
        }

        /// <summary>
        /// Handles change of logged user.
        /// </summary>
        /// <param name="user">New logged user.</param>
        private async void UserChanged(User user)
        {
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
        }
        
        /// <summary>
        /// Handles change of role of user.
        /// </summary>
        /// <param name="role">New role of user.</param>
        private void RoleChanged(Role role)
        {
            this.role = role;
            this.DisplayRole = role.Name;

            WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(role));
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
                this.Navigate(new MyPage());
                if (this.user != null)
                {
                    WeakReferenceMessenger.Default.Send<InfoUserMessage>(new InfoUserMessage(this.user));
                }
                if (this.role != null)
                {
                    WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
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
                if (user.Role.HasPermission(Model.Enums.PermissionNames.ChangeRoleRuntime))
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
            roleSelection.ShowDialog();
            WeakReferenceMessenger.Default.Unregister<SelectedRoleChangedMessage>(this);
        }
    }
}
