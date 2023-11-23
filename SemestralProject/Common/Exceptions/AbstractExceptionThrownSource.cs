using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.Exceptions
{
    /// <summary>
    /// Class which abstracts all object with ability to throw exception.
    /// </summary>
    public class AbstractExceptionThrownSource : IExceptionThrownSource
    {
        public event ExceptionThrownEventHandler? ExceptionThrown;

        /// <summary>
        /// Creates new object with ability to throw exceptions.
        /// </summary>
        public AbstractExceptionThrownSource()
        {
            ExceptionDispatcher.Defualt.RegisterSource(this);
        }

        /// <summary>
        /// Informs everyone about thrown exception.
        /// </summary>
        /// <param name="exception">Exception which has been thrown.</param>
        protected void ThrowException(Exception exception)
        {
            this.ExceptionThrown?.Invoke(this, new ExceptionThrownEventArgs(exception));
        }
    }
}
