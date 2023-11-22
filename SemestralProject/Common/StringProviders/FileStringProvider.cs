using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which provides whole content of file as string.
    /// </summary>
    public class FileStringProvider : ConstantStringProvider
    {
        /// <summary>
        /// Creates new provider of string which returns whole content of file.
        /// </summary>
        /// <param name="content">Content of file.</param>
        public FileStringProvider(byte[] content) : base(ContentToString(content)) { }

        /// <summary>
        /// Converts content of file to the string.
        /// </summary>
        /// <param name="content">Content of the file.</param>
        /// <returns>String parsed from content of the file.</returns>
        private static string ContentToString(byte[] content)
        {
            return Encoding.UTF8.GetString(content);
        }
    }
}
