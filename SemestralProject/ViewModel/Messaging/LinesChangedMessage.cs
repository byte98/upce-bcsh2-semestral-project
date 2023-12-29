using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class informing about change of lines.
    /// </summary>
    public class LinesChangedMessage: ValueChangedMessage<object?>
    {
        /// <summary>
        /// Creates new message informing abot change of lines.
        /// </summary>
        public LinesChangedMessage() : base(null) { }
    }
}
