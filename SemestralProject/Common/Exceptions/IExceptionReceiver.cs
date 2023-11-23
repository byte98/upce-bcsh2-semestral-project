using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.Exceptions
{
    /// <summary>
    /// Interface abstracting all exception receivers.
    /// </summary>
    public interface IExceptionReceiver
    {
        /// <summary>
        /// Handles receiving of exception.
        /// </summary>
        /// <param name="ex">Exception which should be received.</param>
        public abstract void Receive(Exception ex);
    }
}
