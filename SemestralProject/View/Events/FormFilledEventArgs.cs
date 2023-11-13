using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Arguments of event 'form has been filled'.
    /// </summary>
    public class FormFilledEventArgs
    {
        /// <summary>
        /// Flag, whether form is filled (TRUE) or not(FALSE).
        /// </summary>
        public bool IsFilled { get; init; }

        /// <summary>
        /// Creates new argumets for event 'form has been filled'.
        /// </summary>
        /// <param name="isFilled">Flag, whether form is filled.</param>
        public FormFilledEventArgs(bool isFilled)
        {
            this.IsFilled = isFilled;
        }
    }
}
