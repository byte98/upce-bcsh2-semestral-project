using Microsoft.Win32;
using SemestralProject.Model.Persistence;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents data model of
    /// connection to the database.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// String which represents unknown value.
        /// </summary>
        private const string UnknownValue = "<neznámý údaj>";

        /// <summary>
        /// Connection model with unknown data.
        /// </summary>
        public static readonly Connection Unknown = new Connection(
                Connection.UnknownValue,
                Connection.UnknownValue,
                Connection.UnknownValue,
                Connection.UnknownValue,
                Connection.UnknownValue
            );

        /// <summary>
        /// Address of server with database.
        /// </summary>
        public string Server { get; private set; }

        /// <summary>
        /// Port on which is database running.
        /// </summary>
        public string Port { get; private set; }

        /// <summary>
        /// Name of database to which application will connect to.
        /// </summary>
        public string Database {  get; private set; }

        /// <summary>
        /// Username of user with access to database.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Password of user with access to database.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Saver of connection to the system.
        /// </summary>
        private readonly ConnectionSaver saver;

        /// <summary>
        /// Loader of connection from the system.
        /// </summary>
        private readonly ConnectionLoader loader;

        /// <summary>
        /// Creates new model of connection to database.
        /// </summary>
        /// <param name="server">Address of server with database.</param>
        /// <param name="port">Port on which is database running.</param>
        /// <param name="database">Name of database to which application will connect to.</param>
        /// <param name="username">Username of user with access to database.</param>
        /// <param name="password">Password of user with access to database.</param>
        public Connection(string server, string port, string database, string username, string password)
            : this(server, port, database, username, password, ConnectionFormat.Default){}

        /// <summary>
        /// Creates new model of connection to database.
        /// </summary>
        /// <param name="server">Address of server with database.</param>
        /// <param name="port">Port on which is database running.</param>
        /// <param name="database">Name of database to which application will connect to.</param>
        /// <param name="username">Username of user with access to database.</param>
        /// <param name="password">Password of user with access to database.</param>
        /// <param name="format">Format of data which will be saved to the system.</param>
        public Connection(string server, string port, string database, string username, string password, ConnectionFormat format)
        {
            this.Server = server;
            this.Port = port;
            this.Database = database;
            this.Username = username;
            this.Password = password;
            this.saver = new ConnectionSaver(format, this);
            this.loader = new ConnectionLoader(format);
        }

        /// <summary>
        /// Gets unknown connection with specified data format.
        /// </summary>
        /// <param name="format">Fprmat of saved data.</param>
        /// <returns>Unknown connection with specified data format.</returns>
        public static Connection GetUnknownWithFormat(ConnectionFormat format) => new Connection(
            Connection.UnknownValue,
            Connection.UnknownValue,
            Connection.UnknownValue,
            Connection.UnknownValue,
            Connection.UnknownValue,
            format
        );

        /// <summary>
        /// Saves connection information into system.
        /// </summary>
        public void Save()
        {
            this.saver.Save();
        }

        /// <summary>
        /// Saves connection information into system asynchronously.
        /// </summary>
        /// <returns>Task which performs saving information into system.</returns>
        public Task SaveAsync()
        {
            return this.saver.SaveAsync();
        }

        /// <summary>
        /// Loads connection information from the system.
        /// </summary>
        public void Load()
        {
            Connection loaded = this.loader.LoadUnknown();
            if (loaded.IsUnknown() == false)
            {
                this.Server = loaded.Server;
                this.Port = loaded.Port;
                this.Database = loaded.Database;
                this.Username = loaded.Username;
                this.Password = loaded.Password;
            }
        }

        /// <summary>
        /// Loads connection from the system asynchronously.
        /// </summary>
        /// <returns>Task which performs loading connection from the system.</returns>
        public Task LoadAsync()
        {
            return Task.Run(async () =>
            {
                Connection loaded = await this.loader.LoadUnknownAsync();
                if (loaded.IsUnknown() == false)
                {
                    this.Server = loaded.Server;
                    this.Port = loaded.Port;
                    this.Database = loaded.Database;
                    this.Username = loaded.Username;
                    this.Password = loaded.Password;
                }
            });
        }

        /// <summary>
        /// Checks, whether model contains some unknown data.
        /// </summary>
        /// <returns>TRUE, if model contains some unknown data, FALSE otherwise.</returns>
        public bool IsUnknown()
        {
            return (
                this.Server == string.Empty || this.Server == Connection.UnknownValue ||
                this.Port == string.Empty || this.Port == Connection.UnknownValue ||
                this.Username == string.Empty || this.Username == Connection.UnknownValue ||
                this.Password == string.Empty || this.Password == Connection.UnknownValue ||
                this.Database == string.Empty || this.Database == Connection.UnknownValue
            );
        }
    }
}
