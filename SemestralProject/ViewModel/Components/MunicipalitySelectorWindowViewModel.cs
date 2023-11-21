using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View.Components;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// View model of municipality selector window.
    /// </summary>
    public partial class MunicipalitySelectorWindowViewModel: ObservableObject
    {
        /// <summary>
        /// Name of municipality.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        private string name;

        /// <summary>
        /// Name of part of municipality.
        /// </summary>
        [ObservableProperty]
        private string part;

        /// <summary>
        /// Zip code of municipality.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        private string zip;

        /// <summary>
        /// Country in which is municipality located.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        private Country? country;
        
        /// <summary>
        /// Visibility of text in 'OK' button.
        /// </summary>
        [ObservableProperty]
        private Visibility buttonTextVisibility;

        /// <summary>
        /// Visibility of progress ring in 'OK' button.
        /// </summary>
        [ObservableProperty]
        private Visibility savingProgressVisibility;

        /// <summary>
        /// Flag, whether buttons should be enabled.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        [NotifyCanExecuteChangedFor(nameof(CancelCommand))]
        private bool controlsEnabled;

        /// <summary>
        /// Creates new view model of municipality selector window.
        /// </summary>
        public MunicipalitySelectorWindowViewModel()
        {
            this.Name = string.Empty;
            this.part = string.Empty;
            this.zip = string.Empty;
            this.ButtonTextVisibility = Visibility.Visible;
            this.SavingProgressVisibility = Visibility.Collapsed;
            this.ControlsEnabled = true;
            WeakReferenceMessenger.Default.Register<SelectedCountryChangedMessage>(this, (sender, message) =>
            {
                this.Country = message.Value;
            });
        }

        /// <summary>
        /// Handles click on 'OK' button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(CanConfirm))]
        private async Task OK()
        {
            if (this.Country != null)
            {
                this.ControlsEnabled = false;
                this.ButtonTextVisibility = Visibility.Collapsed;
                this.SavingProgressVisibility = Visibility.Visible;
                Municipality municipality = await Municipality.CreateAsync(this.Name, (this.Part.Length == 0 ? null : this.Part), this.Zip, this.Country);
                WeakReferenceMessenger.Default.Send<MunicipalitiesChangedMessage>(new MunicipalitiesChangedMessage());
                WeakReferenceMessenger.Default.Send<SelectedMunicipalityChangedMessage>(new SelectedMunicipalityChangedMessage(municipality));
                WindowUtils.CloseForModel(this);
            }
            
        }

        /// <summary>
        /// Handles click on 'cancel' button.
        /// </summary>
        [RelayCommand(CanExecute = nameof(ButtonsEnabled))]
        private void Cancel()
        {
            WindowUtils.CloseForModel(this);
        }

        /// <summary>
        /// Checks, whether buttons should be enabled.
        /// </summary>
        /// <returns>
        /// TRUE, if buttons should be enabled,
        /// FALSE otherwise.
        /// </returns>
        private bool ButtonsEnabled() => this.ControlsEnabled;

        /// <summary>
        /// Checks, whether entered data can be confirmed and saved to the database.
        /// </summary>
        /// <returns>
        /// TRUE if data can be confirmed and saved to the database,
        /// FALSE otherwise.
        /// </returns>
        private bool CanConfirm()
        {
            bool nameLen = this.Name.Length > 0;
            bool countrySet = this.Country != null;
            bool zipLen = this.Zip.Length > 0;
            bool ctrls = this.ControlsEnabled;
            return nameLen == true && countrySet == true && zipLen == true && ctrls == true;
        }
    }
}
