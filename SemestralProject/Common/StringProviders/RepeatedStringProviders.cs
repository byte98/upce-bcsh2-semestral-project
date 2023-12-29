using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// String provider which creates same string repeatedly.
    /// </summary>
    public class RepeatedStringProviders: IStringProvider
    {
        /// <summary>
        /// Source of data.
        /// </summary>
        private readonly IStringProvider source;

        /// <summary>
        /// Number of generated strings.
        /// </summary>
        private int limit;

        /// <summary>
        /// Counter of generated strings.
        /// </summary>
        private int counter = -1;

        /// <summary>
        /// Already generated data from source.
        /// </summary>
        private string[] sourceData;

        /// <summary>
        /// Creats new string provider which creates strings by repeating source strings.
        /// </summary>
        /// <param name="source">Source of strings.</param>
        /// <param name="limit">Number of generated strings.</param>
        public RepeatedStringProviders(IStringProvider source, int limit)
        {
            this.source = source;
            this.limit = limit;
            this.sourceData = this.source.ToArray();
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < this.limit; i++)
            {
                this.counter++;
                yield return this.sourceData[this.counter % this.sourceData.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
