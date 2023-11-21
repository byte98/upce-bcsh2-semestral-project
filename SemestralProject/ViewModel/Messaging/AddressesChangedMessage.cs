using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class which represents message informing about available addresses set changed.
    /// </summary>
    public class AddressesChangedMessage: ValueChangedMessage<object?>
    {
        /// <summary>
        /// Creates new message which informs about change of available addresses.
        /// </summary>
        public AddressesChangedMessage() : base(null) { }
    }
}
