using CommunityToolkit.Mvvm.Messaging.Messages;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class which informs about employees.
    /// </summary>
    public class InfoEmployeeMessage: ValueChangedMessage<Employee>
    {
        /// <summary>
        /// Creates new message which informs about employee.
        /// </summary>
        /// <param name="employee">Employee about which all receivers will be informed.</param>
        public InfoEmployeeMessage(Employee employee): base(employee) { }
    }
}
