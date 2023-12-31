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
    /// Class which represents a single shift.
    /// </summary>
    [DatabaseClass("proc_smeny_create", "func_smeny_read", "proc_smeny_update", "proc_smeny_delete", "smeny_seq", "id_smena")]
    public partial class Shift
    {


        /// <summary>
        /// Code of the stop.
        /// </summary>
        [DatabaseColumn("id_vozidlo")]
        public Vehicle vehicle { get; set; }

        /// <summary>
        /// Code of the stop.
        /// </summary>
        [DatabaseColumn("id_zamestnanec")]
        public Employee employee { get; set; }

        /// <summary>
        /// Code of the stop.
        /// </summary>
        [DatabaseColumn("id_jizndi_rad")]
        public Schedule Schedule { get; set; }


        public string Name { get; set; } = string.Empty;

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
