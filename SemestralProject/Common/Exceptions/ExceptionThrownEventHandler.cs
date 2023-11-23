using SemestralProject.View.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.Exceptions
{
    /// <summary>
    /// Handler of 'exception has been thrown' event.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Arguments of the event.</param>
    public delegate void ExceptionThrownEventHandler(object sender, ExceptionThrownEventArgs e);
}
