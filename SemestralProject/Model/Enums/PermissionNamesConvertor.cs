using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Enums
{
    /// <summary>
    /// Class which converts enumeration value of
    /// permission name to its real name in database and vice-versa.
    /// </summary>
    public static class PermissionNamesConvertor
    {
        /// <summary>
        /// Converts permission name enumeration value to its real name in database.
        /// </summary>
        /// <param name="name">Enumeration value of permission.</param>
        /// <returns>String representing system name of permission in database.</returns>
        public static string ToName(PermissionNames name)
        {
            string reti = string.Empty;
            switch(name)
            {
                case PermissionNames.ChangeRoleRuntime: reti = "role.change.runtime"; break;
            }
            return reti;
        }
    }
}
