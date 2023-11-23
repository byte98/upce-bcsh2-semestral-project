using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View.Components;
using SemestralProject.ViewModel.Messaging;
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
            WeakReferenceMessenger.Default.Register<AddressesChangedMessage>(this, (sender, args) =>
            {
                this.Load();
            });
            WeakReferenceMessenger.Default.Register<SelectedAddressChangedMessage>(this, (sender, args) =>
            {
                this.SelectedAddress = args.Value;
            });
        }

        /// <summary>
        /// Handles initialization process after control is loaded.
        /// </summary>
        [RelayCommand]
        private void ControlLoaded()
        {
            this.Load();
        }

        /// <summary>
        /// Loads all available addresses.
        /// </summary>
        private async void Load()
        {
            this.LoaderVisibility = Visibility.Visible;
            this.ComboBoxVisibility = Visibility.Collapsed;
            Address[] addresses = await Address.GetAllAsync();
            this.AvailableAddresses.Clear();
            foreach (Address address in addresses)
            {
                this.AvailableAddresses.Add(address);
            }
            this.SelectedAddress = ArrayUtils<Address>.Random(addresses);
            if (this.SelectedAddress != null)
            {
                WeakReferenceMessenger.Default.Send<SelectedAddressChangedMessage>(new SelectedAddressChangedMessage(this.SelectedAddress));
            }
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
