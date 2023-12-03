using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.View.Components;
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
    /// Class which handles behaviour of permissions page.
    /// </summary>
    public partial class PermissionsPageViewModel: ObservableObject
    {
        /// <summary>
        /// Flag, whether details panel is visible.
        /// </summary>
        [ObservableProperty]
        private bool detailsVisible;

        /// <summary>
        /// Visibility of loader progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility loaderVisibility;

        /// <summary>
        /// Visibility of main content of the window.
        /// </summary>
        [ObservableProperty]
        private Visibility contentVisibility;

        /// <summary>
        /// Visibility of waiting modal.
        /// </summary>
        [ObservableProperty]
        private Visibility waitVisibility;

        /// <summary>
        /// Collection of all available roles.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Role> allRoles;

        /// <summary>
        /// Actually selected role.
        /// </summary>
        [ObservableProperty]
        private Role? selectedRole;

        /// <summary>
        /// Collection of permissions of selected role.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Permission> selectedPermissions;

        /// <summary>
        /// Creates new handler of permissions page.
        /// </summary>
        public PermissionsPageViewModel()
        {
            this.detailsVisible = true;
            this.loaderVisibility = Visibility.Visible;
            this.contentVisibility = Visibility.Collapsed;
            this.waitVisibility = Visibility.Collapsed;
            this.allRoles = new ObservableCollection<Role>();
            this.selectedPermissions = new ObservableCollection<Permission>();
            this.AllRoles.Clear();
        }

        /// <summary>
        /// Handles loading procedure after page is loaded.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.AllRoles.Clear();
            this.LoaderVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.AllRoles.Clear();
            Role[] loadedRoles = await Role.GetAllAsync();
            IList<Task> loadingTasks = new List<Task>();
            foreach (Role r in loadedRoles)
            {
                loadingTasks.Add(r.LoadPermissionsAsync());
            }
            await Task.WhenAll(loadingTasks);
            foreach (Role r in loadedRoles)
            {
                this.AllRoles.Add(r);
            }
            this.LoaderVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles change of selected role.
        /// </summary>
        [RelayCommand]
        private async Task SelectedRoleChanged()
        {
            this.SelectedPermissions.Clear();
            if (this.SelectedRole != null)
            {
                await this.SelectedRole.LoadPermissionsAsync();
                foreach(Permission p in this.SelectedRole.GetPermissions())
                {
                    this.SelectedPermissions.Add(p);
                }
            }
        }

        /// <summary>
        /// Handles click on change permissiohns button.
        /// </summary>
        [RelayCommand]
        private void ChangePermissions()
        {
            if (this.SelectedRole != null)
            {
                PermissionSelectorWindow window = new PermissionSelectorWindow();
                WeakReferenceMessenger.Default.Send<SelectedPermissionsChangedMessage>(new SelectedPermissionsChangedMessage(this.SelectedPermissions));
                WeakReferenceMessenger.Default.Register<SelectedPermissionsChangedMessage>(this, async (sender, args) =>
                {
                    this.ContentVisibility = Visibility.Collapsed;
                    this.WaitVisibility = Visibility.Visible;
                    this.SelectedPermissions.Clear();
                    foreach(Permission perm in args.Value)
                    {
                        this.SelectedPermissions.Add(perm);
                    }
                    await Task.Run(async () =>
                    {
                        Rights[] rights = await Rights.GetByRoleAsync(this.SelectedRole);
                        IList<Task> tasks = new List<Task>();
                        foreach(Rights r in rights)
                        {
                            tasks.Add(r.DeleteAsync());
                        }
                        await Task.WhenAll(tasks);
                        tasks.Clear();
                        foreach(Permission perm in args.Value)
                        {
                            tasks.Add(Rights.CreateAsync(this.SelectedRole, perm));
                        }
                        await Task.WhenAll();
                    });
                    this.ContentVisibility = Visibility.Visible;
                    this.WaitVisibility = Visibility.Collapsed;
                });
                window.ShowDialog();
                WeakReferenceMessenger.Default.Unregister<SelectedPermissionsChangedMessage>(this);
            }
            
        }
    }
}
