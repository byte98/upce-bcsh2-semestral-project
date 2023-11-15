using SemestralProject.View.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Navigation
{
    /// <summary>
    /// Interface abstracting all views with dynamic content.
    /// </summary>
    public interface IDynamicContent<T>
    {
        /// <summary>
        /// Event triggered when content needs to be changed.
        /// </summary>
        public event ContentChangeEventHandler<T>? ContentChange;
    }
}
