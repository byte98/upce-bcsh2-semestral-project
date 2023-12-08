using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Pages
{
    /// <summary>
    /// Class which abstracts all page view models.
    /// </summary>
    public abstract partial class AbstractPageViewModel: ObservableObject
    {

        /// <summary>
        /// Name of permission which allows user to edit data.
        /// </summary>
        private readonly PermissionNames editPermission;

        /// <summary>
        /// Visibility of editing controls.
        /// </summary>
        [ObservableProperty]
        private Visibility editVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of waiting ring.
        /// </summary>
        [ObservableProperty]
        private Visibility waitVisibility = Visibility.Visible;

        /// <summary>
        /// Visibility of content.
        /// </summary>
        [ObservableProperty]
        private Visibility contentVisibility = Visibility.Collapsed;

        /// <summary>
        /// Flag, whether user has permission to edit data.
        /// </summary>
        private bool canEdit = false;

        /// <summary>
        /// Creates new model view for page.
        /// </summary>
        /// <param name="editName">Name of permission which allows user to edit data.</param>
        public AbstractPageViewModel(PermissionNames editName)
        {
            this.editPermission = editName;
            WeakReferenceMessenger.Default.Register<LoggedRoleChangedMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
        }

        /// <summary>
        /// Handles change of role.
        /// </summary>
        /// <param name="role">New role of user.</param>
        private async void RoleChanged(Role role)
        {
            this.EditVisibility = Visibility.Collapsed;
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;

            this.canEdit = await role.HasPermissionAsync(this.editPermission);
            if (this.canEdit)
            {
                this.EditVisibility = Visibility.Visible;
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

    }
}
