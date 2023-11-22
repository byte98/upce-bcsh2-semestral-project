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
    /// Message informing about change of logged user role.
    /// </summary>
    public class LoggedRoleChangedMessage: ValueChangedMessage<Role>
    {
        /// <summary>
        /// Creates new message informing about change of logged user role.
        /// </summary>
        /// <param name="role">New role of user.</param>
        public LoggedRoleChangedMessage(Role role): base(role) { }
    }
}
