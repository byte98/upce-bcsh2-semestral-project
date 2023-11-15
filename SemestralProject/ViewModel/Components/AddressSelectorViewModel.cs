using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// View model for address selector control.
    /// </summary>
    public partial class AddressSelectorViewModel: ObservableObject
    {
        /// <summary>
        /// Visibility of loading progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility loaderVisibility;

        /// <summary>
        /// Visibility of combo box.
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(FindAddressCommand))]
        private Visibility comboBoxVisibility;

        /// <summary>
        /// Collection with all available addresses.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Address> availableAddresses;

        /// <summary>
        /// Actually selected address.
        /// </summary>
        [ObservableProperty]
        private Address? selectedAddress;

        /// <summary>
        /// Creates new view model for address selector window.
        /// </summary>
        public AddressSelectorViewModel()
        {
            this.loaderVisibility = Visibility.Visible;
            this.comboBoxVisibility = Visibility.Collapsed;
            this.availableAddresses = new ObservableCollection<Address>();
        }

        /// <summary>
        /// Handles initialization process after control is loaded.
        /// </summary>
        [RelayCommand]
        private async Task ControlLoaded()
        {
            Address[] addresses = await Address.GetAllAsync();
            this.AvailableAddresses.Clear();
            foreach(Address address in addresses)
            {
                this.AvailableAddresses.Add(address);
            }
            this.SelectedAddress = ArrayUtils<Address>.Random(addresses);
            this.LoaderVisibility = Visibility.Collapsed;
            this.ComboBoxVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles finding address.
        /// </summary>
        [RelayCommand(CanExecute =nameof(FindAllowed))]
        private void FindAddress()
        {
            AddressSelectorWindow addressSelectorWindow = new AddressSelectorWindow();
            addressSelectorWindow.ShowDialog();
        }

        /// <summary>
        /// Checks, whether finding address is allowed.
        /// </summary>
        /// <returns>
        /// TRUE if finding address is allowed,
        /// FALSE otherwise.
        /// </returns>
        private bool FindAllowed() => this.ComboBoxVisibility == Visibility.Visible;
    }
}
