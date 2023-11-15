using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Class which represetns arguments of event 'navigation requested'.
    /// </summary>
    public class NavigationRequestedEventArgs: EventArgs
    {
        /// <summary>
        /// Target of navigation.
        /// </summary>
        public object Target { get; init; }

        /// <summary>
        /// Creates new arguments of event 'navigation requested'.
        /// </summary>
        /// <param name="target">Target of navigation.</param>
        public NavigationRequestedEventArgs(object target)
        {
            this.Target = target;
        }
    }
}
