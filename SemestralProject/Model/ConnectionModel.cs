using Microsoft.Win32;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents data model of
    /// connection to the database.
    /// </summary>
    internal class ConnectionModel: ASimpleModel
    {
        #region Settings path definitions
        /// <summary>
        /// String which represents unknown value.
        /// </summary>
        private const string Unknown = "<neznámý údaj>";

        /// <summary>
        /// Key used to encrypt settings.
        /// </summary>
        private static readonly string SettingsKey = ConfigurationManager.AppSettings.Get("key.db") ?? "password";

        /// <summary>
        /// String which defines path to database settings.
        /// </summary>
        private const string SettingsRoot = "HKEY_CURRENT_USER\\BCSH2_Semestral_project\\dbase";

        /// <summary>
        /// String which represents key in application settings
        /// where server is saved.
        /// </summary>
        private const string ServerSettings = "s";

        /// <summary>
        /// String which represents key in application settings
        /// where port is saved.
        /// </summary>
        private const string PortSettings = "pt";

        /// <summary>
        /// String which represents key in application settings
        /// where username is saved.
        /// </summary>
        private const string UsernameSettings = "u";

        /// <summary>
        /// String which represents key in application settings
        /// where password is saved.
        /// </summary>
        private const string PasswordSettings = "p";

        /// <summary>
        /// String which represents key in application settings
        /// where server is saved.
        /// </summary>
        private const string DatabaseSettings = "d";
        #endregion

        /// <summary>
        /// Attribute with server address of database.
        /// </summary>
        private string server;

        /// <summary>
        /// Attribute with port of database on server.
        /// </summary>
        private string port;

        /// <summary>
        /// Attribute with user name of user which
        /// connects to the database.
        /// </summary>
        private string username;

        /// <summary>
        /// Attribute with password of user which
        /// connects to the database.
        /// </summary>
        private string password;

        /// <summary>
        /// Attribute with name of database.
        /// </summary>
        private string database;

        /// <summary>
        /// Property which holds address of server with database.
        /// </summary>
        public string Server
        {
            get
            {
                return this.server;
            }

            set
            {
                if (value != this.server)
                {
                    this.server = value;
                    this.InvokePropertyChanged(nameof(Server));
                }
            }
        }

        /// <summary>
        /// Property which holds port on which database
        /// application runs.
        /// </summary>
        public string Port
        {
            get
            {
                return this.port;
            }

            set
            {
                if (value != this.port)
                {
                    this.port = value;
                    this.InvokePropertyChanged(nameof(Port));
                }
            }
        }

        /// <summary>
        /// Property which holds name of user
        /// which will be connected to the database.
        /// </summary>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (value != this.username)
                {
                    this.username = value;
                    this.InvokePropertyChanged(nameof(Username));
                }
            }
        }

        /// <summary>
        /// Property which holds password of user
        /// which will be connected to the database.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (value != this.password)
                {
                    this.password = value;
                    this.InvokePropertyChanged(nameof(Password));
                }
            }
        }

        /// <summary>
        /// Property which holds name of database.
        /// </summary>
        public string Database
        {
            get
            {
                return this.database;
            }

            set
            {
                if (value != this.database)
                {
                    this.database = value;
                    this.InvokePropertyChanged(nameof(Database));
                }
            }
        }

        /// <summary>
        /// Creates new model of connection to the database.
        /// </summary>
        /// <param name="server">Name of server on which database application runs.</param>
        /// <param name="port">Port on which database application runs.</param>
        /// <param name="username">Name of user which will be connected to the database.</param>
        /// <param name="password">Password of user which will be connected to the database.</param>
        /// <param name="database">Name of database.</param>
        private ConnectionModel
        (
            string server,
            string port,
            string username,
            string password,
            string database
        )
        {
            this.server = server;
            this.port = port;
            this.username = username;
            this.password = password;
            this.database = database;
        }

        /// <summary>
        /// Loads connection model from application settings.
        /// </summary>
        /// <returns>Model of connection to the database.</returns>
        public static Task<ConnectionModel> Load()
        {
            return Task.Run(() =>
            {
                string server   = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.ServerSettings, (object?) ConnectionModel.Unknown), ConnectionModel.SettingsKey) ?? ConnectionModel.Unknown;
                string port     = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.PortSettings, (object?)ConnectionModel.Unknown), ConnectionModel.SettingsKey) ?? ConnectionModel.Unknown;
                string username = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.UsernameSettings, (object?)ConnectionModel.Unknown), ConnectionModel.SettingsKey) ?? ConnectionModel.Unknown;
                string password = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.PasswordSettings, (object?)ConnectionModel.Unknown), ConnectionModel.SettingsKey) ?? ConnectionModel.Unknown;
                string database = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.DatabaseSettings, (object?)ConnectionModel.Unknown), ConnectionModel.SettingsKey) ?? ConnectionModel.Unknown;
                return new ConnectionModel(
                    server,
                    port,
                    username,
                    password,
                    database
                );
            });
        }

        /// <summary>
        /// Saves connection model to the application settings.
        /// </summary>
        public void Save()
        {
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.ServerSettings, StringUtils.Encrypt(this.server, ConnectionModel.SettingsKey));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.PortSettings, StringUtils.Encrypt(this.port, ConnectionModel.SettingsKey));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.UsernameSettings, StringUtils.Encrypt(this.username, ConnectionModel.SettingsKey));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.PasswordSettings, StringUtils.Encrypt(this.password, ConnectionModel.SettingsKey));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.DatabaseSettings, StringUtils.Encrypt(this.database, ConnectionModel.SettingsKey));
        }
    }
}
