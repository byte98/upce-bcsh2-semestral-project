using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.Exceptions
{
    /// <summary>
    /// Class which dispatches exceptions to all registered receivers.
    /// </summary>
    public class ExceptionDispatcher
    {
        /// <summary>
        /// Lazy loader of dispatcher of all exceptions.
        /// </summary>
        private static Lazy<ExceptionDispatcher> lazy = 
            new Lazy<ExceptionDispatcher>(() => new ExceptionDispatcher());

        /// <summary>
        /// Default exception dispatcher.
        /// </summary>
        public static ExceptionDispatcher Defualt => lazy.Value;

        /// <summary>
        /// List with all possible sources of exceptions.
        /// </summary>
        private readonly IList<IExceptionThrownSource> sources;

        /// <summary>
        /// Receivers of all posible exceptions.
        /// </summary>
        private readonly IList<IExceptionReceiver> receivers;

        /// <summary>
        /// Creates new exception dispatcher.
        /// </summary>
        private ExceptionDispatcher()
        {
            this.sources = new List<IExceptionThrownSource>();
            this.receivers = new List<IExceptionReceiver>();
        }

        /// <summary>
        /// Registers new source of exceptions.
        /// </summary>
        /// <param name="source">Source of exceptions which will be added.</param>
        public void RegisterSource(IExceptionThrownSource source)
        {
            this.sources.Add(source);
            source.ExceptionThrown += this.HandleException;
        }
        
        /// <summary>
        /// Handles 'exception has been thrown' event.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="args">Arguments of event.</param>
        private void HandleException(object sender, ExceptionThrownEventArgs args)
        {
            foreach(IExceptionReceiver receiver in this.receivers)
            {
                receiver.Receive(args.Exception);
            }
        }

        /// <summary>
        /// Registers new receiver of exceptions.
        /// </summary>
        /// <param name="receiver">Receiver of exceptions which will be informed if there is new exception.</param>
        public void RegisterReceiver(IExceptionReceiver receiver)
        {
            this.receivers.Add(receiver);
        }
    }
}
