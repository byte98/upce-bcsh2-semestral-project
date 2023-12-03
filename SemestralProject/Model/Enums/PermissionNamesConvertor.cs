using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string[] parts = Regex.Split(name.ToString(), @"(?<!^)(?=[A-Z])");
            if (parts.Length > 0 )
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < parts.Length; i++)
                {
                    sb.Append(parts[i].ToLower());
                    if (i < parts.Length - 1)
                    {
                        sb.Append(".");
                    }
                }
                reti = sb.ToString();
            }
            return reti;
        }
    }
}
