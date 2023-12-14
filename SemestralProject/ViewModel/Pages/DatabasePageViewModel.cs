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
using System.Windows.Controls.Primitives;
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
        /// Actually selected data.
        /// </summary>
        [ObservableProperty]
        private DataRowView? selectedTableData;

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
                        if (kvp.Key.Trim().ToLower().StartsWith("id_"))
                        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                            dataTable.Columns[kvp.Key].ReadOnly = true;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        }
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
                dataTable.RowChanged += async (sender, e) =>
                {
                    this.WaitVisibility = Visibility.Visible;
                    this.ContentVisibility = Visibility.Collapsed;
                    await Task.Run(async () =>
                    {
                        if (this.SelectedTableData != null)
                        {
                            TableColumn[] columns = await Supertool.GetColumnsForTableAsync(this.SelectedTable);
                            IDictionary<string, object?> newValues = new Dictionary<string, object?>();
                            for(int i = 0; i < columns.Length; i++)
                            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                if (i < this.SelectedTableData.Row.ItemArray.Length && this.SelectedTableData.Row.ItemArray[i] != null && this.SelectedTableData.Row.ItemArray[i].GetType() != null &&  this.SelectedTableData.Row.ItemArray[i].GetType() != typeof(DBNull))
                                {
                                    string stringVal = (string)(this.SelectedTableData.Row.ItemArray[i] ?? string.Empty);
                                    int intVal = int.MinValue;
                                    DateTime dtimeValue = DateTime.MinValue;
                                    if (int.TryParse(stringVal, out intVal))
                                    {
                                        newValues.Add(columns[i].Name, intVal);
                                    }
                                    else if (DateTime.TryParse(stringVal, out dtimeValue))
                                    {
                                        newValues.Add(columns[i].Name, dtimeValue);
                                    }
                                    else
                                    {
                                        newValues.Add(columns[i].Name, this.SelectedTableData.Row.ItemArray[i]);
                                    }
                                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            }
                            await Supertool.UpdateAsync(this.SelectedTable, newValues);
                        }
                        
                    });
                    this.SelectedTableChangedCommand.Execute(null);
                };
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
