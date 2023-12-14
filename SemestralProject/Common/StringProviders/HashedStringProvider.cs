using SemestralProject.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// String provider which creates hashed variant of input strings.
    /// </summary>
    public class HashedStringProvider: IStringProvider
    {
        /// <summary>
        /// Source of data.
        /// </summary>
        private readonly IStringProvider source;

        /// <summary>
        /// Creats new string provider which creates hashed strings.
        /// </summary>
        /// <param name="source">Strings which will be hashed.</param>
        public HashedStringProvider(IStringProvider source)
        {
            this.source = source;
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach(string str in this.source)
            {
                yield return StringUtils.Hash(str);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
