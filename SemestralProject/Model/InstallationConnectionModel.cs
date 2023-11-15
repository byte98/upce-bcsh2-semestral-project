using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Structure holding data of connection for installer.
    /// </summary>
    public struct InstallationConnectionModel
    {
        /// <summary>
        /// Server on which database runs.
        /// </summary>
        public string Server { get; init; }

        /// <summary>
        /// Port on which database runs.
        /// </summary>
        public string Port { get; init; }

        /// <summary>
        /// Name of database.
        /// </summary>
        public string Database { get; init; }

        /// <summary>
        /// Username of user with access to database.
        /// </summary>
        public string Username { get; init; }

        /// <summary>
        /// Password of user. 
        /// </summary>
        public string Password { get; init; }

        /// <summary>
        /// Creates new connection data model for installer.
        /// </summary>
        /// <param name="server">Server on which database runs.</param>
        /// <param name="port">Port on which database runs.</param>
        /// <param name="database">Name of database.</param>
        /// <param name="username">Username of user with access to database.</param>
        /// <param name="password">Password of user. </param>
        public InstallationConnectionModel(string server, string port, string database, string username, string password)
        {
            this.Server = server;
            this.Port = port;
            this.Database = database;
            this.Username = username;
            this.Password = password;
        }


    }
}
