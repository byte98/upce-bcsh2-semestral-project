using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common
{
    /// <summary>
    /// Structure holding information about object stored in file.
    /// </summary>
    public struct FileObject
    {
        /// <summary>
        /// Position of object from the start of the file.
        /// </summary>
        public uint Position { get; init; }

        /// <summary>
        /// Size of object.
        /// </summary>
        public uint Size { get; init; }

        /// <summary>
        /// Creates new structure holding information about object stored in file.
        /// </summary>
        /// <param name="position">Position of object in file.</param>
        /// <param name="size">Size of object.</param>
        public FileObject(uint position, uint size)
        {
            this.Position = position;
            this.Size = size;
        }
    }
}
