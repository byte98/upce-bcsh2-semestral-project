using CommunityToolkit.Mvvm.ComponentModel;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SemestralProject.Model.Enums;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.ViewModel.Messaging;


namespace SemestralProject.ViewModel.Pages
{

    /// <summary>
    /// Class which handles behaviour of shifts page.
    /// </summary>
    public partial class ShiftsPageViewModel : AbstractPageViewModel
    {
         /// <summary>
         /// Collection of all scheduled shifts.
         /// </summary>
         [ObservableProperty]
         private ObservableCollection<Shift> shifts;

        /// <summary>
        /// Actually selected stop.
        /// </summary>
        [ObservableProperty]
        private Shift? selectedShift;


        /// <summary>
        /// Collection of all available schedules.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Schedule> availableSchedules;

        /// <summary>
        /// Schedule For new shift
        /// </summary>
        [ObservableProperty]
        private Schedule schedule;


        /// <summary>
        /// Collection of all available employees.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Employee> availableEmployees;

        /// <summary>
        /// Employee For new shift
        /// </summary>
        [ObservableProperty]
        private Employee employee;

        /// <summary>
        /// Collection of all available vehicles.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Vehicle> availableVehicles;

        /// <summary>
        /// Vehicle for the new shift
        /// </summary>
        [ObservableProperty]
        private Vehicle vehicle;

        /// <summary>
        /// Creates new view model for stops page.
        /// </summary>
        public ShiftsPageViewModel() : base(PermissionNames.ShiftsModify)
        {
            this.shifts = new ObservableCollection<Shift>();
            this.availableVehicles = new ObservableCollection<Vehicle>();
            this.availableEmployees = new ObservableCollection<Employee>();
            this.availableSchedules = new ObservableCollection<Schedule>();
            WeakReferenceMessenger.Default.Register<ShiftsChangedMessage>(this, async (sender, args) =>
            {
                this.WaitVisibility = Visibility.Visible;
                this.ContentVisibility = Visibility.Collapsed;
                this.Shifts.Clear();

                // Unbearably slow loading for other entities, too many unnecessary
                // intermediate queries and abstractins

                Employee[] loadedEmployees = await Employee.GetAllAsync();
                foreach (Employee s in loadedEmployees)
                {
                    this.AvailableEmployees.Add(s);
                }

                Vehicle[] loadedVehicles = await Vehicle.GetAllAsync();
                foreach (Vehicle s in loadedVehicles)
                {
                    this.AvailableVehicles.Add(s);
                }

                Schedule[] loadedSchedules = await Schedule.GetAllAsync();
                foreach (Schedule s in loadedSchedules)
                {
                    this.AvailableSchedules.Add(s);
                }

                // this one is okay-ish
                Shift[] loaded = await Shift.GetAllAsync();
                foreach (Shift s in loaded)
                {
                    this.Shifts.Add(s);
                }
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
            this.Shifts.Clear();

            // Unbearably slow loading for other entities, too many unnecessary
            // intermediate queries and abstractins

            Employee[] loadedEmployees = await Employee.GetAllAsync();
            foreach (Employee s in loadedEmployees)
            {
                if (s != null) this.AvailableEmployees.Add(s);
            }

            Vehicle[] loadedVehicles = await Vehicle.GetAllAsync();
            foreach (Vehicle s in loadedVehicles)
            {
                if (s != null) this.AvailableVehicles.Add(s);
            }

            Schedule[] loadedSchedules = await Schedule.GetAllAsync();
            foreach (Schedule s in loadedSchedules)
            {
                if(s != null)
                    this.AvailableSchedules.Add(s);
            }

            Shift[] loaded = await Shift.GetAllAsync();
            foreach (Shift s in loaded)
            {
                this.Shifts.Add(s);
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles click on new button.
        /// </summary>
        [RelayCommand]
        private async Task New()
        {
            await Shift.CreateAsync(this.Vehicle, this.Employee, this.Schedule);
            WeakReferenceMessenger.Default.Send<ShiftsChangedMessage>(new ShiftsChangedMessage());
        }

        /// <summary>
        /// Handles click on remove button.
        /// </summary>
        [RelayCommand]
        private async Task Remove()
        {
            if (this.SelectedShift != null)
            {
                await this.SelectedShift.DeleteAsync();
                WeakReferenceMessenger.Default.Send<StopsChangedMessage>(new StopsChangedMessage());
            }
        }
    }
}
