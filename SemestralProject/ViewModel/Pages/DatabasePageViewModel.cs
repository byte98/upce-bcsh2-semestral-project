using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model;
using SemestralProject.Model.Enums;
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
    /// Class which handles behaviour of database supertool page.
    /// </summary>
    public partial class DatabasePageViewModel: AbstractPageViewModel
    {
        /// <summary>
        /// Collection with all available tables.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> tables;

        /// <summary>
        /// Actually selected table.
        /// </summary>
        [ObservableProperty]
        private string? selectedTable;

        /// <summary>
        /// Creates new model view for database supertool page.
        /// </summary>
        public DatabasePageViewModel(): base(PermissionNames.Supertool)
        {
            this.tables = new ObservableCollection<string>();
        }


        /// <summary>
        /// Handles loading of page.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            string[] tabNames = await Supertool.GetTableNamesAsync();
            this.Tables.Clear();
            foreach(string tabName in tabNames)
            {
                this.Tables.Add(tabName);
            }
            if (this.Tables.Count > 0)
            {
                this.SelectedTable = this.Tables.First();
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles change of selected table.
        /// </summary>
        [RelayCommand]
        private async Task SelectedTableChanged()
        {

        }
    }
}
