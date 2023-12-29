using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represetns large character object.
    /// </summary>
    public class Clob
    {
        /// <summary>
        /// Content of large character object.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Creates new large character object.
        /// </summary>
        public Clob() : this(string.Empty) { }

        /// <summary>
        /// Creates new large character object.
        /// </summary>
        /// <param name="content">Content of character object.</param>
        public Clob(string content)
        { this.Content = content; }
    }
}
