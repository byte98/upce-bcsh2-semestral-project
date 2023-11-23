using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which performs saving to Window Registry.
    /// </summary>
    public class RegistrySaver
    {
        /// <summary>
        /// Path to registry where all data will be saved.
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Creates new saver of data to registry.
        /// </summary>
        /// <param name="path">Path to registry where all data will be saved.</param>
        public RegistrySaver(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Saves data to registry.
        /// </summary>
        /// <param name="name">Name of value.</param>
        /// <param name="value">Value which will be saved.</param>
        public void Save(string name, object value)
        {
            Registry.SetValue(this.path, name, value);
        }

        /// <summary>
        /// Saves data to registry asynchronously.
        /// </summary>
        /// <param name="name">Name of value.</param>
        /// <param name="value">Value which will be saved.</param>
        /// <returns>Task which performs saving to registry.</returns>
        public Task SaveAsync(string name, object value)
        {
            return Task.Run(() =>
            {
                this.Save(name, value);
            });
        }
    }
}
