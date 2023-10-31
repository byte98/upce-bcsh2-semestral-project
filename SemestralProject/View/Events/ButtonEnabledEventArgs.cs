using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Class which handles flag, whether button should be enabled or not.
    /// </summary>
    public class ButtonEnabledEventArgs: EventArgs
    {
        /// <summary>
        /// Flag, whether button should be enabled (TRUE) or not (FALSE)
        /// </summary>
        public bool ButtonEnabled { get; init; }

        /// <summary>
        /// Creates new arguments of event which changes enable property of button.
        /// </summary>
        /// <param name="buttonEnabled">Flag, whether button should be enabled.</param>
        public ButtonEnabledEventArgs(bool buttonEnabled)
        {
            this.ButtonEnabled = buttonEnabled;
        }
    }
}
