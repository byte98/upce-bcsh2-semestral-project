using CommunityToolkit.Mvvm.Messaging.Messages;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class which informs about change of selected schedule.
    /// </summary>
    public class SelectedScheduleGroupChangedMessage : ValueChangedMessage<ScheduleGrouping>
    {
        /// <summary>
        /// Creates new message informing about change of selected schedule.
        /// </summary>
        /// <param name="schedule></param>
        public SelectedScheduleGroupChangedMessage(ScheduleGrouping schedule) : base(schedule) { }
    }
}
