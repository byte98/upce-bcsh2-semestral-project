using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Installer.Truncate
{
    /// <summary>
    /// Class which handles first step of deletion of data.
    /// </summary>
    [ObservableObject]
    public partial class TruncateStep1ViewModel : NavigationDynamicContent<object?>
    {

        /// <summary>
        /// Handles click on back button.
        /// </summary>
        [RelayCommand]
        private void BackClicked()
        {
            this.NavigateBack();
        }

        /// <summary>
        /// Handles load of control.
        /// </summary>
        [RelayCommand]
        private void ControlLoaded()
        {
            TruncateProcessViewModel? tpvm = TruncateProcessViewModel.Instance;
            if (tpvm != null)
            {
                tpvm.RegisterDynamicSource(this);
            }
        }

        /// <summary>
        /// Handles click on 'yes' button.
        /// </summary>
        [RelayCommand]
        private void Yes()
        {

        }

        /// <summary>
        /// Handles click on 'no' button.
        /// </summary>
        [RelayCommand]
        private void No()
        {
            this.NavigateBack();
        }
    }
}
