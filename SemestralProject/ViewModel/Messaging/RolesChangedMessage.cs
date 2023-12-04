using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class informing about change of roles table.
    /// </summary>
    public class RolesChangedMessage: ValueChangedMessage<object?>
    {
        /// <summary>
        /// Creates new message which informs about change of roles.
        /// </summary>
        public RolesChangedMessage(): base(null) { }
    }
}
