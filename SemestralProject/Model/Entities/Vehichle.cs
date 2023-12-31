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
    /// Class which represents a single vehicle.
    /// </summary>
    [DatabaseClass("proc_vozidla_create", "func_vozidla_read", "proc_vozidla_update", "proc_vozidla_delete", "vozidla_seq", "id_vozidlo")]
    public partial class Vehicle
    {

        /// <summary>
        /// Evidential number for the vehicle.
        /// </summary>
        [DatabaseColumn("evidencni_cislo")]
        public string EvidenceNumber { get; set; }

        /// <summary>
        /// Type of Vehicle.
        /// </summary>
        [DatabaseColumn("typ_vozidla")]
        public string VehicleType { get; set; }

        public override string? ToString()
        {
            return this.EvidenceNumber;
        }
    }
}
