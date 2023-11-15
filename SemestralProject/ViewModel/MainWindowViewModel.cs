using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.View;
using SemestralProject.View.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel
{
    /// <summary>
    /// Class which handles behaviour of main window.
    /// </summary>
    public partial class MainWindowViewModel: ObservableObject
    {
        /// <summary>
        /// Actual version of program.
        /// </summary>
        [ObservableProperty]
        private string version = Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version?.ToString();

        /// <summary>
        /// Handles click on 'installation' hyperlink.
        /// </summary>
        [RelayCommand]
        private void HyperlinkInstallationClicked()
        {
            InstallerWindow installerWindow = new InstallerWindow();
            installerWindow.ShowDialog();
        }

    }
}
