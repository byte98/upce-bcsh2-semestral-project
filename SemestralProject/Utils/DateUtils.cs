using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which contains some utility functions to work with dates.
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// Format of date time used for conversion.
        /// </summary>
        private const string Format = "MM/dd/yyyy HH:mm:ss";

        /// <summary>
        /// Format of date used in SQL queries.
        /// </summary>
        private const string SQLFormat = "MM/DD/YYYY HH24:MI:SS";

        /// <summary>
        /// Converts data to SQL compatible string.
        /// </summary>
        /// <param name="date">Date which will be converted.</param>
        /// <returns>String containing SQL compatible format of date.</returns>
        public static string ToSQL(DateTime date)
        {
            return $"TO_DATE('{date.ToString(DateUtils.Format)}', '{DateUtils.SQLFormat}')";
        }

        /// <summary>
        /// Converts string to date time.
        /// </summary>
        /// <param name="str">String which will be converted.</param>
        /// <returns>Date time with data from string.</returns>
        public static DateTime FromString(string str)
        {
            return DateTime.ParseExact(str, DateUtils.Format, null);
        }
    }
}
