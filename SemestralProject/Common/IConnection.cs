using SemestralProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SemestralProject.Common
{
    /// <summary>
    /// Interface which abstracts connection into database.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Enumeration of all available database objects.
        /// </summary>
        public enum DatabaseObject
        {
            /// <summary>
            /// Table with data in database.
            /// </summary>
            Table,

            /// <summary>
            /// View of data.
            /// </summary>
            View,

            /// <summary>
            /// Sequence of data.
            /// </summary>
            Sequence,

            /// <summary>
            /// Defined trigger.
            /// </summary>
            Trigger,

            /// <summary>
            /// Named function.
            /// </summary>
            Function,

            /// <summary>
            /// Named procedure.
            /// </summary>
            Procedure,

            /// <summary>
            /// Package of functions, procuedures, etc.
            /// </summary>
            Package
        }

        /// <summary>
        /// Connects to database.
        /// </summary>
        /// <returns>
        /// TRUE, if connection to database has been successfull,
        /// FALSE otherwise.
        /// </returns>
        public abstract bool Connect();

        /// <summary>
        /// Connects to database asynchronously.
        /// </summary>
        /// <returns>
        /// Task, which results into:
        /// TRUE, if connection to database has been successfull,
        /// FALSE otherwise.
        /// </returns>
        public virtual Task<bool> ConnectAsync()
        {
            return Task<bool>.Run(() =>
            {
                return this.Connect();
            });
        }

        /// <summary>
        /// Disconnects from database.
        /// </summary>
        /// <returns>
        /// TRUE, if disconnecting from database has been successfull,
        /// FALSE otherwise.
        /// </returns>
        public abstract bool Disconnect();

        /// <summary>
        /// Disconnects from database asynchronously.
        /// </summary>
        /// <returns>
        /// Task which results into:
        /// TRUE, if disconnecting from database has been successfull,
        /// FALSE otherwise.
        /// </returns>
        public virtual Task<bool> DisconnectAsync()
        {
            return Task<bool>.Run(this.Disconnect);
        }

        /// <summary>
        /// Executes SQL statement.
        /// </summary>
        /// <param name="sql">SQL statement which will be executed.</param>
        /// <returns>
        /// TRUE, if statement has been successfully executed,
        /// FALSE otherwise.
        /// </returns>
        public abstract bool Execute(string sql);

        /// <summary>
        /// Executes SQL statement asynchronously.
        /// </summary>
        /// <param name="sql">SQL statement which will be exectured.</param>
        /// <returns>
        /// Task which results into:
        /// TRUE, if statement has been successfully executed,
        /// FALSE otherwise.
        /// </returns>
        public virtual Task<bool> ExecuteAsync(string sql)
        {
            return Task<bool>.Run(() =>
            {
                return this.Execute(sql);
            });
        }

        /// <summary>
        /// Executes SQL query.
        /// </summary>
        /// <param name="sql">SQL string with query which will be queried.</param>
        /// <returns>
        /// Array of dictionaries representing results where one row in array
        /// represents one row of result and key in dictionary represents
        /// name of column of result.
        /// </returns>
        public IDictionary<string, object?>[] Query(string sql);

        /// <summary>
        /// Executes SQL query asynchronously.
        /// </summary>
        /// <param name="sql">SQL string with query which will be queried.</param>
        /// <returns>Task which results into result of query.</returns>
        public Task<IDictionary<string, object?>[]> QueryAsync(string sql)
        {
            return Task<IDictionary<string, object?>[]>.Run(() =>
            {
                return this.Query(sql);
            });
        }

        /// <summary>
        /// Checks, whether object exists in database.
        /// </summary>
        /// <param name="object">Type of object.</param>
        /// <param name="name">Name of object.</param>
        /// <returns>
        /// TRUE, if object exists in database,
        /// FALSE otherwise.
        /// </returns>
        public abstract bool ObjectExists(IConnection.DatabaseObject @object, string name);

        /// <summary>
        /// Checks, whether object exists in database asynchronously.
        /// </summary>
        /// <param name="object">Type of object.</param>
        /// <param name="name">Name of object.</param>
        /// <returns>
        /// Task, which results into:
        /// TRUE, if object exists in database,
        /// FALSE otherwise.
        /// </returns>
        public virtual Task<bool> ObjectExistsAsync(IConnection.DatabaseObject @object, string name)
        {
            return Task<bool>.Run(() =>
            {
                return this.ObjectExists(@object, name);
            });
        }

        /// <summary>
        /// Data model of connection.
        /// </summary>
        public abstract Connection ConnectionModel { get; }

        /// <summary>
        /// Last received exception by connection.
        /// </summary>
        public abstract Exception? LastException { get; }

        /// <summary>
        /// Number of affected rows.
        /// </summary>
        public abstract int AffectedRows { get; }
        
        /// <summary>
        /// Checks, whether there was any exception thrown.
        /// </summary>
        /// <returns>TRUE, if connection created any exception, FALSE otherwise.</returns>
        public virtual bool HasException()
        {
            return this.LastException != null;
        }
    }
}
