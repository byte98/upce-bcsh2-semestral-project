using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.Common
{
    /// <summary>
    /// Class which connects views with its view models.
    /// </summary>
    public static class ViewModelLocator
    {
        /// <summary>
        /// Dictionary of view models to its views.
        /// </summary>
        private static readonly IDictionary<string, object> modelsToView = new Dictionary<string, object>();

        /// <summary>
        /// Dictionary of views to its view models.
        /// </summary>
        private static readonly IDictionary<string, object> viewsToModels = new Dictionary<string, object>();


        #region Implementation of AutoHookedUp XAML property
        public static bool GetAutoHookedUpViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoHookedUpViewModelProperty);
        }

        public static void SetAutoHookedUpViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoHookedUpViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoHookedUpViewModelProperty =
           DependencyProperty.RegisterAttached("AutoHookedUpViewModel",
           typeof(bool), typeof(ViewModelLocator), new
           PropertyMetadata(false, AutoHookedUpViewModelChanged));

        private static void AutoHookedUpViewModelChanged(DependencyObject d,
         DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d)) return;
            object? viewModel = ViewModelLocator.GetModel(d);
            ((FrameworkElement)d).DataContext = viewModel;
        }
        #endregion

        /// <summary>
        /// Gets name of model for view.
        /// </summary>
        /// <param name="viewName">Name of view.</param>
        /// <returns>String representing model name for view.</returns>
        private static string GetModelName(string viewName)
        {
            string reti = new string(viewName);
            if (reti.EndsWith("View"))
            {
                reti = reti.Substring(0, reti.Length - "View".Length);
            }
            reti = reti.Replace(".View.", ".ViewModel.");
            reti = reti + "ViewModel";
            return reti;
        }

        /// <summary>
        /// Gets model for view.
        /// </summary>
        /// <param name="view">Instance of view.</param>
        /// <returns>
        /// New instance of model for view,
        /// or NULL if something bad happened.
        /// </returns>
        private static object? GetModel(object? view)
        {
            object? reti = null;
            if (view != null)
            {
                reti = ViewModelLocator.GetModel(view.GetType());
                if (reti != null && reti.GetType() != null)
                {
                    string? modelName = reti.GetType().FullName;
                    if (modelName != null)
                    {
                        ViewModelLocator.SetView(modelName, view);
                    }
                }
            }
            return reti;
        }

        /// <summary>
        /// Gets model for view.
        /// </summary>
        /// <param name="viewType">Type of view.</param>
        /// <returns>
        /// New instance of model for view,
        /// or NULL if something bad happened.
        /// </returns>
        private static object? GetModel(Type? viewType)
        {
            object? reti = null;
            if (viewType != null)
            {
                reti = ViewModelLocator.GetModel(viewType.FullName);
            }
            return reti;
        }

        /// <summary>
        /// Gets model for view.
        /// </summary>
        /// <param name="viewName">Name of view.</param>
        /// <returns>
        /// New instance of model for view,
        /// or NULL if something bad happened.
        /// </returns>
        private static object? GetModel(string? viewName)
        {
            object? reti = null;
            if (viewName != null)
            {
                string modelName = ViewModelLocator.GetModelName(viewName);
                Type? modelType = Type.GetType(modelName, false);
                if (modelType != null)
                {
                    reti = Activator.CreateInstance(modelType);
                    if (reti != null)
                    {
                        ViewModelLocator.SetModel(viewName, reti);
                    }
                }
            }
            return reti;
        }

        /// <summary>
        /// Sets model for view.
        /// </summary>
        /// <param name="view">Name of view.</param>
        /// <param name="model">Model of view.</param>
        private static void SetModel(string view, object model)
        {
            if (ViewModelLocator.viewsToModels.ContainsKey(view))
            {
                ViewModelLocator.viewsToModels.Remove(view);
            }
            ViewModelLocator.viewsToModels.Add(view, model);
        }

        /// <summary>
        /// Sets view for model.
        /// </summary>
        /// <param name="model">Name of model.</param>
        /// <param name="view">View of model.</param>
        private static void SetView(string model, object view)
        {
            if (ViewModelLocator.modelsToView.ContainsKey(model))
            {
                ViewModelLocator.modelsToView.Remove(model);
            }
            ViewModelLocator.modelsToView.Add(model, view);
        }

        /// <summary>
        /// Gets view connected with model.
        /// </summary>
        /// <param name="model">View model of view.</param>
        /// <returns>
        /// Object representing view connected to view model,
        /// or NULL if there is no such view.
        /// </returns>
        public static object? GetViewToModel(object model)
        {
            object? reti = null;
            Type modelType = model.GetType();
            string? modelName = modelType.FullName;
            if (modelName != null)
            {
                if (ViewModelLocator.modelsToView.ContainsKey(modelName))
                {
                    reti = ViewModelLocator.modelsToView[modelName];
                }
            }
            return reti;
        }
    }
}
