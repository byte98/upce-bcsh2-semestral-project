using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which merges multiple string providers by alternating its contents.
    /// </summary>
    public class MergedStringProvider : IStringProvider
    {
        /// <summary>
        /// Providers of strings which content will be alternated.
        /// </summary>
        private readonly IStringProvider[] providers;

        /// <summary>
        /// Strings returned by string provider.
        /// </summary>
        private string[] strings;

        /// <summary>
        /// Creates new merger of string providers which alternates its contents.
        /// </summary>
        /// <param name="providers">Providers of strings which content will be alternated.</param>
        public MergedStringProvider(params IStringProvider[] providers)
        {
            this.providers = providers;
            strings = new string[0];
            Load();
        }

        /// <summary>
        /// Loads contents of string providers and alternates them.
        /// </summary>
        private void Load()
        {
            IList<string> content = new List<string>();
            IList<string[]> loaded = new List<string[]>();
            foreach (IStringProvider provider in providers)
            {
                loaded.Add(provider.ToArray());
            }
            int maxLength = loaded.Max(arr => arr.Length);
            for (int i = 0; i < maxLength; i++)
            {
                foreach (string[] arr in loaded)
                {
                    if (i < arr.Length)
                    {
                        content.Add(arr[i]);
                    }
                }
            }
            strings = content.ToArray();
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
