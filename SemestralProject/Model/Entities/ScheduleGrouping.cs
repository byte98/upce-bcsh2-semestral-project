using SemestralProject.DatabaseObject.DatabaseColummn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    public class ScheduleGrouping
    {

        public ScheduleGrouping(Line line)
        {
            this.Line = line;
        }


        /// <summary>
        /// List of schedules.
        /// </summary>
        public List<Schedule> Schedules { get; set; } = new();

        /// <summary>
        /// Line of the schedules.
        /// </summary>
        public Line Line { get; set; }
    }
}
