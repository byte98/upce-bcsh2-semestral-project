using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which provides no strings at all.
    /// </summary>
    public class EmptyStringProvider : IStringProvider
    {
        /// <summary>
        /// Empty array of strings.
        /// </summary>
        private readonly string[] strings = new string[0];

        /// <summary>
        /// Creates new string provider which provides no strings at all.
        /// </summary>
        public EmptyStringProvider() { }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string str in strings)
            {
                yield return str;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
