using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Handler of 'content change' event.
    /// </summary>
    /// <typeparam name="T">Type of any additional data sent together with event.</typeparam>
    /// <param name="sender">Sender of event.</param>
    /// <param name="e">Arguments of event.</param>
    public delegate void ContentChangeEventHandler<T>(object sender, ContentChangeEventArgs<T> e);
}
