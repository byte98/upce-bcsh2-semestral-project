using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class rerpesenting message which informs about channge of employees.
    /// </summary>
    class EmployeesChangedMessage : ValueChangedMessage<object?>
    {
        /// <summary>
        /// Creates new message which informs about change of employees.
        /// </summary>
        public EmployeesChangedMessage(): base(null) { }
    }
}
