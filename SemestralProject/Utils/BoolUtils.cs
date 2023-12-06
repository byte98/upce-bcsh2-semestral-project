using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which contains some utility functions to work with booleans.
    /// </summary>
    public static class BoolUtils
    {
        /// <summary>
        /// Translates reqult of query to the boolean.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool FromQuery(object? result)
        {
            bool reti = false;
            if (result != null)
            {
                if (result is bool)
                {
                    reti = (bool)result;
                }
                else if (result is int)
                {
                    reti = (int)result == 0;
                }
            }
            return reti;
        }

        /// <summary>
        /// Translates bool value to string usable in query.
        /// </summary>
        /// <param name="value">Value which will be translated.</param>
        /// <returns>String representing bool value usable in SQL query.</returns>
        public static string ToQuery(bool value)
        {
            return value == true ? "0" : "1";
        }
    }
}
