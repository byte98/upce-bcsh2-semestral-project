using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which holds data from users view.
    /// </summary>
    public struct UsersView
    {
        /// <summary>
        /// User from view.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// Masked e-mail of user.
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Masked phone number of user.
        /// </summary>
        public string Phone { get; init; }

        /// <summary>
        /// Creates new structure whihc hodls data from users view.
        /// </summary>
        /// <param name="user">User from view.</param>
        /// <param name="email">Masked e-mail of user.</param>
        /// <param name="phone">Masked phone number of user.</param>
        public UsersView(User user, string email, string phone)
        {
            this.User = user;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
