using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which provides strings as parts from file separated by separator.
    /// </summary>
    public class SeparatedFileStringProvider : IStringProvider
    {
        /// <summary>
        /// Separator of parts.
        /// </summary>
        private readonly string separator;

        /// <summary>
        /// Strings provided by this provider.
        /// </summary>
        private string[] strings;

        /// <summary>
        /// Content of file.
        /// </summary>
        private readonly byte[] content;

        /// <summary>
        /// Flag, whether empty parts should be added too.
        /// </summary>
        private readonly bool emptyParts;

        /// <summary>
        /// Creates new provider of strings as parts of file separated by separator.
        /// </summary>
        /// <param name="content">Content of file.</param>
        /// <param name="separator">Separator of parts.</param>
        /// <param name="emptyParts">Flag, whether empty parts should be added too.</param>
        public SeparatedFileStringProvider(byte[] content, string separator, bool emptyParts = false)
        {
            this.content = content;
            this.separator = separator;
            this.emptyParts = emptyParts;
            strings = new string[0];
            Load();
        }

        /// <summary>
        /// Loads parts from file.
        /// </summary>
        private void Load()
        {
            string fileContent = Encoding.UTF8.GetString(content);
            string[] parts = fileContent.Split(separator);
            IList<string> loaded = new List<string>();
            foreach (string part in parts)
            {
                if (emptyParts == true)
                {
                    loaded.Add(part);
                }
                else
                {
                    string trimmed = part.Trim();
                    if (trimmed.Length > 0)
                    {
                        loaded.Add(part);
                    }
                }
            }
            strings = loaded.ToArray();
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
