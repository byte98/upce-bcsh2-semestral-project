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
    /// Message which informs about actually logged user.
    /// </summary>
    public class InfoUserMessage: ValueChangedMessage<User>
    {
        /// <summary>
        /// Informs about actually logged user.
        /// </summary>
        /// <param name="user">Actually logged user.</param>
        public InfoUserMessage(User user) :base(user) { }
    }
}
