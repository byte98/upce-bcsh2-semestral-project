using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class which informs about users change.
    /// </summary>
    public class UsersChangedMessage: ValueChangedMessage<object?>
    {
        /// <summary>
        /// Creates new message informing about change of users.
        /// </summary>
        public UsersChangedMessage() : base(null) { }
    }
}
