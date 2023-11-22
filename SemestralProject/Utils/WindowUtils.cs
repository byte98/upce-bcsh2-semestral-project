using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which contains some windows utility functions.
    /// </summary>
    public static class WindowUtils
    {
        /// <summary>
        /// Closes window connected with view model.
        /// </summary>
        /// <param name="model">View model for which window will be closed.</param>
        public static void CloseForModel(object model)
        {
            Window? window = WindowUtils.GetWindowForModel(model);
            if (window != null)
            {
                window.Close();
            }
        }

        /// <summary>
        /// Closes window connected with view model.
        /// </summary>
        /// <param name="modelType">Data type of model for which window will be closed.</param>
        public static void CloseForModel(Type modelType)
        {
            Window? window = WindowUtils.GetWindowForModel(modelType);
            if (window != null)
            {
                window.Close();
            }
        }

        /// <summary>
        /// Hides window connected with view model.
        /// </summary>
        /// <param name="model">View model which window will be hidden.</param>
        public static void HideForModel(object model)
        {
            Window? window = WindowUtils.GetWindowForModel(model);
            if (window != null)
            {
                window.Hide();
            }
        }

        /// <summary>
        /// Shows window connected with view model.
        /// </summary>
        /// <param name="model">View model which window will be shown.</param>
        public static void ShowForModel(object model)
        {
            Window? window = WindowUtils.GetWindowForModel(model);
            if (window != null)
            {
                window.Show();
            }
        }

        /// <summary>
        /// Minimizes window connected with view model.
        /// </summary>
        /// <param name="model">View model which window will be minimized.</param>
        public static void MinimizeForModel(object model)
        {
            Window? window = WindowUtils.GetWindowForModel(model);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }


        /// <summary>
        /// Maximizes window connected with view model.
        /// </summary>
        /// <param name="model">View model which window will be maximized.</param>
        public static void MaximizeForModel(object model)
        {
            Window? window = WindowUtils.GetWindowForModel(model);
            if (window != null)
            {
                window.WindowState = WindowState.Maximized;
            }
        }
        /// <summary>
        /// Gets window connected with model.
        /// </summary>
        /// <param name="model">Model which window will be searched.</param>
        /// <returns>Window connected with searched model, or NULL if there is no such window.</returns>
        private static Window? GetWindowForModel(object model)
        {
            Window? reti = null;
            object? view = ViewModelLocator.GetViewToModel(model);
            if (view != null)
            {
                if (view is Window)
                {
                    reti = (Window)view;
                }
            }
            return reti;
        }

        /// <summary>
        /// Gets window connected with model.
        /// </summary>
        /// <param name="modelType">Data type of model which window will be searched.</param>
        /// <returns>Window connected with searched model, or NULL if there is no such window.</returns>
        private static Window? GetWindowForModel(Type modelType)
        {
            Window? reti = null;
            object? view = ViewModelLocator.GetViewToModel(modelType);
            if (view != null)
            {
                if (view is Window)
                {
                    reti = (Window)view;
                }
            }
            return reti;
        }
    }
}

