﻿// <auto-generated />
#pragma warning disable
#nullable enable

using System.Threading.Tasks;
namespace SemestralProject.Model
{
    public partial class Supertool
    {
        /// <summary>
        /// Gets names of all available tables asynchronously.
        /// </summary>
        /// <returns> Task which resolves into: array with all available names of tables.</returns>
        public static System.Threading.Tasks.Task<string[]> GetTableNamesAsync()
        {
            return Task<string[]>.Run(() => {
                return Supertool.GetTableNames();
            });
        }

        /// <summary>
        /// Gets columns of table asynchronously.
        /// </summary>
        /// <param name="table">Name of table.</param>
        /// <returns> Task which resolves into: array with table columns usable in data grid.</returns>
        public static System.Threading.Tasks.Task<SemestralProject.Model.TableColumn[]> GetColumnsForTableAsync(string table)
        {
            return Task<SemestralProject.Model.TableColumn[]>.Run(() => {
                return Supertool.GetColumnsForTable(table);
            });
        }

        /// <summary>
        /// Gets data from table asynchronously.
        /// </summary>
        /// <param name="table">Name of table.</param>
        /// <returns> Task which resolves into: array with data from table.</returns>
        public static System.Threading.Tasks.Task<dynamic[]> GetTableDataAsync(string table)
        {
            return Task<dynamic[]>.Run(() => {
                return Supertool.GetTableData(table);
            });
        }

        /// <summary>
        /// Updates data in database asynchronously.
        /// </summary>
        /// <param name="table">Name of table which data will be updated.</param>
        /// <param name="data">New values of data.</param>
        /// <returns>
        /// Task which 
        /// updates data in database asynchronously.
        /// </returns>
        public static System.Threading.Tasks.Task UpdateAsync(string table, System.Collections.Generic.IDictionary<string, object?> data)
        {
            return Task.Run(() => {
                Supertool.Update(table, data);
            });
        }

    }
}
