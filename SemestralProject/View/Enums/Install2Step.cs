using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.View.Enums
{
    /// <summary>
    /// Enumeration of all steps of second stage of installation.
    /// </summary>
    public enum Install2Step
    {
        /// <summary>
        /// Step in which connection to the database is tested.
        /// </summary>
        Connection,

        /// <summary>
        /// Step in which actual database is deleted.
        /// </summary>
        Deletion,

        /// <summary>
        /// Step in which are created sequences.
        /// </summary>
        Sequences,

        /// <summary>
        /// Step in which are created tables.
        /// </summary>
        Tables,

        /// <summary>
        /// Step in which are created relations.
        /// </summary>
        Relations,

        /// <summary>
        /// Step in which are created data.
        /// </summary>
        Data,

        /// <summary>
        /// Step in which are created packages.
        /// </summary>
        Packages,

        /// <summary>
        /// Step in which are created triggers.
        /// </summary>
        Triggers
    }
}
