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
    /// Class which represents message which informs about change of selected address.
    /// </summary>
    public class SelectedAddressChangedMessage: ValueChangedMessage<Address>
    {
        /// <summary>
        /// Creates new message which informs about change of selected address.
        /// </summary>
        /// <param name="address">Actually selected address.</param>
        public SelectedAddressChangedMessage(Address address): base(address) { }
    }
}
