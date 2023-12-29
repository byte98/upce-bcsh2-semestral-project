using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents light variant of schedule.
    /// </summary>
    public class LightSchedule
    {
        /// <summary>
        /// Stop to which is schedule associated.
        /// </summary>
        public Stop  Stop { get; set; }

        /// <summary>
        /// Date and time of arrival.
        /// </summary>
        public DateTime Arrival { get; set; }

        /// <summary>
        /// Date and time of departure.
        /// </summary>
        public DateTime Departure { get; set; }

        public override string? ToString()
        {
            return Stop.Name + " ..... " + Arrival.ToString("HH:mm") + " - " + Departure.ToString("HH:mm");
        }
    }
}
