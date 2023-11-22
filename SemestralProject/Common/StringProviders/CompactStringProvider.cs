using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which provides one string as compacted string from other providers.
    /// </summary>
    public class CompactStringProvider : IStringProvider
    {
        /// <summary>
        /// Providers which outputs will be compacted to one string.
        /// </summary>
        private readonly IStringProvider[] providers;

        /// <summary>
        /// Provider of output of compacted string provider.
        /// </summary>
        private ConstantStringProvider output;

        /// <summary>
        /// Creates new provider of one string as compected string from other providers.
        /// </summary>
        /// <param name="providers">Providers which outputs will be compacted to one string.</param>
        public CompactStringProvider(params IStringProvider[] providers)
        {
            output = new ConstantStringProvider(string.Empty);
            this.providers = providers;
            Load();
        }

        /// <summary>
        /// Loads all output from providers and compact them into one string.
        /// </summary>
        private void Load()
        {
            StringBuilder buffer = new StringBuilder();
            foreach (IStringProvider provider in providers)
            {
                foreach (string str in provider)
                {
                    buffer.Append(str);
                }
            }
            output = new ConstantStringProvider(buffer.ToString());
        }

        public IEnumerator<string> GetEnumerator()
        {
            return output.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return output.GetEnumerator();
        }
    }
}
