using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents entity with asynchronous actions.
    /// </summary>
    public abstract class AsynchronousEntity: Entity
    {

        /// <summary>
        /// Updates entity asynchronously.
        /// </summary>
        /// <returns>
        /// Task which results into:
        /// TRUE if entity has been successfully updated,
        /// FALSE otherwise.
        /// </returns>
        public virtual Task<bool> UpdateAsync()
        {
            return Task.Run(() => this.Update());
        }

        /// <summary>
        /// Deletes entity asynchronously.
        /// </summary>
        /// <returns>
        /// Task, which resolves into:
        /// TRUE if entity has been deleted,
        /// FALSE otherwise.
        /// </returns>
        public virtual Task<bool> DeleteAsync()
        {
            return Task<bool>.Run(() => this.Delete());
        }
    }
}
