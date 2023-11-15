using SemestralProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Reflection.Metadata.Ecma335;
using System.IO.Packaging;
using System.Runtime.CompilerServices;
using System.IO;

namespace SemestralProject.Common
{
    /// <summary>
    /// Class which represents connection to Oracle Database.
    /// </summary>
    internal class OracleConnector : IConnection
    {
        /// <summary>
        /// Connection string to the database.
        /// </summary>
        private string? connectionString;

        /// <summary>
        /// Internal connection to the database.
        /// </summary>
        private OracleConnection? connection;

        /// <summary>
        /// Instance of connection to the database.
        /// </summary>
        private static OracleConnector? instance;

        public Connection ConnectionModel { get; init; }
        public Exception? LastException { get; private set; }
        public int AffectedRows { get; private set; }

        /// <summary>
        /// Loads connection from saved settings asynchronously.
        /// </summary>
        /// <returns>Task which resolves into connection with parameters from settings.</returns>
        public static Task<OracleConnector> LoadAsync()
        {
            return Task<OracleConnector>.Run(() =>
            {
                Connection model = Connection.Unknown;
                model.Load();
                return new OracleConnector(model);
            });
        }

        /// <summary>
        /// Loads connection from saved settings.
        /// </summary>
        /// <returns>Connection with parameters from settings.</returns>
        public static OracleConnector Load()
        {
            if (OracleConnector.instance != null)
            {
                return OracleConnector.instance;
            }
            else
            {
                if (File.Exists("db.log"))
                {
                    File.Delete("db.log");
                }
                Connection model = Connection.Unknown;
                model.Load();
                OracleConnector reti = new OracleConnector(model);
                OracleConnector.instance = reti;
                return reti;
            }
        }

        /// <summary>
        /// Reloads connection from saved settings.
        /// </summary>
        /// <returns>Connection with parameters from settings.</returns>
        public static OracleConnector Reload()
        {
            if (File.Exists("db.log"))
            {
                File.Delete("db.log");
            }
            Connection model = Connection.Unknown;
            model.Load();
            OracleConnector reti = new OracleConnector(model);
            OracleConnector.instance = reti;
            return reti;
        }

        /// <summary>
        /// Reloads connection from saved settings asynchronously.
        /// </summary>
        /// <returns>Task which resolves into connection with parameters from settings.</returns>
        public static Task<OracleConnector> ReloadAsync()
        {
            return Task<OracleConnector>.Run(() =>
            {
                return OracleConnector.Reload();
            });
        }

        /// <summary>
        /// Creates new connection into Oracle database.
        /// </summary>
        /// <param name="connectionModel">Data model of connection.</param>
        private OracleConnector(Connection connectionModel)
        {
            this.ConnectionModel = connectionModel;
        }

        /// <summary>
        /// Updates internal connection to the database.
        /// </summary>
        private void UpdateConnection()
        {
            this.UpdateConnectionString();
            if (this.connection != null)
            {
                this.Disconnect();
            }
            this.connection = new OracleConnection(this.connectionString);
        }

        /// <summary>
        /// Prepares properties.
        /// </summary>
        private void Prepare()
        {
            this.AffectedRows = 0;
            this.LastException = null;
        }

        /// <summary>
        /// Updates connection string to the database.
        /// </summary>
        private void UpdateConnectionString()
        {
            this.connectionString = $"Data Source={this.ConnectionModel.Server}:{this.ConnectionModel.Port}/{this.ConnectionModel.Database};User ID={this.ConnectionModel.Username};Password={this.ConnectionModel.Password};Connection Timeout=30; Persist Security Info=false";
        }

        /// <summary>
        /// Writes text to log file.
        /// </summary>
        /// <param name="text">Text which will be written to log file.</param>
        private void Log(string text)
        {
            using (StreamWriter sw = File.AppendText("db.log"))
            {
                //sw.WriteLine(DateTime.Now.ToString() + ": " + text);
                sw.WriteLine(text);
            }
        }

        public bool Connect()
        {
            this.Prepare();
            bool reti = false;
            this.UpdateConnection();
            if (this.connection != null)
            {
                try
                {
                    this.connection.Open();
                }
                catch (Exception ex)
                {
                    reti = false;
                    this.LastException = ex;
                }
                reti = (connection.State == System.Data.ConnectionState.Open);
            }
            return reti;
        }

        public bool Execute(string sql)
        {
            bool reti = false;
            this.Prepare();
            if (this.connection != null)
            {
                using (OracleCommand cmd = this.connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    this.Log(sql);
                    try
                    {
                        this.AffectedRows = cmd.ExecuteNonQuery();
                        reti = true;
                    }
                    catch (Exception ex)
                    {
                        reti = false;
                        this.LastException = ex;
                    }
                }
            }
            return reti;
        }

        public IDictionary<string, object?>[] Query(string sql)
        {
            IDictionary<string, object?>[] reti = new IDictionary<string, object?>[0];
            this.Prepare();
            if (this.connection != null)
            {
                using (OracleCommand cmd = this.connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    this.Log(sql);
                    try
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            IList<IDictionary<string, object?>> results = new List<IDictionary<string, object?>>();
                            while(reader.Read())
                            {
                                IDictionary<string, object?> row = new Dictionary<string, object?>();
                                for (int i = 0; i < reader.FieldCount;  i++)
                                {
                                    row[reader.GetName(i)] = reader.GetValue(i);
                                }
                                results.Add(row);
                            }
                            reti = results.ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        this.LastException = ex;
                    }
                }
            }
            return reti;
        }

        public bool ObjectExists(IConnection.DatabaseObject @object, string name)
        {
            bool reti = false;
            switch(@object)
            {
                case IConnection.DatabaseObject.Table:     reti = this.TableExists(name);     break;
                case IConnection.DatabaseObject.View:      reti = this.ViewExists(name);      break;
                case IConnection.DatabaseObject.Sequence:  reti = this.SequenceExists(name);  break;
                case IConnection.DatabaseObject.Trigger:   reti = this.TriggerExists(name);   break;
                case IConnection.DatabaseObject.Procedure: reti = this.ProcedureExists(name); break;
                case IConnection.DatabaseObject.Function:  reti = this.FunctionExists(name);  break;
                case IConnection.DatabaseObject.Package:   reti = this.PackageExists(name);   break;
                default:                                   reti = false;                      break;
            }
            return reti;
        }

        /// <summary>
        /// Executes existential query.
        /// </summary>
        /// <param name="query">Query which will be executed.</param>
        /// <param name="colName">Name of column in result which will be checked.</param>
        /// <returns>TRUE if existential query confirms existence, FALSE otherwise.</returns>
        private bool ExistsQuery(string query, string colName)
        {
            bool reti = false;
            IDictionary<string, object?>[] result = this.Query(query);
            if (result.Length > 0)
            {
                IDictionary<string, object?> row = result[0];
                if (row.ContainsKey(colName) && row[colName] != null)
                {
                    int val = int.Parse((row[colName]?.ToString() ?? "0"));
                    if (val > 0)
                    {
                        reti = true;
                    }
                }
            }
            return reti;
        }

        /// <summary>
        /// Checks, whether table exists in database.
        /// </summary>
        /// <param name="name">Name of table.</param>
        /// <returns>TRUE if table exists in database, FALSE otherwise.</returns>
        private bool TableExists(string name)
        {
            string sql = "SELECT COUNT(*) AS COUNT FROM all_tables WHERE table_name='" + name + "'";
            return this.ExistsQuery(sql, "COUNT");
        }

        /// <summary>
        /// Checks, whether view exists in database.
        /// </summary>
        /// <param name="name">Name of view.</param>
        /// <returns>TRUE if view exists in database, FALSE otherwise.</returns>
        private bool ViewExists(string name)
        {
            string sql = "SELECT COUNT(*) AS COUNT FROM all_views WHERE view_name='" + name + "'";
            return this.ExistsQuery(sql, "COUNT");
        }

        /// <summary>
        /// Checks, whether sequence exists in database.
        /// </summary>
        /// <param name="name">Name of sequence.</param>
        /// <returns>TRUE if sequence exists in database, FALSE otherwise.</returns>
        private bool SequenceExists(string name)
        {
            string sql = "SELECT COUNT(*) AS COUNT FROM all_sequences WHERE sequence_name='" + name + "'";
            return this.ExistsQuery(sql, "COUNT");
        }

        /// <summary>
        /// Checks, whether trigger exists in database.
        /// </summary>
        /// <param name="name">Name of trigger.</param>
        /// <returns>TRUE if trigger exists in database, FALSE otherwise.</returns>
        private bool TriggerExists(string name)
        {
            string sql = "SELECT COUNT(*) AS COUNT FROM all_triggers WHERE trigger_name='" + name + "'";
            return this.ExistsQuery(sql, "COUNT");
        }

        /// <summary>
        /// Checks, whether procedure exists in database.
        /// </summary>
        /// <param name="name">Name of procedure.</param>
        /// <returns>TRUE if procedure exists in database, FALSE otherwise.</returns>
        private bool ProcedureExists(string name)
        {
            string sql = "SELECT COUNT(*) AS COUNT FROM all_procedures WHERE object_type='PROCEDURE' AND object_name='" + name + "'";
            return this.ExistsQuery(sql, "COUNT");
        }

        /// <summary>
        /// Checks, whether function exists in database.
        /// </summary>
        /// <param name="name">Name of function.</param>
        /// <returns>TRUE if function exists in database, FALSE otherwise.</returns>
        private bool FunctionExists(string name)
        {
            string sql = "SELECT COUNT(*) AS COUNT FROM all_procedures WHERE object_type='FUNCTION' AND object_name='" + name + "'";
            return this.ExistsQuery(sql, "COUNT");
        }

        /// <summary>
        /// Checks, whether package exists in database.
        /// </summary>
        /// <param name="name">Name of package which will be checked.</param>
        /// <returns>TRUE if package exists in database, FALSE otherwise.</returns>
        private bool PackageExists(string name)
        {
            string sql = "SELECT COUNT(*) AS COUNT FROM all_objects WHERE object_type='PACKAGE' AND object_name='" + name + "'";
            return this.ExistsQuery(sql, "COUNT");
        }

        public bool Disconnect()
        {
            bool reti = true;
            this.Prepare();
            if (this.connection != null)
            {
                reti = false;
                try
                {
                    this.connection.Close();
                }
                catch (Exception ex)
                {
                    reti = false;
                    this.LastException = ex;
                }
                if (this.LastException != null)
                {
                    reti = true;
                }
            }
            return reti;
        }
    }
}
