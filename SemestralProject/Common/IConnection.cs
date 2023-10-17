using SemestralProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common
{
    /// <summary>
    /// Interface which abstracts connection into database.
    /// </summary>
    internal interface IConnection
    {
        /// <summary>
        /// Connects to database.
        /// </summary>
        /// <returns>
        /// TRUE, if connection to database has been successfull,
        /// FALSE otherwise.
        /// </returns>
        public abstract Task<bool> Connect();

        /// <summary>
        /// Executes SQL statement.
        /// </summary>
        /// <param name="sql">SQL statement which will be executed.</param>
        /// <returns>Task which handles execution of SQL statement.</returns>
        public abstract Task Execute(string sql);

        /// <summary>
        /// Executes SQL query.
        /// </summary>
        /// <param name="sql">SQL string which will be queried.</param>
        /// <returns>Task which handles query of SQL string.</returns>
        public abstract Task<object> Query(string sql);

        /// <summary>
        /// Data model of connection.
        /// </summary>
        public abstract ConnectionModel ConnectionModel { get; }
        
    }
}
