using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Pages
{
    /// <summary>
    /// Class which handles behaviour of stops page.
    /// </summary>
    public partial class StopsPageViewModel: AbstractPageViewModel
    {
        /// <summary>
        /// Collection of all available stops.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Stop> stops;

        /// <summary>
        /// Actually selected stop.
        /// </summary>
        [ObservableProperty]
        private Stop? selectedStop;

        /// <summary>
        /// Code of new stop. 
        /// </summary>
        [ObservableProperty]
        private string stopCode = string.Empty;

        /// <summary>
        /// Name of new stop.
        /// </summary>
        [ObservableProperty]
        private string stopName = string.Empty; 


        /// <summary>
        /// Creates new view model for stops page.
        /// </summary>
        public StopsPageViewModel(): base(PermissionNames.StopsModify)
        {
            this.stops = new ObservableCollection<Stop>();
            WeakReferenceMessenger.Default.Register<StopsChangedMessage>(this, async (sender, args) =>
            {
                this.WaitVisibility = Visibility.Visible;
                this.ContentVisibility = Visibility.Collapsed;
                this.Stops.Clear();
                Stop[] loaded = await Stop.GetAllAsync();
                foreach (Stop s in loaded)
                {
                    this.Stops.Add(s);
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
            this.Stops.Clear();
            Stop[] loaded = await Stop.GetAllAsync();
            foreach(Stop s in loaded)
            {
                this.Stops.Add(s);
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
            await Stop.CreateAsync(this.StopCode, this.StopName);
            WeakReferenceMessenger.Default.Send<StopsChangedMessage>(new StopsChangedMessage());
        }

        /// <summary>
        /// Handles click on remove button.
        /// </summary>
        [RelayCommand]
        private async Task Remove()
        {
            if (this.SelectedStop != null)
            {
                await this.SelectedStop.DeleteAsync();
                WeakReferenceMessenger.Default.Send<StopsChangedMessage>(new StopsChangedMessage());
            }
        }
    }
}
