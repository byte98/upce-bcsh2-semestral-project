using ModernWpf.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common.StringProviders
{
    /// <summary>
    /// Class which provides strings as lines of file.
    /// </summary>
    public class FileLinesStringProvider : SeparatedFileStringProvider
    {
        /// <summary>
        /// Creates new provider of strings as lines of file.
        /// </summary>
        /// <param name="content">Content of file.</param>
        /// <param name="emptyLines">Flag, whether empty lines should be added too.</param>
        public FileLinesStringProvider(byte[] content, bool emptyLines = false)
            : base(content, Environment.NewLine, emptyLines) { }
    }
}
