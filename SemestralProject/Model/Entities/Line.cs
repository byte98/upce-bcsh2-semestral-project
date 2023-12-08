using SemestralProject.DatabaseObject.DatabaseClass;
using SemestralProject.DatabaseObject.DatabaseColummn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents one single line.
    /// </summary>
    [DatabaseClass("proc_linky_create", "func_linky_read", "proc_linky_update", "proc_linky_delete", "linky_seq", "id_linka")]
    public partial class Line
    {
        /// <summary>
        /// Code of line.
        /// </summary>
        [DatabaseColumn("kod")]
        public string Code { get; set; } = string.Empty;

        public override string? ToString()
        {
            return this.Code;
        }
    }
}
