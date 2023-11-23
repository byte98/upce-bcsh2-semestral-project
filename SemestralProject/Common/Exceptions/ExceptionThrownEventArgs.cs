using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.Exceptions
{
    /// <summary>
    /// Arguments of event 'exception has been thrown'.
    /// </summary>
    public class ExceptionThrownEventArgs: EventArgs
    {
        /// <summary>
        /// Exception which has been thrown.
        /// </summary>
        public Exception Exception { get; init; }

        /// <summary>
        /// Creates new arguments of event 'exception has been thrown'.
        /// </summary>
        /// <param name="exception">Exception which has been thrown.</param>
        public ExceptionThrownEventArgs(Exception exception): base() {  this.Exception = exception; }
    }
}
