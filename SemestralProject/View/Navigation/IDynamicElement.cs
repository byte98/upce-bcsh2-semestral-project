using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Navigation
{
    /// <summary>
    /// Interface abstracting all available elements with dynamic content.
    /// </summary>
    /// <typeparam name="T">Data type associated with change of content.</typeparam>
    interface IDynamicElement<T>
    {
        /// <summary>
        /// Registers source of dynamic content change.
        /// </summary>
        /// <param name="dynamic">Source of dynamic content change.</param>
        public abstract void RegisterDynamicSource(IDynamicContent<T> dynamic);

        /// <summary>
        /// Registers target of data associated with dynamic content change.
        /// </summary>
        /// <param name="target">Target of data when dynamic content is changed.</param>
        public abstract void RegisterTarget(IDynamicTarget<T> target);
    }
}
