using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.View.Components;
using SemestralProject.View.Installer;
using SemestralProject.View.Installer.Truncate;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Installer.Truncate
{
    /// <summary>
    /// Class which handles process of truncate (aka. data deletion)
    /// </summary>
    [ObservableObject]
    public partial class TruncateProcessViewModel: DynamicElement<object?>
    {
        /// <summary>
        /// Class which handles initialization of data deletion process.
        /// </summary>
        private class TruncateProcessInitializer : DynamicContent<object?>
        {
            /// <summary>
            /// Starts data deletion process.
            /// </summary>
            public void Start()
            {
                this.ChangeContent(new TruncateStep1());
            }
        }

        /// <summary>
        /// Instance of data deletion process model view.
        /// </summary>
        public static TruncateProcessViewModel? Instance { get; private set; }

        /// <summary>
        /// Handles view loaded event.
        /// </summary>
        [RelayCommand]
        private void ViewLoaded()
        {
            object? view = ViewModelLocator.GetViewToModel(this);
            if (view != null && view.GetType() == typeof(TruncateProcess))
            {
                TruncateProcess tp = (TruncateProcess)view;
                this.Initialize(tp.ContentControl);
            }
            TruncateProcessViewModel.Instance = this;
            TruncateProcessInitializer initializer = new TruncateProcessInitializer();
            this.RegisterDynamicSource(initializer);
            initializer.Start();
        }
    }
}
