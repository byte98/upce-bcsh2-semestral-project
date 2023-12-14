using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model.Entities;
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
    /// Class which handles behaviour of logs page.
    /// </summary>
    public partial class LogsPageViewModel: AbstractPageViewModel
    {
        /// <summary>
        /// Collection with all available logs.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Log> logs;

        /// <summary>
        /// Collection with all available operations.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> filterOperations;

        /// <summary>
        /// Collection with all available tables.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> filterTables;

        /// <summary>
        /// Actually selected operation.
        /// </summary>
        [ObservableProperty]
        private string selectedOperation = string.Empty;

        /// <summary>
        /// Actually selected table.
        /// </summary>
        [ObservableProperty]
        private string selectedTable = string.Empty;

        /// <summary>
        /// List with all available logs.
        /// </summary>
        private IList<Log> allLogs;

        /// <summary>
        /// Creates new handler of logs page.
        /// </summary>
        public LogsPageViewModel(): base(PermissionNames.LogsRead)
        {
            this.logs = new ObservableCollection<Log>();
            this.filterOperations = new ObservableCollection<string>();
            this.filterTables = new ObservableCollection<string>();
            this.allLogs = new List<Log>();
        }

        /// <summary>
        /// Handles loading of page.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.Logs.Clear();
            this.FilterTables.Clear();
            this.FilterOperations.Clear();
            this.FilterTables.Add(string.Empty);
            this.FilterOperations.Add(string.Empty);
            this.allLogs.Clear();
            Log[] loadedLogs = await Log.GetAllAsync();
            foreach (Log log in loadedLogs)
            {
                this.Logs.Add(log);
                this.allLogs.Add(log);
                if (this.FilterOperations.Contains(log.Operation) == false)
                {
                    this.FilterOperations.Add(log.Operation);
                }
                if (this.FilterTables.Contains(log.Table) == false)
                {
                    this.FilterTables.Add(log.Table);
                }
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Performs filtering of logs.
        /// </summary>
        [RelayCommand]
        private void Filter()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.Logs.Clear();
            foreach(Log l in this.allLogs)
            {
                if ((this.SelectedTable == string.Empty || this.SelectedTable == l.Table) &&
                    (this.SelectedOperation == string.Empty || this.SelectedOperation == l.Operation))
                {
                    this.Logs.Add(l);
                }
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }
    }
}
