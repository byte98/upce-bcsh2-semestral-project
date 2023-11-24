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
    /// Class which informs about actual role of user.
    /// </summary>
    public class InfoRoleMessage: ValueChangedMessage<Role>
    {
        /// <summary>
        /// Creates new message which informs about actual role of user.
        /// </summary>
        /// <param name="role"></param>
        public InfoRoleMessage(Role role) : base(role) { }
    }
}
