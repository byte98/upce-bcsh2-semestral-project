using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

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
        /// <returns>
        /// Date time with data from string,
        /// or NULL if conversion is not possible.
        /// </returns>
        public static DateTime? FromString(string str)
        {
            DateTime? reti = null;
            DateTime parsed;
            if (DateTime.TryParseExact(str, DateUtils.Format, null, System.Globalization.DateTimeStyles.AssumeUniversal, out parsed) == true)
            {
                reti = parsed;
            }
            return reti;
        }

        /// <summary>
        /// Converts result of query to the date time.
        /// </summary>
        /// <param name="result">Result of query.</param>
        /// <returns>
        /// Date time converted from result of query,
        /// or NULL if conversion is not possible.
        /// </returns>
        public static DateTime? FromQuery(object? result)
        {
            DateTime? reti = null;
            if (result != null)
            {
                if (result.GetType() == typeof(DateTime))
                {
                    reti = (DateTime)result;
                }
                else
                {
                    reti = DateUtils.FromString(result.ToString() ?? string.Empty);
                }
            }
            return reti;
        }
    }
}
