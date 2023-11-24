using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Enums
{
    /// <summary>
    /// Enumeration of all available system names of permissions.
    /// </summary>
    public enum PermissionNames
    {
        /// <summary>
        /// Permission of changing role during program runtime.
        /// </summary>
        ChangeRoleRuntime,

        /// <summary>
        /// Permission of changing own role.
        /// </summary>
        ChangeRoleOwn,

        /// <summary>
        /// Permission of changing own user data.
        /// </summary>
        ChangeUserOwn,

        /// <summary>
        /// Permission of changing own personal number.
        /// </summary>
        ChangePersonalNumberOwn,

        /// <summary>
        /// Permission of changing date of registration.
        /// </summary>
        ChangeRegistrationDateOwn,

        /// <summary>
        /// Permission of changing employment date.
        /// </summary>
        ChangeEmploymentDateOwn
    }
}
