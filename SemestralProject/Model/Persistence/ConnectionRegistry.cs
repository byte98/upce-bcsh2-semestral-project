using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Structure which holds registry names used 
    /// when saving and loading connection information
    /// to the system.
    /// </summary>
    public struct ConnectionRegistry
    {
        /// <summary>
        /// Path to registry where all data will be saved.
        /// </summary>
        public string Path { get; init; }

        /// <summary>
        /// Name of registry containing address of server where database is located.
        /// </summary>
        public string Server { get; init; }

        /// <summary>
        /// Name of registry containing port on which database runs.
        /// </summary>
        public string Port { get; init; }

        /// <summary>
        /// Name of registry containing name of database of application.
        /// </summary>
        public string Database {  get; init; }

        /// <summary>
        /// Name of registry containing username of user with access to database.
        /// </summary>
        public string Username { get; init; }

        /// <summary>
        /// Name of registry containing password of user with access to database.
        /// </summary>
        public string Password { get; init; }

        /// <summary>
        /// Creates new holder of information about registry paths
        /// of connection to the database.
        /// </summary>
        public ConnectionRegistry() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty) { }

        /// <summary>
        /// Creates new holder of information about registry paths
        /// of connection to the database.
        /// </summary>
        /// <param name="path">Path to registry to which all information will be saved.</param>
        /// <param name="server">Name of registry containing address of server where database is located.</param>
        /// <param name="port">Name of registry containing port on which database runs.</param>
        /// <param name="database">Name of registry containing name of database of application.</param>
        /// <param name="username">Name of registry containing username of user with access to database.</param>
        /// <param name="password">Name of registry containing password of user with access to database.</param>
        public ConnectionRegistry(string path, string server, string port, string database, string username, string password)
        {
            this.Path = path;
            this.Server = server;
            this.Port = port;
            this.Database = database;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// Default registry paths for saving connection information.
        /// </summary>
        public static readonly ConnectionRegistry Default = new ConnectionRegistry(
            "HKEY_CURRENT_USER\\SOFTWARE\\" + (Assembly.GetExecutingAssembly().GetName().Name ?? "BCSH2_SEMESTRAL_PROJECT") + "\\0x0d",
            "0x0a",
            "0x0b",
            "0x0c",
            "0x0d",
            "0x0e"
        );
    }
}
