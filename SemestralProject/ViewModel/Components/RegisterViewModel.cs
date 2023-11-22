using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// Class which handles behaviour of registration form.
    /// </summary>
    [ObservableObject]
    public partial class RegisterViewModel: NavigationSource
    {
        /// <summary>
        /// Handles click on 'register' button.
        /// </summary>
        [RelayCommand]
        public void Register()
        {

        }

        /// <summary>
        /// Handles click on 'login' button.
        /// </summary>
        [RelayCommand]
        public void Login()
        {
            this.NavigateBack();
        }
    }
}
