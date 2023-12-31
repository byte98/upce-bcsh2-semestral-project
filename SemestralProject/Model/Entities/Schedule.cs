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
    /// Class which represents one line of schedule.
    /// </summary>
    [DatabaseClass("proc_jizdni_rady_create", "func_jizdni_rady_read", "proc_jizdni_rady_update", "proc_jizdni_rady_delete", "jizdni_rady_seq", "id_jizdni_rad")]
    public partial class Schedule
    {
        /// <summary>
        /// Time of arrival.
        /// </summary>
        [DatabaseColumn("cas_prijezdu")]
        public DateTime Arrival { get; set; } = DateTime.Now;

        /// <summary>
        /// Time of departure.
        /// </summary>
        [DatabaseColumn("cas_odjezdu")]
        public DateTime Departure { get; set; } = DateTime.Now;

        /// <summary>
        /// Number of schedule in sequence.
        /// </summary>
        [DatabaseColumn("poradove_cislo")]
        public int SequenceNumber { get; set; } = 0;

        /// <summary>
        /// Variant of schedule.
        /// </summary>
        [DatabaseColumn("varianta")]
        public int Variant { get; set; } = 0;

        /// <summary>
        /// Line of schedule.
        /// </summary>
        [DatabaseColumn("linka")]
        public Line Line { get; set; }

        /// <summary>
        /// Stop of schedule.
        /// </summary>
        [DatabaseColumn("zastavka")]
        public Stop Stop { get; set; }

        public override string? ToString()
        {
            return "[" + this.Line.ToString() + "] " + this.Stop.ToString() + "....." + Arrival.ToString("HH:mm") + " - " + Departure.ToString("HH:mm");
        }
    }
}
