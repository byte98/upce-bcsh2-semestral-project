using SemestralProject.Common;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Structure which holds data for installation.
    /// </summary>
    public struct InstallationModel
    {
        /// <summary>
        /// Model of connection.
        /// </summary>
        public InstallationConnectionModel Connection { get; init; } = new InstallationConnectionModel();

        /// <summary>
        /// Model of user.
        /// </summary>
        public InstallationUserModel User { get; init; }

        /// <summary>
        /// Instance of connection to the database.
        /// </summary>
        public IConnection? Database {get; init;}

        /// <summary>
        /// Creates new data model for installer.
        /// </summary>
        /// <param name="server">Server on which database runs.</param>
        /// <param name="port">Port on which database runs.</param>
        /// <param name="database">Name of database.</param>
        /// <param name="username">Username of user with access to database.</param>
        /// <param name="password">Password of user. </param>
        public InstallationModel(string server, string port, string database, string username, string password)
        {
            this.Database = null;
            this.Connection = new InstallationConnectionModel(
                server, port, database, username, password
            );
            this.User = new InstallationUserModel();
        }

        /// <summary>
        /// Creates new data model for installer.
        /// </summary>
        /// <param name="database">Connection to the database.</param>
        /// <param name="connection">Model of connection to the database.</param>
        public InstallationModel(IConnection database, InstallationConnectionModel connection)
        {
            this.Database = database;
            this.Connection = new InstallationConnectionModel(
                connection.Server, connection.Port, connection.Database, connection.Username, connection.Password
            );
            this.User = new InstallationUserModel();
        }

        /// <summary>
        /// Creates new data model for installer.
        /// </summary>
        /// <param name="database">Connection to the database.</param>
        /// <param name="name">Name of user.</param>
        /// <param name="surname">Surname of user.</param>
        /// <param name="email">E-mail of user.</param>
        /// <param name="phone">Phone number of user.</param>
        /// <param name="password">Password of user.</param>
        /// <param name="personalNumber">Personal number of user.</param>
        /// <param name="image">Image of user.</param>
        /// <param name="address">Address of residence of user.</param>
        public InstallationModel(
            IConnection database,
            string name,
            string surname,
            string email,
            string phone,
            string password,
            int personalNumber,
            ImageFile image,
            Address? address)
        {
            this.Database = database;
            this.Connection = new InstallationConnectionModel();
            this.User = new InstallationUserModel(
                name, surname, email, phone, password, personalNumber, image, address
            );
        }
    }
}
