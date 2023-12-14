using SemestralProject.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    public class RandomStringProvider : IStringProvider
    {
        /// <summary>
        /// Source of data.
        /// </summary>
        private IStringProvider source;

        /// <summary>
        /// Limit of generated strings.
        /// </summary>
        int limit;

        /// <summary>
        /// Counter of created strings.
        /// </summary>
        int created = 0;

        /// <summary>
        /// Array with source data.
        /// </summary>
        private string[] sourceData;

        /// <summary>
        /// Creates string provider which produces strings in random order.
        /// </summary>
        /// <param name="source">Original source of strings.</param>
        public RandomStringProvider(IStringProvider source) : this(source, source.Count()) { }

        /// <summary>
        /// Creates string provider which produces strings in random order.
        /// </summary>
        /// <param name="source">Original source of strings.</param>
        /// <param name="limit">Limit of generated strings.</param>
        public RandomStringProvider(IStringProvider source, int limit)
        {
            this.limit = limit;
            this.source = source;
            this.sourceData = source.ToArray();
        }

        public IEnumerator<string> GetEnumerator()
        {
            for(int i = 0; i < this.limit; i++)
            {
                yield return ArrayUtils<string>.Random(this.sourceData) ?? string.Empty;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
