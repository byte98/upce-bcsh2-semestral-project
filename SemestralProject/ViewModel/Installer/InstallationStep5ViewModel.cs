using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model;
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
    /// Class which represents view model of fifth step of installation process.
    /// </summary>
    public partial class InstallationStep5ViewModel: NavigationDynamicContent<InstallationModel>, IDynamicTarget<InstallationModel>
    {
        /// <summary>
        /// Data model of installation.
        /// </summary>
        private InstallationModel model;

        /// <summary>
        /// Creates new view model for fifth step of installation process.
        /// </summary>
        public InstallationStep5ViewModel()
        {
            if (InstallationProcessViewModel.Instance != null)
            {
                InstallationProcessViewModel.Instance.RegisterDynamicSource(this);
                InstallationProcessViewModel.Instance.RegisterTarget(this);
            }
        }

        public void SetData(InstallationModel data)
        {
            this.model = data;
        }

        /// <summary>
        /// Handles click on 'back' button.
        /// </summary>
        [RelayCommand]
        private void BackClicked()
        {
            this.NavigateBack();
        }

        /// <summary>
        /// Moves to the previous step of installation process.
        /// </summary>
        [RelayCommand]
        private void Previous()
        {
            this.ChangeContent(new InstallationStep3(), this.model);
        }
    }
}
