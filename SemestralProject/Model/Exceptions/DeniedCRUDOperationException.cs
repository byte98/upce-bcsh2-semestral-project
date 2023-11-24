using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Exceptions
{
    /// <summary>
    /// Exception informing about fact, that performed CRUD operation is denied.
    /// </summary>
    public class DeniedCRUDOperationException: Exception
    {
        /// <summary>
        /// Creates new exception informing about fact, that performaed CRUD operation is denied.
        /// </summary>
        /// <param name="entity">Entity on which operation has been made.</param>
        /// <param name="operation">Name of operation which has been performed.</param>
        public DeniedCRUDOperationException(Entity entity, string operation)
            : base("Model exception: Operation '" + operation + "' on '" + entity.GetType().Name + "' is denied!") { }
    }
}
