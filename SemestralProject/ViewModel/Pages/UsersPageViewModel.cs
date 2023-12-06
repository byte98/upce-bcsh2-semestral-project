using CommunityToolkit.Mvvm.ComponentModel;
using SemestralProject.Model.Entities;
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
        /// Creates new handler of users page.
        /// </summary>
        public UsersPageViewModel()
        {
            this.waitVisibility = Visibility.Visible;
            this.contentVisibility = Visibility.Hidden;
            this.states = new ObservableCollection<State>();
            this.roles = new ObservableCollection<Role>();
        }
        
        /// <summary>
        /// Loads content of page.
        /// </summary>
        private void Load()
        {

        }
    }
}
