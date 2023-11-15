using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Handler of 'navigation requested' event.
    /// </summary>
    /// <param name="sender">Sender of event.</param>
    /// <param name="e">Arguments of event.</param>
    public delegate void NavigationRequestedEventHandler(object sender, NavigationRequestedEventArgs e);
}
