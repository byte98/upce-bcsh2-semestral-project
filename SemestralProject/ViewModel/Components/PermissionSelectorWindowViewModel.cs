using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// Class which handles behaviour of permission selector window.
    /// </summary>
    public partial class PermissionSelectorWindowViewModel: ObservableObject
    {
        /// <summary>
        /// List of all available permissions.
        /// </summary>
        private IList<Permission> permissions;

        /// <summary>
        /// List of selected permissions.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Permission> selectedPermissions;

        /// <summary>
        /// List of all available permissions which has not been selected.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Permission> availablePermissions;

        /// <summary>
        /// Actually selected, highlighted permission from selected ones.
        /// </summary>
        [ObservableProperty]
        private Permission? selectedPermission;

        /// <summary>
        /// Actually selected, highlighted permission from available ones.
        /// </summary>
        [ObservableProperty]
        private Permission? availablePermission;

        /// <summary>
        /// Visibility of progress loaders.
        /// </summary>
        [ObservableProperty]
        private Visibility loaderVisibility;

        /// <summary>
        /// Visibility of main content.
        /// </summary>
        [ObservableProperty]
        private Visibility contentVisibility;

        /// <summary>
        /// Visibility of edit controls.
        /// </summary>
        [ObservableProperty]
        private Visibility editVisibility;

        /// <summary>
        /// Creates new view model for permission selector window.
        /// </summary>
        public PermissionSelectorWindowViewModel()
        {
            this.selectedPermissions = new ObservableCollection<Permission>();
            this.availablePermissions = new ObservableCollection<Permission>();
            this.permissions = new List<Permission>();
            this.loaderVisibility = Visibility.Visible;
            this.contentVisibility = Visibility.Hidden;
            this.editVisibility = Visibility.Hidden;
            WeakReferenceMessenger.Default.Register<LoggedRoleChangedMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
            WeakReferenceMessenger.Default.Register<InfoRoleMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
            WeakReferenceMessenger.Default.Register<SelectedPermissionsChangedMessage>(this, (sender, args) =>
            {
                this.SelectedPermissions.Clear();
                foreach(Permission perm in args.Value)
                {
                    this.SelectedPermissions.Add(perm);
                }
            });
        }

        /// <summary>
        /// Handles change of role.
        /// </summary>
        /// <param name="role">Role which is currently actual.</param>
        private async void RoleChanged(Role role)
        {
            this.EditVisibility = Visibility.Collapsed;
            bool canEdit = await role.HasPermissionAsync(Model.Enums.PermissionNames.RolesModify);
            if (canEdit)
            {
                this.EditVisibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Handles loading of window.
        /// </summary>
        [RelayCommand]
        private async Task WindowLoaded()
        {
            this.LoaderVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.permissions = await Permission.GetAllAsync();
            foreach(Permission perm in this.permissions)
            {
                if (this.SelectedPermissions.Contains(perm) == false)
                {
                    this.AvailablePermissions.Add(perm);
                }
            }
            this.LoaderVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Adds all available permissions.
        /// </summary>
        [RelayCommand]
        private void AddAll()
        {
            foreach(Permission perm in this.AvailablePermissions)
            {
                this.SelectedPermissions.Add(perm);
            }
            this.AvailablePermissions.Clear();
        }

        /// <summary>
        /// Adds selected permission.
        /// </summary>
        [RelayCommand]
        private void Add()
        {
            if (this.AvailablePermission != null)
            {
                this.SelectedPermissions.Add(this.AvailablePermission);
                this.AvailablePermissions.Remove(this.AvailablePermission);
            }
        }

        /// <summary>
        /// Removes selected permission.
        /// </summary>
        [RelayCommand]
        private void Remove()
        {
            if (this.SelectedPermission != null)
            {
                this.AvailablePermissions.Add(this.SelectedPermission);
                this.SelectedPermissions.Remove(this.SelectedPermission);
            }
        }

        /// <summary>
        /// Removes all permissions.
        /// </summary>
        [RelayCommand]
        private void RemoveAll()
        {
            foreach(Permission perm in this.SelectedPermissions)
            {
                this.AvailablePermissions.Add(perm);
            }
            this.SelectedPermissions.Clear();
        }

        /// <summary>
        /// Handles click on OK button.
        /// </summary>
        [RelayCommand]
        private void OK()
        {
            WeakReferenceMessenger.Default.Send<SelectedPermissionsChangedMessage>(new SelectedPermissionsChangedMessage(this.SelectedPermissions));
            WindowUtils.CloseForModel(this);
        }

        /// <summary>
        /// Handles click on cancel button.
        /// </summary>
        [RelayCommand]
        private void Cancel()
        {
            WindowUtils.CloseForModel(this);
        }
    }
}
