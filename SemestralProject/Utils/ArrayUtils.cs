using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class with utility functions for arrays.
    /// </summary>
    /// <typeparam name="T">Data type of single element in array.</typeparam>
    public static class ArrayUtils<T>
    {
        /// <summary>
        /// Gets random element from array.
        /// </summary>
        /// <param name="array">Array from which random element will be returned.</param>
        /// <returns>Random element from array, or NULL if array is empty.</returns>
        public static T? Random(T[] array)
        {
            T? reti = default(T);
            if (array.Length > 0)
            {
                Random rnd = new Random();
                int idx = rnd.Next(0, array.Length);
                reti = array[idx];
            }
            return reti;
        }
    }
}
