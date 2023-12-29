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
    /// Class which represents single stop.
    /// </summary>
    [DatabaseClass("proc_zastavky_create", "func_zastavky_read", "proc_zastavky_update", "proc_zastavky_delete", "zastavky_seq", "id_zastavka")]
    public partial class Stop
    {
        
        /// <summary>
        /// Code of the stop.
        /// </summary>
        [DatabaseColumn("kod")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Name of the stop.
        /// </summary>
        [DatabaseColumn("nazev")]
        public string Name { get; set; } = string.Empty;

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
