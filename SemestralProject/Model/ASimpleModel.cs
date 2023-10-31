using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which abstracts all simple data models.
    /// </summary>
    public abstract class ASimpleModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Event invoked when any property has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invokes event notifiing about property change.
        /// </summary>
        /// <param name="propertyName">Name of property which has been changed.</param>
        protected void InvokePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
