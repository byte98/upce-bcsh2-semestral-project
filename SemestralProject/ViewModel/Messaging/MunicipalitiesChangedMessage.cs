using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Message informing about change in table with municipalities.
    /// </summary>
    public class MunicipalitiesChangedMessage: ValueChangedMessage<object?>
    {
        /// <summary>
        /// Creates new message informing about change in table with municipalities.
        /// </summary>
        public MunicipalitiesChangedMessage() : base(null) { }
    }
}
