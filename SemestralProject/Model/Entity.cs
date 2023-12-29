using Oracle.ManagedDataAccess.Client;
using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which abstracts all database entities.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Identifier of entity.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <returns>TRUE if entity has been successfully updated, FALSE otherwise.</returns>
        public abstract bool Update();

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <returns>TRUE if entity has been deleted, FALSE otherwise.</returns>
        public abstract bool Delete();

        /// <summary>
        /// Performs creation of entity.
        /// </summary>
        /// <param name="sql">SQL statement which creates entity.</param>
        /// <param name="seq">Name of sequence responsible for creating identifier of entity.</param>
        /// <returns>Identifier of newly created entity.</returns>
        protected static int Create(string sql, string seq)
        {
            int reti = int.MinValue;
            if (sql.EndsWith(";") == false) sql = sql + ";";
            if (sql.All(c => char.IsUpper(c)) == false) seq = seq.ToUpper();
            IConnection connection = OracleConnector.Load();
            connection.Execute("SET TRANSACTION READ WRITE");
            connection.Execute("SAVEPOINT entity_create_savepoint");
            if (connection.Execute("BEGIN\n    " + sql + "\nEND;") == false)
            {
                connection.Execute("ROLLBACK TO SAVEPOINT entity_create_savepoint");
            }
            else
            {
                IDictionary<string, object?>[] result = connection.Query($"SELECT sempr_utils.func_last_seq('{seq}') AS last_id FROM dual");
                if (result.Length > 0)
                {
                    reti = (int)(result[0]["last_id"] ?? int.MinValue);
                }
                connection.Execute("COMMIT");
            }
            return reti;
        }

        /// <summary>
        /// Performs reading of entity.
        /// </summary>
        /// <param name="sql">SQL query which can read entity.</param>
        /// <returns>Result of reading of entity.</returns>
        protected static IDictionary<string, object?>[] Read(string sql)
        {
            IDictionary<string, object?>[] reti = new IDictionary<string, object?>[0];
            IConnection connection = OracleConnector.Load();
            connection.Execute("COMMIT");
            string cmd = $"SELECT * FROM TABLE({sql})";
            reti = connection.Query(cmd);
            connection.Execute("COMMIT");
            return reti;
        }

        /// <summary>
        /// Executes call of PL/SQL function.
        /// </summary>
        /// <param name="sql">PL/SQL function which will be executed.</param>
        /// <returns>TRUE if execution has been successfull, FALSE otherwise.</returns>
        private static bool Execute(string sql)
        {
            bool reti = false;
            if (sql.EndsWith(";") == false) sql = sql + ";";
            IConnection connection = OracleConnector.Load();
            string cmd = $"BEGIN\n    {sql}\nEND;";
            reti = connection.Execute(cmd);
            connection.Execute("COMMIT");
            return reti;
        }
        
        /// <summary>
        /// Performs update of entity.
        /// </summary>
        /// <param name="sql">SQL query which peforms update.</param>
        /// <returns>TRUE if update has been successfull, FALSE otherwise.</returns>
        protected static bool Update(string sql)
        {
            return Entity.Execute(sql);
        }

        /// <summary>
        /// Performs deletion of entity.
        /// </summary>
        /// <param name="sql">SQL query which performs deletion.</param>
        /// <returns>TRUE if deletion has been successfull, FALSE otherwise.</returns>
        protected static bool Delete(string sql)
        {
            return Entity.Execute(sql);
        }
        

        public override bool Equals(object? obj)
        {
            bool reti = false;
            if (obj != null)
            {
                if (obj.GetType() == this.GetType())
                {
                    Entity e = (Entity)obj;
                    return e.Id == this.Id;
                }
            }
            return reti;
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ this.Id);
        }
    }
}
