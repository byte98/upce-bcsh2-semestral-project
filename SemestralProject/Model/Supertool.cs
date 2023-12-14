﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using SemestralProject.AsynchronousMethod;
using SemestralProject.Common;
using SemestralProject.Utils;
using SemestralProject.View.Windows;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents database supertool.
    /// </summary>
    public partial class Supertool
    {
        /// <summary>
        /// Gets names of all available tables.
        /// </summary>
        /// <returns>Array with all available names of tables.</returns>
        [AsynchronousMethod]
        public static string[] GetTableNames()
        {
            string[] reti = new string[0];
            IConnection connection = OracleConnector.Load();
            connection.Execute("SET TRANSACTION READ ONLY");
            IDictionary<string, object?>[] results = connection.Query("SELECT TABLE_NAME FROM user_tables");
            connection.Execute("COMMIT");
            IList<string> loadedData = new List<string>();
            if (results.Length > 0)
            {
                foreach(IDictionary<string, object?> row in results)
                {
                    string tabName = (string)(row["TABLE_NAME"] ?? string.Empty);
                    if (tabName.Length > 0)
                    {
                        loadedData.Add(tabName);
                    }
                }
            }
            reti = loadedData.ToArray();
            return reti;
        }

        /// <summary>
        /// Gets columns of table.
        /// </summary>
        /// <param name="table">Name of table.</param>
        /// <returns>Array with table columns usable in data grid.</returns>
        [AsynchronousMethod]
        public static TableColumn[] GetColumnsForTable(string table)
        {
            IList<TableColumn> reti = new List<TableColumn>();
            string sql = $"SELECT column_name, data_type, data_length FROM USER_TAB_COLUMNS WHERE table_name='{table}'";
            IConnection connection = OracleConnector.Load();
            IDictionary<string, object?>[] results = connection.Query(sql);
            if (results.Length > 0)
            {
                foreach( IDictionary<string, object?> row in results)
                {
                    string dtype = (string)(row["data_type"] ?? string.Empty);
                    string colName = (string)(row["column_name"] ?? string.Empty);
                    if (dtype.Length * colName.Length > 0) // Is both dtype and colName NOT empty?
                    {
                        reti.Add(new TableColumn(colName, dtype));
                    }
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets data from table.
        /// </summary>
        /// <param name="table">Name of table.</param>
        /// <returns>Array with data from table.</returns>
        [AsynchronousMethod]
        public static dynamic[] GetTableData(string table)
        {
            IList<dynamic> reti = new List<dynamic>();
            string sql = $"SELECT * FROM {table}";
            IConnection connection = OracleConnector.Load();
            connection.Execute("SET TRANSACTION READ ONLY");
            IDictionary<string, object?>[] result = connection.Query(sql);
            if (result.Length > 0)
            {
                foreach(IDictionary<string, object?> row in result)
                {
                    dynamic data = new ExpandoObject();
                    foreach(KeyValuePair<string, object?> kvp in row)
                    {
                        if (kvp.Value != null)
                        {
                            ((IDictionary<string, object>)data)[kvp.Key] = kvp.Value;
                        }
                    }
                    reti.Add(data);
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Updates data in database.
        /// </summary>
        /// <param name="table">Name of table which data will be updated.</param>
        /// <param name="data">New values of data.</param>
        [AsynchronousMethod]
        public static void Update(string table, IDictionary<string, object?> data)
        {
            int id = int.MinValue;
            string idCol = string.Empty;
            foreach(KeyValuePair<string, object?> row in data)
            {
                if (row.Key.ToLower().Trim().StartsWith("id_"))
                {
                    id = (int)(row.Value ?? int.MinValue);
                    idCol = (string)row.Key;
                }
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ");
            sql.Append(table);
            sql.Append(" SET ");
            for (int i = 0; i < data.Keys.Count; i++)
            {
                sql.Append(data.Keys.ElementAt(i));
                sql.Append("=");
                if (data.Values.ElementAt(i) is int)
                {
                    sql.Append(data.Values.ElementAt(i));
                }
                else if (data.Values.ElementAt(i) is DateTime)
                {
                    sql.Append(DateUtils.ToSQL((DateTime)(data.Values.ElementAt(i) ?? DateTime.MinValue)));
                }
                else
                {
                    sql.Append("'");
                    sql.Append(data.Values.ElementAt(i));
                    sql.Append("'");
                }
                if (i < data.Keys.Count - 1)
                {
                    sql.Append(", ");
                }
            }
            if (idCol != string.Empty)
            {
                sql.Append(" WHERE ");
                sql.Append(idCol);
                sql.Append("=");
                sql.Append(id);
                IConnection connection = OracleConnector.Load();
                connection.Execute("SET TRANSACTION READ WRITE");
                connection.Execute(sql.ToString());
                connection.Execute("COMMIT");
            }
            
        }
    }
}
