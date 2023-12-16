using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model;
using SemestralProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
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
        /// Data from objects.
        /// </summary>
        [ObservableProperty]
        private DataView objectsData;

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
            this.objectsData = new DataView();
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
            ICollection<IDictionary<string, object>> objectData = await Supertool.GetObjectsDataAsync();
            DataTable dataTable = new DataTable();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (string key in objectData.FirstOrDefault().Keys)
            {
                dataTable.Columns.Add(new DataColumn(key));
                dataTable.Columns[key].ReadOnly = true;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            foreach (IDictionary<string, object> row in objectData)
            {
                DataRow r = dataTable.NewRow();
                foreach(string key in row.Keys)
                {
                    if (dataTable.Columns.Contains(key))
                    {
                        r[key] = row[key];
                    }
                   
                }
                dataTable.Rows.Add(r);
            }
            this.ObjectsData = dataTable.DefaultView;
            this.ObjectsData.AllowEdit = false;
            this.ObjectsData.AllowDelete = false;
            this.ObjectsData.AllowNew = false;
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
                        if (dataTable.Columns.Contains(kvp.Key) == false)
                        {
                            dataTable.Columns.Add(new DataColumn(kvp.Key));
                        }
                        row[kvp.Key] = kvp.Value;
                    }
                    dataTable.Rows.Add(row);
                }
                dataTable.RowDeleting += async (sender, e) =>
                {
                    DataRow row = e.Row;
                    IDictionary<string, object?>? data = this.GetSelectedData(row);
                    this.WaitVisibility = Visibility.Visible;
                    this.ContentVisibility = Visibility.Collapsed;
                    await Task.Run(async () =>
                    {
                        
                        if (data != null)
                        {
                            await Supertool.DeleteAsync(this.SelectedTable, data);
                        }
                    });
                    
                    this.SelectedTableChangedCommand.Execute(null);

                };
                dataTable.RowChanged += async (sender, e) =>
                {
                    this.WaitVisibility = Visibility.Visible;
                    this.ContentVisibility = Visibility.Collapsed;
                    await Task.Run(async () =>
                    {
                        if (this.SelectedTableData != null)
                        {
                            IDictionary<string, object?>? data = this.GetSelectedData(this.SelectedTableData.Row);
                            if (data != null)
                            {
                                await Supertool.UpdateAsync(this.SelectedTable, data);
                            }
                        }
                        
                    });
                    this.SelectedTableChangedCommand.Execute(null);
                };
                dataTable.TableNewRow += async (sender, e) =>
                {
                    this.WaitVisibility = Visibility.Visible;
                    this.ContentVisibility = Visibility.Collapsed;
                    await Task.Run(async () =>
                    {
                        IDictionary<string, object?>? data = this.GetSelectedData(e.Row);
                        if (data != null)
                        {
                            await Supertool.CreateAsync(this.SelectedTable, data);
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
        /// Gets dictionary with actually selected data.
        /// </summary>
        /// <param name="row">Row which contains data.</param>
        /// <returns>Dictionary with actually selected data.</returns>
        private IDictionary<string, object?>? GetSelectedData(DataRow row)
        {
            IDictionary<string, object?>? reti = null;
            if (row != null && this.SelectedTable != null)
            {
                TableColumn[] columns = Supertool.GetColumnsForTable(this.SelectedTable);
                reti = new Dictionary<string, object?>();
                for (int i = 0; i < columns.Length; i++)
                {
                    if (i < row.ItemArray.Length && row.ItemArray[i] != null && row.ItemArray[i].GetType() != null && row.ItemArray[i].GetType() != typeof(DBNull))
                    {
                        string stringVal = (string)(row.ItemArray[i] ?? string.Empty);
                        int intVal = int.MinValue;
                        DateTime dtimeValue = DateTime.MinValue;
                        if (int.TryParse(stringVal, out intVal))
                        {
                            reti.Add(columns[i].Name, intVal);
                        }
                        else if (DateTime.TryParse(stringVal, out dtimeValue))
                        {
                            reti.Add(columns[i].Name, dtimeValue);
                        }
                        else
                        {
                            reti.Add(columns[i].Name, row.ItemArray[i]);
                        }
                    }
                }
            }
            return reti;
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
