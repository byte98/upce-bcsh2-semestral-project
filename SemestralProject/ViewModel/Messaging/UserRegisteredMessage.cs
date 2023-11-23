using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Message informing about new registration of user.
    /// </summary>
    public class UserRegisteredMessage: ValueChangedMessage<int>
    {
        /// <summary>
        /// Creates new mesage informing about new registration of user.
        /// </summary>
        /// <param name="personalNumber">Personal number of user.</param>
        public UserRegisteredMessage(int personalNumber) : base(personalNumber) { }
    }
}
