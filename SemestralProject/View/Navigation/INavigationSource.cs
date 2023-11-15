using SemestralProject.View.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Navigation
{
    /// <summary>
    /// Interface abstracting all other object which can request navigation.
    /// </summary>
    public interface INavigationSource
    {
        /// <summary>
        /// Event triggered when navigation is requested.
        /// </summary>
        public event NavigationRequestedEventHandler? NavigationRequested;

        /// <summary>
        /// Event triggered when navigation back is requested.
        /// </summary>
        public event NavigationBackEventHandler? NavigationBack;
    }
}
