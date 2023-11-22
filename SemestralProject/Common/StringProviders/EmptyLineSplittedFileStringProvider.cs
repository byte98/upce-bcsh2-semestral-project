using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which provides strings as parts of file splitted by empty lines.
    /// </summary>
    public class EmptyLineSplittedFileStringProvider : IStringProvider
    {
        /// <summary>
        /// Content of file.
        /// </summary>
        private readonly byte[] content;

        /// <summary>
        /// Parts of file.
        /// </summary>
        private string[] parts;

        /// <summary>
        /// Creates new provider of strings which returns parts of file separated by empty lines.
        /// </summary>
        /// <param name="content">Content of file.</param>
        public EmptyLineSplittedFileStringProvider(byte[] content)
        {
            this.content = content;
            parts = new string[0];
            ReadFile();
        }

        /// <summary>
        /// Reads content of file.
        /// </summary>
        private void ReadFile()
        {
            IList<string> fileParts = new List<string>();
            StringBuilder buffer = new StringBuilder();
            string[] lines = Encoding.UTF8.GetString(content).Split(Environment.NewLine);
            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                if (trimmed.Length > 0)
                {
                    buffer.Append(line);
                }
                else
                {
                    if (buffer.Length > 0)
                    {
                        fileParts.Add(buffer.ToString());
                    }
                    buffer.Clear();
                }
            }
            parts = fileParts.ToArray();
        }


        public IEnumerator<string> GetEnumerator()
        {
            foreach (string str in parts)
            {
                yield return str;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return parts.GetEnumerator();
        }
    }
}
