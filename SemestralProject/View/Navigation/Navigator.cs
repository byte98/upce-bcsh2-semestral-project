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
    /// Class which performs navigation.
    /// </summary>
    public sealed class Navigator
    {
        /// <summary>
        /// Lazy loader of navigator.
        /// </summary>
        private static readonly Lazy<Navigator> lazy =
            new Lazy<Navigator>(() => new Navigator());

        /// <summary>
        /// Instance of navigator.
        /// </summary>
        public static Navigator Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// History of navigated objects.
        /// </summary>
        private readonly Stack<object> history;

        /// <summary>
        /// Stack on frames on which can navigation be performed.
        /// </summary>
        private readonly Stack<Frame> frames;

        /// <summary>
        /// Sources of navigation requests.
        /// </summary>
        private readonly IList<INavigationSource> sources;

        /// <summary>
        /// Attribute holding frame in which navigation will be performed.
        /// </summary>
        private Frame? context;

        /// <summary>
        /// Frame in which navigation will be performed.
        /// </summary>
        public Frame? Context
        {
            private get
            {
                return this.context;
            }

            set
            {
                this.history.Clear();
                this.context = value;
                if (this.context != null)
                {
                    this.frames.Push(this.context);
                }
            }
        }

        /// <summary>
        /// Creates new navigator.
        /// </summary>
        private Navigator()
        {
            this.sources = new List<INavigationSource>();
            this.history = new Stack<object>();
            this.frames = new Stack<Frame>();
        }

        /// <summary>
        /// Handles navigation request.
        /// </summary>
        /// <param name="sender">Sender of request.</param>
        /// <param name="e">Arguments of request.</param>
        private void HanldeRequest(object sender, NavigationRequestedEventArgs e)
        {
            if (this.Context != null)
            {
                this.history.Push(e.Target);
                this.Context.NavigationService.Navigate(e.Target);
            }
        }

        /// <summary>
        /// Handles navigation back.
        /// </summary>
        /// <param name="sender">Sender of request.</param>
        /// <param name="e">Arguments of request.</param>
        private void HandleBack(object sender, NavigationBackEventArgs e)
        {
            if (this.Context != null && this.history.Count > 0)
            {
                this.Context.NavigationService.GoBack();
            }
        }

        /// <summary>
        /// Registeres source of navigation requests.
        /// </summary>
        /// <param name="source">Source of navigation requests.</param>
        public void RegisterSource(INavigationSource source)
        {
            this.sources.Add(source);
            source.NavigationRequested += this.HanldeRequest;
            source.NavigationBack      += this.HandleBack;
        }

        /// <summary>
        /// Sets actual context as the previous one.
        /// </summary>
        public void SetPreviousContext()
        {
            if (this.frames.Count > 0)
            {
                //this.frames.Pop();
                //this.context = this.frames.Peek();
                this.context = this.frames.Pop();
            }
        }
    }
}
