using SemestralProject.View.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SemestralProject.View.Navigation
{
    /// <summary>
    /// Class which abstracts all other classes with dynamic content.
    /// </summary>
    /// <typeparam name="T">Type of data sent with content change.</typeparam>
    public abstract class DynamicContent<T> : IDynamicContent<T>
    {
        public event ContentChangeEventHandler<T>? ContentChange;

        /// <summary>
        /// Changes content of dynamic content.
        /// </summary>
        /// <param name="control">New content of dynamic content.</param>
        protected void ChangeContent(UserControl control)
        {
            this.ContentChange?.Invoke(this, new ContentChangeEventArgs<T>(control));
        }

        /// <summary>
        /// Changes content of dynamic content.
        /// </summary>
        /// <param name="control">New content of dynamic content.</param>
        /// <param name="data">Data associated with content change.</param>
        protected void ChangeContent(UserControl control, T data)
        {
            this.ContentChange?.Invoke(this, new ContentChangeEventArgs<T>(data, control));
        }
    }
}
