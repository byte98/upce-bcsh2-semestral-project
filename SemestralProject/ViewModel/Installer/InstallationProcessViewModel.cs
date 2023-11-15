using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.View.Components;
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
    /// Class which handles whole installation process.
    /// </summary>
    [ObservableObject]
    public partial class InstallationProcessViewModel: DynamicElement<InstallationModel>, IDynamicTarget<InstallationModel>
    {
        /// <summary>
        /// Class which handles initialization of installation process.
        /// </summary>
        private class InstallationProcessInitializer: DynamicContent<InstallationModel>
        {
            /// <summary>
            /// Model with all installation data.
            /// </summary>
            private readonly InstallationModel model;

            /// <summary>
            /// Creates new initializer of installation process.
            /// </summary>
            /// <param name="model">Model with all installation data.</param>
            public InstallationProcessInitializer(InstallationModel model)
            {
                this.model = model;
            }

            /// <summary>
            /// Starts installation process.
            /// </summary>
            public void Start()
            {
                this.ChangeContent(new InstallationStep1(), this.model);
            }
        }

        /// <summary>
        /// Instance of handler of whole installation process.
        /// </summary>
        public static InstallationProcessViewModel? Instance;

        /// <summary>
        /// Model containing all instalation data.
        /// </summary>
        private InstallationModel model;

        /// <summary>
        /// Creates new handler of whole installation process.
        /// </summary>
        public InstallationProcessViewModel()
        {
            this.model = new InstallationModel();
            
        }

        /// <summary>
        /// Handles view loaded event.
        /// </summary>
        [RelayCommand]
        private void ViewLoaded()
        {
            object? view = ViewModelLocator.GetViewToModel(this);
            if (view != null && view.GetType() == typeof(InstallationProcess))
            {
                InstallationProcess ip = (InstallationProcess)view;
                this.Initialize(ip.ContentControl);
            }
            InstallationProcessViewModel.Instance = this;
            InstallationProcessInitializer initializer = new InstallationProcessInitializer(this.model);
            this.RegisterDynamicSource(initializer);
            initializer.Start();
        }

        public void SetData(InstallationModel data)
        {
            this.model = data;
        }
    }
}
