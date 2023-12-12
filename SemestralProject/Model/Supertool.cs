using SemestralProject.AsynchronousMethod;
using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
