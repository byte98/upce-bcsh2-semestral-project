using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Handler of 'form has been filled' event.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Arguments of the event.</param>
    public delegate void FormFilledEventHandler(object sender, FormFilledEventArgs e);
}
