using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SemestralProject.Model
{
    /// <summary>
    /// Structure holding information from hierarchy view.
    /// </summary>
    public struct HierarchyView
    {
        /// <summary>
        /// String displaying level in hierarchy.
        /// </summary>
        public string Level { get; init; }

        /// <summary>
        /// Name of user.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Image of user.
        /// </summary>
        public ImageSource Image {  get; init; }

        /// <summary>
        /// Creates new structure holding information from hierarchy view.
        /// </summary>
        /// <param name="level">String displaying level in hierarchy.</param>
        /// <param name="name">Name of user.</param>
        /// <param name="image">Image of user.</param>
        public HierarchyView(string level, string name, ImageSource image)
        {
            this.Level = level;
            this.Name = name;
            this.Image = image;
        }
    }
}
