using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Structure which holds information about table column.
    /// </summary>
    public struct TableColumn
    {
        /// <summary>
        /// Name of table column.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Data type of column.
        /// </summary>
        public string DataType { get; init; }

        /// <summary>
        /// Creates new structure which holds information about table column.
        /// </summary>
        /// <param name="name">Name of table column.</param>
        /// <param name="dataType">Data type of column.</param>
        public TableColumn(string name, string dataType)
        {
            this.Name = name;
            this.DataType = dataType;
        }
    }
}
