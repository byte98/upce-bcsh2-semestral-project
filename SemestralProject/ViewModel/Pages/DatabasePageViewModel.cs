using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model;
using SemestralProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

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
        /// Data from actually selected table.
        /// </summary>
        [ObservableProperty]
        private DataView tableData;

        /// <summary>
        /// Creates new model view for database supertool page.
        /// </summary>
        public DatabasePageViewModel(): base(PermissionNames.Supertool)
        {
            this.tables = new ObservableCollection<string>();
            this.tableData = new DataView();
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
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            if (this.SelectedTable != null)
            {
                dynamic[] data = await Supertool.GetTableDataAsync(this.SelectedTable);
                DataTable dataTable = new DataTable();
                if (data.Length > 0)
                {
                    foreach(KeyValuePair<string, object> kvp in data.First())
                    {
                        dataTable.Columns.Add(new DataColumn(kvp.Key));
                    }
                }
                foreach(dynamic d in data)
                {
                    DataRow row = dataTable.NewRow();
                    foreach(KeyValuePair<string, object> kvp in d)
                    {
                        row[kvp.Key] = kvp.Value;
                    }
                    dataTable.Rows.Add(row);
                }
                this.TableData = dataTable.DefaultView;
            }
            
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Creates new header for table column.
        /// </summary>
        /// <param name="name">Name of column.</param>
        /// <param name="dataType">Data type of column.</param>
        /// <returns>Object representing header of column.</returns>
        private static object GetColumnHeader(string name, string dataType)
        {
            Label nameLabel = new Label
            {
                Content = name,
                Margin = new Thickness(0, 0, 0, 16)
            };
            Label dtypeLabel = new Label
            {
                Content = dataType,
                Foreground = Application.Current.Resources["SystemBaseLowColorBrush"] as SolidColorBrush
            };
            return new StackPanel
            {
                Children =
                {
                    nameLabel,
                    dtypeLabel
                }
            };
        }
    }
}
