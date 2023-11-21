using SemestralProject.Common;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Structure which holds model for createing user when installation is in process.
    /// </summary>
    public struct InstallationUserModel
    {
        /// <summary>
        /// Name of user.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Surname of user.
        /// </summary>
        public string Surname { get; init; }

        /// <summary>
        /// E-mail of user.
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Phone of user.
        /// </summary>
        public string Phone { get; init; }

        /// <summary>
        /// Password of user.
        /// </summary>
        public string Password { get; init; }

        /// <summary>
        /// Personal number of user.
        /// </summary>
        public int PersonalNumber { get; init; }

        /// <summary>
        /// Image of user.
        /// </summary>
        public UserImage Image { get; init; }

        /// <summary>
        /// Address of residence of user.
        /// </summary>
        public Address? Address { get; init; }

        /// <summary>
        /// Creates new user model used for installation.
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <param name="surname">Surname of user.</param>
        /// <param name="email">E-mail of user.</param>
        /// <param name="phone">Phone number of user.</param>
        /// <param name="password">Password of user.</param>
        /// <param name="personalNumber">Personal number of user.</param>
        /// <param name="image">Image of user.</param>
        /// <param name="address">Address of residence of user.</param>
        public InstallationUserModel(
            string name,
            string surname,
            string email,
            string phone,
            string password,
            int personalNumber,
            UserImage image,
            Address? address)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
            this.Password = password;
            this.PersonalNumber = personalNumber;
            this.Image = image;
            this.Address = address;
        }

        /// <summary>
        /// Creates new user model used for installation.
        /// </summary>
        public InstallationUserModel() : this(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            int.MinValue,
            UserImage.Default,
            null
        )
        { }
    }
}
