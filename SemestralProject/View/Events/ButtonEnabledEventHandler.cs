using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Definition of delegate which processes change of button enabled property.
    /// </summary>
    /// <param name="sender">Sender of event.</param>
    /// <param name="e">Arguments of event.</param>
    public delegate void ButtonEnabledEventHandler(object sender, ButtonEnabledEventArgs e);
}
