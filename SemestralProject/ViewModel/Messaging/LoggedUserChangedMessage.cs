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
    /// Message informing about change of logged user.
    /// </summary>
    public class LoggedUserChangedMessage: ValueChangedMessage<User>
    {
        /// <summary>
        /// Creates new message informing about change of logged user.
        /// </summary>
        /// <param name="user">New logged user.</param>
        public LoggedUserChangedMessage(User user): base(user) { }
    }
}
