using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common
{
    /// <summary>
    /// Class which represents provider of constant string.
    /// </summary>
    public class ConstantStringProvider : IStringProvider
    {
        /// <summary>
        /// String which will be returned.
        /// </summary>
        private readonly string str;

        /// <summary>
        /// Creates new provider of constant string.
        /// </summary>
        /// <param name="str">String which will be returned.</param>
        public ConstantStringProvider(string str)
        {
            this.str = str;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return this.str;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
