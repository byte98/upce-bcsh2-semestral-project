using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Navigation
{
    /// <summary>
    /// Interface abstracting target of changes of dynamic content.
    /// </summary>
    /// <typeparam name="T">Type of data associated with change of dynamic content.</typeparam>
    public interface IDynamicTarget<T>
    {
        /// <summary>
        /// Sets new data associated with dynamic content.
        /// </summary>
        /// <param name="data">New data associated with dynamic content.</param>
        public abstract void SetData(T data);
    }
}
