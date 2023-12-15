using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model;
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
        /// Visibility of editing controls.
        /// </summary>
        [ObservableProperty]
        private Visibility editVisibility;

        /// <summary>
        /// Flag, whether name of role should be read only.
        /// </summary>
        [ObservableProperty]
        private bool nameReadOnly;

        /// <summary>
        /// Collection of all available roles.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Role> allRoles;

        /// <summary>
        /// Collection of displayed data.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<PermissionsView> viewData;

        /// <summary>
        /// Actually selected role.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteRoleCommand))]
        private Role? selectedRole;

        /// <summary>
        /// Actually selected data
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteRoleCommand))]
        private PermissionsView? selectedData;

        /// <summary>
        /// Name of selected role.
        /// </summary>
        [ObservableProperty]
        private string selectedRoleName;

        /// <summary>
        /// Collection of permissions of selected role.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Permission> selectedPermissions;

        /// <summary>
        /// Name of new role.
        /// </summary>
        [ObservableProperty]
        private string newRoleName;

        /// <summary>
        /// Flag, whether user can edit data.
        /// </summary>
        private bool canEdit;

        /// <summary>
        /// Creates new handler of permissions page.
        /// </summary>
        public PermissionsPageViewModel()
        {
            this.detailsVisible = false;
            this.loaderVisibility = Visibility.Visible;
            this.contentVisibility = Visibility.Collapsed;
            this.waitVisibility = Visibility.Collapsed;
            this.editVisibility = Visibility.Collapsed;
            this.newRoleName = string.Empty;
            this.nameReadOnly = true;
            this.selectedRoleName = string.Empty;
            this.allRoles = new ObservableCollection<Role>();
            this.viewData = new ObservableCollection<PermissionsView>();
            this.selectedPermissions = new ObservableCollection<Permission>();
            this.AllRoles.Clear();
            WeakReferenceMessenger.Default.Register<RolesChangedMessage>(this, (sender, args) =>
            {
                this.Reload();
            });
            WeakReferenceMessenger.Default.Register<LoggedRoleChangedMessage>(this, (sender, args) =>
            {
                this.UserRoleChanged(args.Value);
            });
        }

        /// <summary>
        /// Handles change of user role.
        /// </summary>
        /// <param name="role"></param>
        private void UserRoleChanged(Role role)
        {
            this.EditVisibility = Visibility.Collapsed;
            this.NameReadOnly = true;
            this.canEdit = role.HasPermission(Model.Enums.PermissionNames.RolesModify);
            if (this.canEdit)
            {
                this.EditVisibility = Visibility.Visible;
                this.NameReadOnly = false;
            }
        }

        /// <summary>
        /// Reloads content of page.
        /// </summary>
        private async void Reload()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.ViewData.Clear();
            IConnection conn = await OracleConnector.LoadAsync();
            IDictionary<string, object?>[] results = await conn.QueryAsync("SELECT * FROM VW_ROLE_OPRAVNENI_COUNT");
            foreach (IDictionary<string, object?> row in results)
            {
                int? id = (int?)row["role"];
                int? count = (int?)row["opravneni"];
                Role? role = null;
                if (id != null)
                {
                    await conn.ExecuteAsync("COMMIT");
                    role = await Role.GetByIdAsync((int)id);
                }
                if (role != null && count != null)
                {
                    this.ViewData.Add(new PermissionsView(role, (int)count));
                }
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles loading procedure after page is loaded.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.ViewData.Clear();
            IConnection conn = await OracleConnector.LoadAsync();
            IDictionary<string, object?>[] results = await conn.QueryAsync("SELECT * FROM VW_ROLE_OPRAVNENI_COUNT");
            foreach (IDictionary<string, object?> row in results)
            {
                int? id = (int?)row["role"];
                int? count = (int?)row["opravneni"];
                Role? role = null;
                if (id != null)
                {
                    await conn.ExecuteAsync("COMMIT");
                    role = await Role.GetByIdAsync((int)id);
                }
                if (role != null && count != null)
                {
                    this.ViewData.Add(new PermissionsView(role, (int)count));
                }
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles change of selected role.
        /// </summary>
        [RelayCommand]
        private async Task SelectedRoleChanged()
        {
            this.SelectedPermissions.Clear();
            if (this.SelectedData != null)
            {
                this.SelectedRole = this.SelectedData.Role;
                if (this.SelectedRole != null)
                {
                    this.SelectedRoleName = this.SelectedRole.Name;
                    if (this.SelectedRole != null)
                    {
                        await this.SelectedRole.LoadPermissionsAsync();
                        if (this.SelectedRole != null)
                        {
                            foreach (Permission p in this.SelectedRole.GetPermissions())
                            {
                                this.SelectedPermissions.Add(p);
                            }
                        }
                    }
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
                        IList<Task> tasks2 = new List<Task>();
                        foreach (Permission perm in args.Value)
                        {
                            tasks2.Add(Rights.CreateAsync(this.SelectedRole, perm));
                        }
                        await Task.WhenAll(tasks2);
                    });
                    this.ContentVisibility = Visibility.Visible;
                    this.WaitVisibility = Visibility.Collapsed;
                    this.Reload();
                });
                window.ShowDialog();
                WeakReferenceMessenger.Default.Unregister<SelectedPermissionsChangedMessage>(this);
            }
        }

        /// <summary>
        /// Handles click on save name button.
        /// </summary>
        [RelayCommand]
        private async Task SaveName()
        {
            this.ContentVisibility = Visibility.Collapsed;
            this.WaitVisibility = Visibility.Visible;
            if (this.SelectedRole != null)
            {
                this.SelectedRole.Name = this.SelectedRoleName;
                await this.SelectedRole.UpdateAsync();
            }
            this.Reload();
        }

        /// <summary>
        /// Handles click on adding new role.
        /// </summary>
        [RelayCommand]
        private async Task NewRole()
        {
            if (this.NewRoleName.Length > 0)
            {
                this.ContentVisibility = Visibility.Collapsed;
                this.WaitVisibility = Visibility.Visible;
                await Role.CreateAsync(this.NewRoleName);
                this.Reload();
                this.NewRoleName = string.Empty;
            }
        }

        /// <summary>
        /// Checks, whether selected role is NOT NULL.
        /// </summary>
        /// <returns>TRUE if selected role is NOT NULL, FALSE otherwise.</returns>
        private bool SelectedNonNull() => this.SelectedRole != null;

        /// <summary>
        /// Handles click on delete role.
        /// </summary>
        /// <returns></returns>
        [RelayCommand(CanExecute =nameof(SelectedNonNull))]
        private async Task DeleteRole()
        {
            if (this.SelectedRole != null)
            {
                this.ContentVisibility = Visibility.Collapsed;
                this.WaitVisibility = Visibility.Visible;
                await this.SelectedRole.DeleteAsync();
                this.SelectedRole = null;
                this.Reload();
            }
        }
    }
}
