using SemestralProject.Common;
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
    /// Class which represents state of user.
    /// </summary>
    [DatabaseClass("proc_stavy_create", "func_stavy_read", "proc_stavy_update", "proc_stavy_delete", "stavy_seq", "id_stav")]
    public partial class State
    {
        /// <summary>
        /// Name of state.
        /// </summary>
        [DatabaseColumn("nazev")]
        public string Name { get; set; }

        /// <summary>
        /// Flag, whether user can log in.
        /// </summary>
        [DatabaseColumn("prihlasitelny")]
        public bool Loginable { get; set; }

        /// <summary>
        /// Active state of user.
        /// </summary>
        public static readonly State Active = new State(0, "Aktivní", true);

        /// <summary>
        /// Blocked state of user.
        /// </summary>
        public static readonly State Blocked = new State(1, "Blokovaný", false);

        /// <summary>
        /// Deleted state of user.
        /// </summary>
        public static readonly State Deleted = new State(2, "Smazaný", false);

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
