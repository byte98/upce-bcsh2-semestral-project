using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.ViewModel.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace SemestralProject.ViewModel.Pages
{

    /// <summary>
    /// Class which handles behaviour of Vehicle page.
    /// </summary>
    public partial class VehiclesPageViewModel : AbstractPageViewModel
    {
         /// <summary>
         /// Collection of all vehicles.
         /// </summary>
         [ObservableProperty]
         private ObservableCollection<Vehicle> vehicles;

        /// <summary>
        /// Actually selected vehicle.
        /// </summary>
        [ObservableProperty]
        private Vehicle? selectedVehicle;

        /// <summary>
        /// Evidence number of the new vehicle
        /// </summary>
        [ObservableProperty]
        private string vehicleEvidenceNumber = string.Empty;

        /// <summary>
        /// Type of the new vehicle
        /// </summary>
        [ObservableProperty]
        private string vehicleType = string.Empty;

        /// <summary>
        /// List with all available types.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> availableTypes = new ObservableCollection<string> {
            "TRM",
            "BUS",
            "MTR"
        };


        /// <summary>
        /// Creates new view model for vehicles page.
        /// </summary>
        public VehiclesPageViewModel() : base(PermissionNames.ShiftsModify)
        {
            this.vehicles = new ObservableCollection<Vehicle>();
            WeakReferenceMessenger.Default.Register<VehiclesChangedMessage>(this, async (sender, args) =>
            {
                    this.WaitVisibility = Visibility.Visible;
                    this.ContentVisibility = Visibility.Collapsed;
                    this.Vehicles.Clear();
                    Vehicle[] loaded = await Vehicle.GetAllAsync();
                    foreach (Vehicle v in loaded) this.Vehicles.Add(v);
                    this.WaitVisibility = Visibility.Collapsed;
                    this.ContentVisibility = Visibility.Visible;
            });
        }

        /// <summary>
        /// Handles loading of page.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.Vehicles.Clear();
            Vehicle[] loaded = await Vehicle.GetAllAsync();
            foreach (Vehicle v in loaded) this.Vehicles.Add(v);
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles click on new button.
        /// </summary>
        [RelayCommand]
        private async Task New()
        {
            await Vehicle.CreateAsync(this.VehicleEvidenceNumber, this.VehicleType);
            WeakReferenceMessenger.Default.Send<VehiclesChangedMessage>(new VehiclesChangedMessage());
        }

        /// <summary>
        /// Handles click on remove button.
        /// </summary>
        [RelayCommand]
        private async Task Remove()
        {
            if (this.SelectedVehicle != null)
            {
                await this.SelectedVehicle.DeleteAsync();
                WeakReferenceMessenger.Default.Send<VehiclesChangedMessage>(new VehiclesChangedMessage());
            }
        }
    }
}
