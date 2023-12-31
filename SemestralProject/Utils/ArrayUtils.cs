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

        /// <summary>
        /// Gets part of array.
        /// </summary>
        /// <param name="array">Array which part will be returned.</param>
        /// <param name="start">Starting position in array.</param>
        /// <param name="length">Length of part.</param>
        /// <returns>Part of array.</returns>
        public static T[] Part(T[] array, int start, int length)
        {
            IList<T> reti = new List<T>();
            int counter = 0;
            for (int i = start; i < array.Length; i++)
            {
                if (counter < length)
                {
                    reti.Add(array[i]);
                    counter++;
                }
                else
                {
                    break;
                }
            }
            return reti.ToArray();
        }
    }
}
