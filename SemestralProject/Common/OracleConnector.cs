using SemestralProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

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

        public ConnectionModel ConnectionModel { get; init; }

        /// <summary>
        /// Creates new connection into Oracle database.
        /// </summary>
        /// <param name="connectionModel">Data model of connection.</param>
        private OracleConnector(ConnectionModel connectionModel)
        {
            this.ConnectionModel = connectionModel;
            this.ConnectionModel.PropertyChanged += PropertyChan
            this.UpdateConnection();
        }

        /// <summary>
        /// Updates internal connection to the database.
        /// </summary>
        private void UpdateConnection()
        {

        }

        /// <summary>
        /// Updates connection string to the database.
        /// </summary>
        private void UpdateConnectionString()
        {

        }

        public Task<bool> Connect()
        {
            throw new NotImplementedException();
        }

        public Task Execute(string sql)
        {
            throw new NotImplementedException();
        }

        public Task<object> Query(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
