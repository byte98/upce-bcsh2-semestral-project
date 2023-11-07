using SemestralProject.View.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents user of the system.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Identifier of user.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Password of user.
        /// </summary>
        private readonly string password;

        /// <summary>
        /// Date and time of registration of user.
        /// </summary>
        public DateTime Registration { get; init; }

        /// <summary>
        /// Image of user.
        /// </summary>
        public UserImage Image { get; init; }

    }
}
