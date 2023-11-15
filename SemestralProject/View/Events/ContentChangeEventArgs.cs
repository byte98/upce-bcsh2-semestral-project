using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SemestralProject.View.Events
{
    /// <summary>
    /// Arguments of 'content change' event.
    /// </summary>
    /// <typeparam name="T">Type of any additional data.</typeparam>
    public class ContentChangeEventArgs<T>: EventArgs
    {
        /// <summary>
        /// Aditional data for content change.
        /// </summary>
        public T? Data { get; init; }

        /// <summary>
        /// New content.
        /// </summary>
        public UserControl Control { get; init; }

        /// <summary>
        /// Creates new arguments of 'content change' event.
        /// </summary>
        /// <param name="userControl">New content.</param>
        public ContentChangeEventArgs(UserControl userControl): this(default, userControl) { }

        /// <summary>
        /// Creates new arguments of 'content change' event.
        /// </summary>
        /// <param name="data">Any additional data of event.</param>
        /// <param name="userControl">New content.</param>
        public ContentChangeEventArgs(T? data, UserControl userControl)
        {
            this.Data = data;
            this.Control = userControl;
        }
    }
}
