using SemestralProject.View.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Navigation
{
    /// <summary>
    /// Class which abstracts all other classes with ability to request navigation.
    /// </summary>
    public abstract class NavigationSource : INavigationSource
    {
        public event NavigationRequestedEventHandler? NavigationRequested;
        public event NavigationBackEventHandler? NavigationBack;

        /// <summary>
        /// Performs navigation to target.
        /// </summary>
        /// <param name="target">Target of navigation.</param>
        protected void Navigate(object target)
        {
            NavigationRequestedEventArgs args = new NavigationRequestedEventArgs(target);
            this.NavigationRequested?.Invoke(this, args);
        }

        /// <summary>
        /// Performs navigation back.
        /// </summary>
        protected void NavigateBack()
        {
            NavigationBackEventArgs args = new NavigationBackEventArgs();
            this.NavigationBack?.Invoke(this, args);
        }

        /// <summary>
        /// Creates new object with ability to request navigation.
        /// </summary>
        public NavigationSource()
        {
            Navigator navigator = Navigator.Instance;
            navigator.RegisterSource(this);
        }
    }
}
