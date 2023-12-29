using SemestralProject.DatabaseObject.DatabaseClass;
using SemestralProject.DatabaseObject.DatabaseColummn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class whihc represents one single log.
    /// </summary>
    [DatabaseClass("", "func_logy_read", "", "", "logy_seq", "id_log")]
    public partial class Log
    {
        /// <summary>
        /// Time of creation of log.
        /// </summary>
        [DatabaseColumn("cas")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Name of performed operation.
        /// </summary>
        [DatabaseColumn("operace")]
        public string Operation { get; set; }

        /// <summary>
        /// Name of table.
        /// </summary>
        [DatabaseColumn("tabulka")]
        public string Table { get; set; }

        /// <summary>
        /// Number of affected rows.
        /// </summary>
        [DatabaseColumn("pocet_radku")]
        public int Rows { get; set; }

        /// <summary>
        /// Message connected with log.
        /// </summary>
        [DatabaseColumn("zprava")]
        public string Message { get; set; }
    }
}
