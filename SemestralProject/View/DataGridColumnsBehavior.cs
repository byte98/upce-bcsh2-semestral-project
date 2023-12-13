using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SemestralProject.View
{
    /// <summary>
    /// Class which allows dynamic columns for data grid.
    /// </summary>
    public class DataGridColumnsBehavior
    {
        public static readonly DependencyProperty ColumnsSourceProperty =
            DependencyProperty.RegisterAttached("ColumnsSource", typeof(ObservableCollection<DataGridColumn>), typeof(DataGridColumnsBehavior), new PropertyMetadata(null, OnColumnsSourceChanged));

        public static void SetColumnsSource(DataGrid element, ObservableCollection<DataGridColumn> value)
        {
            element.SetValue(ColumnsSourceProperty, value);
        }

        public static ObservableCollection<DataGridColumn> GetColumnsSource(DataGrid element)
        {
            return (ObservableCollection<DataGridColumn>)element.GetValue(ColumnsSourceProperty);
        }

        private static void OnColumnsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGrid dataGrid)
            {
                dataGrid.Columns.Clear();
                if (e.NewValue is ObservableCollection<DataGridColumn> columns)
                {
                    foreach (var column in columns)
                    {
                        dataGrid.Columns.Add(column);
                    }
                }
            }
        }
    }
}
