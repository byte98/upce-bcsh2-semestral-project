using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
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
    /// View model for address selector window.
    /// </summary>
    public partial class AddressSelectorWindowViewModel: ObservableObject
    {

        /// <summary>
        /// Street part of address.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        private string? street;

        /// <summary>
        /// Number of house.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        private int? houseNumber;

        /// <summary>
        /// Orientation number of house.
        /// </summary>
        [ObservableProperty]
        private int? orientationNumber;

        /// <summary>
        /// Municipality in which is address located.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OKCommand))]
        private Municipality? municipality;

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
        /// Creates new view model for address selector window.
        /// </summary>
        public AddressSelectorWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<SelectedMunicipalityChangedMessage>(this, (sender, message) =>
            {
                this.Municipality = message.Value;
            });
            this.ButtonTextVisibility = Visibility.Visible;
            this.SavingProgressVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles click on 'OK' button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(CanConfirm))]
        private async Task OK()
        {
            this.ButtonTextVisibility = Visibility.Collapsed;
            this.SavingProgressVisibility = Visibility.Visible;
            Address? address = null;
            if (this.Municipality != null && this.HouseNumber != null)
            {
                if (this.OrientationNumber != null && this.Street != null)
                {
                    address = await Address.CreateAsync(this.Street, (int)this.HouseNumber, (int)this.OrientationNumber, this.Municipality);
                }
                else if (this.OrientationNumber != null && this.Street == null)
                {
                    address = await Address.CreateAsync((int)this.HouseNumber, (int)this.OrientationNumber, this.Municipality);
                }
                else if (this.OrientationNumber == null && this.Street != null)
                {
                    address = await Address.CreateAsync(this.Street, (int)this.HouseNumber, this.Municipality);
                }
                else if (this.OrientationNumber == null && this.Street == null)
                {
                    address = await Address.CreateAsync((int)this.HouseNumber, this.Municipality);
                }
            }
            this.ButtonTextVisibility = Visibility.Visible;
            this.SavingProgressVisibility = Visibility.Collapsed;
            if (address != null)
            {
                WeakReferenceMessenger.Default.Send<AddressesChangedMessage>(new AddressesChangedMessage());
                WeakReferenceMessenger.Default.Send<SelectedAddressChangedMessage>(new SelectedAddressChangedMessage(address));
                WindowUtils.CloseForModel(this);
            }
        }

        /// <summary>
        /// Handles click on 'cancel' button.
        /// </summary>
        [RelayCommand]
        private void Cancel()
        {
            WindowUtils.CloseForModel(this);
        }

        /// <summary>
        /// Checks, whether entered data can be confirmed and sent to the database.
        /// </summary>
        /// <returns>
        /// TRUE if entered data can be confirmed and sent to the database, FALSE otherwise.
        /// </returns>
        private bool CanConfirm()
        {
            bool reti = false;
            if (this.Municipality != null && this.HouseNumber != null)
            {
                reti = true;
            }
            return reti;
        }
    }
}
