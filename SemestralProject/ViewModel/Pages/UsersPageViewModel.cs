using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.AsynchronousMethod;
using SemestralProject.Model.Entities;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Pages
{
    /// <summary>
    /// Class which handles behaviour of users page.
    /// </summary>
    public partial class UsersPageViewModel: ObservableObject
    {
        /// <summary>
        /// Visibility of waiting ring.
        /// </summary>
        [ObservableProperty]
        private Visibility waitVisibility;

        /// <summary>
        /// Visibility of content.
        /// </summary>
        [ObservableProperty]
        private Visibility contentVisibility;

        /// <summary>
        /// Visibility of editing controls.
        /// </summary>
        [ObservableProperty]
        private Visibility editVisibility;

        /// <summary>
        /// Collection of all available user states.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<State> states;

        /// <summary>
        /// Collection of all available user roles.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Role> roles;

        /// <summary>
        /// Actually selected role.
        /// </summary>
        [ObservableProperty]
        private Role? selectedRole;

        /// <summary>
        /// Actually selected state.
        /// </summary>
        [ObservableProperty]
        private State? selectedState;

        /// <summary>
        /// Collection of all available users.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<User> users;

        /// <summary>
        /// Actually selected user.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeRoleCommand))]
        [NotifyCanExecuteChangedFor(nameof(ChangeStateCommand))]
        private User? selectedUser;

        /// <summary>
        /// Flag, whether user has permission to edit users.
        /// </summary>
        private bool canEdit;

        /// <summary>
        /// Creates new handler of users page.
        /// </summary>
        public UsersPageViewModel()
        {
            this.waitVisibility = Visibility.Visible;
            this.contentVisibility = Visibility.Hidden;
            this.editVisibility = Visibility.Hidden;
            this.canEdit = false;
            this.states = new ObservableCollection<State>();
            this.roles = new ObservableCollection<Role>();
            this.users = new ObservableCollection<User>();
            WeakReferenceMessenger.Default.Register<RolesChangedMessage>(this, (sender, args) =>
            {
                this.Load();
            });
            WeakReferenceMessenger.Default.Register<InfoRoleMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
            WeakReferenceMessenger.Default.Register<LoggedRoleChangedMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
        }

        /// <summary>
        /// Handles change of role of user.
        /// </summary>
        /// <param name="role">New role of actually logged user.</param>
        private async void RoleChanged(Role role)
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.EditVisibility = Visibility.Collapsed;
            this.canEdit = await role.HasPermissionAsync(Model.Enums.PermissionNames.UsersModify);
            if (this.canEdit)
            {
                this.EditVisibility = Visibility.Visible;
            }

            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Loads content of page.
        /// </summary>
        private async void Load()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;

            this.States.Clear();
            State[] loadedStates = await State.GetAllAsync();
            foreach(State s in loadedStates)
            {
                this.States.Add(s);
            }

            this.Roles.Clear();
            Role[] loadedRoles = await Role.GetAllAsync();
            foreach(Role r in loadedRoles)
            {
                this.Roles.Add(r);
            }

            this.Users.Clear();
            User[] loadedUsers = await User.GetAllAsync();
            foreach(User u in loadedUsers)
            {
                this.Users.Add(u);
            }

            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles loading of page.
        /// </summary>
        [RelayCommand]
        private void PageLoaded()
        {
            this.Load();
        }

        /// <summary>
        /// Handles change of selected user
        /// </summary>
        [RelayCommand]
        private void SelectedUserChanged()
        {
            if (this.SelectedUser != null)
            {
                this.SelectedRole = this.SelectedUser.Role;
                this.SelectedState = this.SelectedUser.State;
            }
        }

        /// <summary>
        /// Checks, whether any user is selected.
        /// </summary>
        /// <returns>TRUE if any user is selected, FALSE otherwise.</returns>
        private bool IsSelected() => this.SelectedUser != null;

        /// <summary>
        /// Handles change of role.
        /// </summary>
        [RelayCommand(CanExecute =nameof(IsSelected))]
        private async Task ChangeRole()
        {
            if (this.SelectedUser != null && this.SelectedRole != null)
            {
                this.WaitVisibility = Visibility.Visible;
                this.ContentVisibility = Visibility.Collapsed;
                this.SelectedUser.Role = this.SelectedRole;
                await this.SelectedUser.UpdateAsync();
                this.Load();
            }
        }

        /// <summary>
        /// Handles change of state.
        /// </summary>
        [RelayCommand(CanExecute =nameof(IsSelected))]
        private async Task ChangeState()
        {
            if (this.SelectedUser != null && this.SelectedState != null)
            {
                this.WaitVisibility = Visibility.Visible;
                this.ContentVisibility = Visibility.Collapsed;
                this.SelectedUser.State = this.SelectedState;
                await this.SelectedUser.UpdateAsync();
                this.Load();
            }
        }
    }
}
