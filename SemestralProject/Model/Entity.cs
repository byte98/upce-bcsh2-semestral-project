using Oracle.ManagedDataAccess.Client;
using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            if (sql.EndsWith(";") == false) sql += ";";
            string cmd = @$"
                SET TRANSACTION READ WRITE;
                {sql}
                SELECT sempr_utils.func_last_seq('{seq}') AS last_id FROM dual;
                COMMIT;
            ";
            IConnection connection = OracleConnector.Load();
            IDictionary<string, object?>[] result = connection.Query(cmd);
            if (result.Length > 0)
            {
                reti = (int)(result[0]["last_id"] ?? int.MinValue);
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
            string cmd = $"SELECT * FROM TABLE({sql})";
            reti = connection.Query(cmd);
            connection.Execute("COMMIT");
            return reti;
        }
    }
}
