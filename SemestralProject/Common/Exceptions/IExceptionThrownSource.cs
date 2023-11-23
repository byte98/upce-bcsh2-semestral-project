using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.Exceptions
{
    /// <summary>
    /// Interface which abstracts all methods for objects
    /// with ability to throw exceptions.
    /// </summary>
    public interface IExceptionThrownSource
    {
        /// <summary>
        /// Event triggered when exception has been thrown.
        /// </summary>
        public event ExceptionThrownEventHandler? ExceptionThrown;
    }
}
