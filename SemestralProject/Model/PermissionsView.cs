using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Structure holding data from permissions view.
    /// </summary>
    public class PermissionsView
    {
        /// <summary>
        /// Role which permissions will be counted.
        /// </summary>
        public Role Role { get; init; }

        /// <summary>
        /// Count of permissions assigned to role.
        /// </summary>
        public int Permissions { get; init; }

        /// <summary>
        /// Creates new structure which holds data from permissions view.
        /// </summary>
        /// <param name="role">Role which permissions will be counted.</param>
        /// <param name="permissions">Count of permissions assigned to role.</param>
        public PermissionsView(Role role, int permissions)
        {
            this.Role = role;
            this.Permissions = permissions;
        }
    }
}
