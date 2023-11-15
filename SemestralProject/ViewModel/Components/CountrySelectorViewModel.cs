using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
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
    /// Class which handles selector of country.
    /// </summary>
    public partial class CountrySelectorViewModel: ObservableObject
    {
        /// <summary>
        /// Visibility of loading text.
        /// </summary>
        [ObservableProperty]
        private Visibility loaderVisibility;

        /// <summary>
        /// Visibility of combo box.
        /// </summary>
        [ObservableProperty]
        private Visibility comboBoxVisibility;

        /// <summary>
        /// List with all available countries.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Country> availableCountries;

        /// <summary>
        /// Selected country.
        /// </summary>
        [ObservableProperty]
        private Country? selectedCountry;

        /// <summary>
        /// Creates new view model for country selector.
        /// </summary>
        public CountrySelectorViewModel()
        {
            this.loaderVisibility = Visibility.Visible;
            this.comboBoxVisibility = Visibility.Collapsed;
            this.availableCountries = new ObservableCollection<Country>();
            this.selectedCountry = null;
        }

        /// <summary>
        /// Handles initialization after loading of control.
        /// </summary>
        [RelayCommand]
        private async Task ControlLoaded()
        {
            Country[] countries = await Country.GetAllAsync();
            this.AvailableCountries.Clear();
            foreach(Country c in countries)
            {
                this.AvailableCountries.Add(c);
            }
            Country? cz = await Country.GetByNameAsync("Česká republika");
            if (cz !=  null)
            {
                this.SelectedCountry = cz;
            }
            else
            {
                this.SelectedCountry = ArrayUtils<Country>.Random(countries);
            }
            this.LoaderVisibility = Visibility.Collapsed;
            this.ComboBoxVisibility = Visibility.Visible;
        }
    }
}
