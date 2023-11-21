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
            object? view = ViewModelLocator.GetViewToModel(model);
            if (view != null)
            {
                if (view is Window)
                {
                    Window window = (Window)view;
                    window.Close();
                }
            }
        }
    }
}
