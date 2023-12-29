using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class representing message which informs about change of stops.
    /// </summary>
    public class StopsChangedMessage: ValueChangedMessage<object?>
    {
        /// <summary>
        /// Creates new message informing about change of stops.
        /// </summary>
        public StopsChangedMessage() : base(null) { }
    }
}
