using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.Exceptions
{
    /// <summary>
    /// Class which abstracts all object with ability
    /// to receive information about thrown exception.
    /// </summary>
    public abstract class AbstractExceptionReceiver : IExceptionReceiver
    {
        /// <summary>
        /// Creates new object with ability to
        /// receive thrown exceptions.
        /// </summary>
        public AbstractExceptionReceiver()
        {
            ExceptionDispatcher.Defualt.RegisterReceiver(this);
        }

        public abstract void Receive(Exception ex);
    }
}
