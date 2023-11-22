using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which combines multiple string providers.
    /// </summary>
    public class CombinedStringProvider : IStringProvider
    {
        /// <summary>
        /// All wrapped string providers.
        /// </summary>
        private readonly IStringProvider[] providers;

        /// <summary>
        /// Strings returned by string provider.
        /// </summary>
        private string[] strings;

        /// <summary>
        /// Creates new string provider which combines multiple string providers.
        /// </summary>
        /// <param name="providers">String provider which will be combined.</param>
        public CombinedStringProvider(params IStringProvider[] providers)
        {
            this.providers = providers;
            strings = new string[0];
            LoadStrings();
        }

        /// <summary>
        /// Loads strings from all string providers.
        /// </summary>
        private void LoadStrings()
        {
            IList<string> providedStrings = new List<string>();
            foreach (IStringProvider provider in providers)
            {
                foreach (string str in provider)
                {
                    providedStrings.Add(str);
                }
            }
            strings = providedStrings.ToArray();
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
