using SemestralProject.View.Events;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SemestralProject.View.Components
{
    /// <summary>
    /// Class which represents element with dynamic content.
    /// </summary>
    /// <typeparam name="T">Type of data associated with dynamic content change.</typeparam>
    public abstract class DynamicElement<T>: IDynamicElement<T>
    {
        /// <summary>
        /// Control which content will be dynamically changed.
        /// </summary>
        private ContentControl? contentControl;

        /// <summary>
        /// Sources of changes of content.
        /// </summary>
        private readonly IList<IDynamicContent<T>> dynamics;

        /// <summary>
        /// Data target of changes.
        /// </summary>
        private IList<IDynamicTarget<T>> targets;
        /// <summary>
        /// Creates new element with dynamic content.
        /// </summary>
        public DynamicElement()
        {
            this.dynamics = new List<IDynamicContent<T>>();
            this.targets = new List<IDynamicTarget<T>>();
        }

        /// <summary>
        /// Initializes element with dynamic content.
        /// </summary>
        /// <param name="contentControl">Control which content will be dynamically changed.</param>
        /// <param name="target">Data target of changes.</param>
        protected void Initialize(ContentControl contentControl)
        {
            this.contentControl = contentControl;
        }

        /// <summary>
        /// Handles dynamic content change.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Arguments of event.</param>
        private void HandleDynamicChange(object sender, ContentChangeEventArgs<T> e)
        {
            if (this.contentControl != null)
            {
                this.contentControl.Content = e.Control;
            }       
            if (e.Data != null)
            {
                this.NotifyTargets(e.Data);
            }
        }

        /// <summary>
        /// Notifies targets about data change.
        /// </summary>
        /// <param name="data">Data sent to targets.</param>
        private void NotifyTargets(T data)
        {
            foreach(IDynamicTarget<T> target in this.targets)
            {
                target.SetData(data);
            }
        }

        public void RegisterDynamicSource(IDynamicContent<T> dynamic)
        {
            this.dynamics.Add(dynamic);
            dynamic.ContentChange += HandleDynamicChange;
        }


        public void RegisterTarget(IDynamicTarget<T> target)
        {
            this.targets.Add(target);
        }
    }
}
