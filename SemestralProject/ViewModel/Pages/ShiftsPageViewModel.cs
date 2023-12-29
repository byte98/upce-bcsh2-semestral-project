using CommunityToolkit.Mvvm.ComponentModel;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SemestralProject.Model.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;


namespace SemestralProject.ViewModel.Pages
{

    /// <summary>
    /// Class which handles behaviour of shifts page.
    /// </summary>
    public partial class ShiftsPageViewModel : AbstractPageViewModel
    {
        /* /// <summary>
         /// Collection of all scheduled shifts.
         /// </summary>
         [ObservableProperty]
         private ObservableCollection<Shift> shifts;*/

        ///// <summary>
        ///// Actually selected stop.
        ///// </summary>
        //[ObservableProperty]
        //private Shift? selectedShift;



        /// <summary>
        /// Creates new view model for stops page.
        /// </summary>
        public ShiftsPageViewModel() : base(PermissionNames.ShiftsModify)
        {
            //this.shifts = new ObservableCollection<Shift>();
            //WeakReferenceMessenger.Default.Register<StopsChangedMessage>(this, async (sender, args) =>
            //{
            //    this.WaitVisibility = Visibility.Visible;
            //    this.ContentVisibility = Visibility.Collapsed;
            //    this.Stops.Clear();
            //    Stop[] loaded = await Stop.GetAllAsync();
            //    foreach (Stop s in loaded)
            //    {
            //        this.Stops.Add(s);
            //    }
            //    this.WaitVisibility = Visibility.Collapsed;
            //    this.ContentVisibility = Visibility.Visible;
            //});
        }

        ///// <summary>
        ///// Handles loading of page.
        ///// </summary>
        //[RelayCommand]
        //private async Task PageLoaded()
        //{
        //    this.WaitVisibility = Visibility.Visible;
        //    this.ContentVisibility = Visibility.Collapsed;
        //    this.Stops.Clear();
        //    Stop[] loaded = await Stop.GetAllAsync();
        //    foreach (Stop s in loaded)
        //    {
        //        this.Stops.Add(s);
        //    }
        //    this.WaitVisibility = Visibility.Collapsed;
        //    this.ContentVisibility = Visibility.Visible;
        //}

        ///// <summary>
        ///// Handles click on new button.
        ///// </summary>
        //[RelayCommand]
        //private async Task New()
        //{
        //    await Stop.CreateAsync(this.StopCode, this.StopName);
        //    WeakReferenceMessenger.Default.Send<StopsChangedMessage>(new StopsChangedMessage());
        //}

        ///// <summary>
        ///// Handles click on remove button.
        ///// </summary>
        //[RelayCommand]
        //private async Task Remove()
        //{
        //    if (this.SelectedStop != null)
        //    {
        //        await this.SelectedStop.DeleteAsync();
        //        WeakReferenceMessenger.Default.Send<StopsChangedMessage>(new StopsChangedMessage());
        //    }
        //}
    }
}
