using System;
using System.Collections.Generic;
using System.Text;

namespace SemestralProject.DatabaseObject.DatabaseColummn
{
    /// <summary>
    /// Class which represents property of object which is represented by column in database.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class DatabaseColumnAttribute: Attribute
    {
        /// <summary>
        /// Name of column in database.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Creates new class which represents property of object which is represented by column in database.
        /// </summary>
        /// <param name="name">Name of column in database.</param>
        public DatabaseColumnAttribute(string name)
        {
            this.Name = name;
        }
    }
}
