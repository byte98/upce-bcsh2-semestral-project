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
    /// View model of municipality selector.
    /// </summary>
    public partial class MunicipalitySelectorViewModel: ObservableObject
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
        [NotifyCanExecuteChangedFor(nameof(FindMunicipalityCommand))]
        private Visibility comboboxVisibility;

        /// <summary>
        /// Collection of all available municipalities.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Municipality> availableMunicipalities;

        /// <summary>
        /// Actually selected municipality. 
        /// </summary>
        [ObservableProperty]
        private Municipality? selectedMunicipality;

        /// <summary>
        /// Creates new view model for municipality selector.
        /// </summary>
        public MunicipalitySelectorViewModel()
        {
            this.loaderVisibility = Visibility.Visible;
            this.comboboxVisibility = Visibility.Collapsed;
            this.AvailableMunicipalities = new ObservableCollection<Municipality>();
            WeakReferenceMessenger.Default.Register<MunicipalitiesChangedMessage>(this, (sender, args) =>
            {
                this.Load();
            });
            WeakReferenceMessenger.Default.Register<SelectedMunicipalityChangedMessage>(this, (sender, args) =>
            {
                this.SelectedMunicipality = args.Value;
            });
        }

        /// <summary>
        /// Loads data for control.
        /// </summary>
        /// <returns>Task which performs loading of control.</returns>
        private async void Load()
        {
            this.AvailableMunicipalities.Clear();
            this.LoaderVisibility = Visibility.Visible;
            this.ComboboxVisibility = Visibility.Collapsed;
            Municipality[] municipalities = await Municipality.GetAllAsync();
            foreach (Municipality mun in municipalities)
            {
                this.AvailableMunicipalities.Add(mun);
            }
            this.SelectedMunicipality = ArrayUtils<Municipality>.Random(municipalities);
            this.LoaderVisibility = Visibility.Collapsed;
            this.ComboboxVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles initialization after control is loaded.
        /// </summary>
        /// <returns>Task which performs initialization of control.</returns>
        [RelayCommand]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task ControlLoaded()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            this.Load();
        }

        /// <summary>
        /// Finds municipality.
        /// </summary>
        [RelayCommand(CanExecute =nameof(FindAllowed))]
        private void FindMunicipality()
        {
            MunicipalitySelectorWindow municipalitySelectorWindow = new MunicipalitySelectorWindow();
            municipalitySelectorWindow.ShowDialog();
        }

        /// <summary>
        /// Checks, whether finding municipality is allowed.
        /// </summary>
        /// <returns>
        /// TRUE, if finding municipality is allowed,
        /// FALSE otherwise.
        /// </returns>
        private bool FindAllowed() => this.ComboboxVisibility == Visibility.Visible; 
    }
}
