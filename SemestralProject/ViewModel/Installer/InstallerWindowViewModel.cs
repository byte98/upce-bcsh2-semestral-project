using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.View;
using SemestralProject.View.Installer;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Installer
{
    /// <summary>
    /// Class which handles behaviour of installer window.
    /// </summary>
    public partial class InstallerWindowViewModel : ObservableObject
    {

        /// <summary>
        /// Handles procedures needed to be done after window is loaded.
        /// </summary>
        [RelayCommand]
        private void WindowLoaded()
        {
            if (InstallerWindow.ContentFrame != null)
            {
                Navigator navigator = Navigator.Instance;
                navigator.Context = InstallerWindow.ContentFrame;
            }
        }

        /// <summary>
        /// Handles procedures needde to be done when window is closing.
        /// </summary>
        [RelayCommand]
        private void WindowClosing()
        {
            Navigator navigator = Navigator.Instance;
            navigator.SetPreviousContext();
        }
    }
}
