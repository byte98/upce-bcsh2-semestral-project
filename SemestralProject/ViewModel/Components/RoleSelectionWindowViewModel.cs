using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// Class which handles roles selection window.
    /// </summary>
    public partial class RoleSelectionWindowViewModel : ObservableObject
    {
        /// <summary>
        /// List of available roles.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Role> rolesItemsSource = new ObservableCollection<Role>();

        /// <summary>
        /// Visibility of main content of window.
        /// </summary>
        [ObservableProperty]
        private Visibility contentVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of loader.
        /// </summary>
        [ObservableProperty]
        private Visibility loaderVisibility = Visibility.Visible;

        /// <summary>
        /// Actually selected role.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        private Role? selectedRole = null;

        /// <summary>
        /// Actual search phrase.
        /// </summary>
        [ObservableProperty]
        private string searchPhrase = string.Empty;

        /// <summary>
        /// List with all available roles.
        /// </summary>
        private IList<Role> roles = new List<Role>();

        /// <summary>
        /// Creates new model view for role selection window.
        /// </summary>
        public RoleSelectionWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<InfoRoleMessage>(this, (sender, args) =>
            {
                this.SelectedRole = args.Value;
            });
        }

        /// <summary>
        /// Handles loading of all data after window is loaded.
        /// </summary>
        [RelayCommand]
        private async Task WindowLoaded()
        {
            this.RolesItemsSource.Clear();
            Role[] roles = await Role.GetAllAsync();
            foreach (Role role in roles)
            {
                this.RolesItemsSource.Add(role);
                this.roles.Add(role);
            }
            this.LoaderVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles search of role.
        /// </summary>
        [RelayCommand]
        private void Search()
        {
            this.RolesItemsSource.Clear();
            if (this.SearchPhrase == null || this.SearchPhrase.Length == 0)
            {
                foreach(Role role in this.roles)
                {
                    this.RolesItemsSource.Add(role);
                }
            }
            else
            {
                foreach(Role role in this.roles)
                {
                    if (role.Name.ToLower().Trim().Contains(this.SearchPhrase.ToLower().Trim()))
                    {
                        this.RolesItemsSource.Add(role);
                    }
                }
            }
        }

        /// <summary>
        /// Handles click on cancel button.
        /// </summary>
        [RelayCommand]
        private void Cancel()
        {
            WindowUtils.CloseForModel(this);
        }

        /// <summary>
        /// Checks, whether user can click on OK button.
        /// </summary>
        /// <returns>TRUE if user can click on OK button, FALSE otherwise.</returns>
        private bool CanOK() => this.SelectedRole != null;

        /// <summary>
        /// Handles click on OK button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(CanOK))]
        public void OK()
        {
            if (this.SelectedRole != null)
            {
                WeakReferenceMessenger.Default.Send<SelectedRoleChangedMessage>(new SelectedRoleChangedMessage(this.SelectedRole));
                WindowUtils.CloseForModel(this);
            }
        }
    }
}
