using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// String provider which extends existing string provider by function.
    /// </summary>
    public class FunctionStringProvider : IStringProvider
    {
        /// <summary>
        /// Function which will be applied to output of another string provider.
        /// </summary>
        private readonly Func<string, string> func;

        /// <summary>
        /// Output of this string provider.
        /// </summary>
        private string[] strings;

        /// <summary>
        /// String provider on which output function will be applied.
        /// </summary>
        private readonly IStringProvider provider;

        /// <summary>
        /// Creates new string provider which extends existing string provider and applies function on its output.
        /// </summary>
        /// <param name="func">Function which will be applied to output of another string provider.</param>
        /// <param name="provider">String provider on which output function will be applied.</param>
        public FunctionStringProvider(Func<string, string> func, IStringProvider provider)
        {
            this.func = func;
            strings = new string[0];
            this.provider = provider;
            Apply();
        }

        /// <summary>
        /// Applies function on output of another provider.
        /// </summary>
        private void Apply()
        {
            IList<string> outputs = new List<string>();
            foreach (string str in provider)
            {
                outputs.Add(func(str));
            }
            strings = outputs.ToArray();
        }

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
