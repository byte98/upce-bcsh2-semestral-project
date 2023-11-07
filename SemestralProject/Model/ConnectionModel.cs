using Microsoft.Win32;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents data model of
    /// connection to the database.
    /// </summary>
    public class ConnectionModel: ASimpleModel
    {
        #region Settings path definitions
        /// <summary>
        /// String which represents unknown value.
        /// </summary>
        private const string Unknown = "<neznámý údaj>";

        /// <summary>
        /// Alphabet of characters allowed to use when generating secured key.
        /// </summary>
        private const string KeyAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        /// <summary>
        /// Length of key used to encrypt data stored in registry.
        /// </summary>
        private const int KeyLength = 32;

        /// <summary>
        /// Credential where is stored encryption key.
        /// </summary>
        private static readonly string KeyCredential = (Assembly.GetExecutingAssembly().GetName().Name ?? "BCSH2_SEMESTRAL_PROJECT");

        /// <summary>
        /// String which defines path to database settings.
        /// </summary>
        private static readonly string SettingsRoot = "HKEY_CURRENT_USER\\SOFTWARE\\" + (Assembly.GetExecutingAssembly().GetName().Name ?? "BCSH2_SEMESTRAL_PROJECT") + "\\0x0d";

        /// <summary>
        /// String which represents key in application settings
        /// where server is saved.
        /// </summary>
        private const string ServerSettings = "0x0a";

        /// <summary>
        /// String which represents key in application settings
        /// where port is saved.
        /// </summary>
        private const string PortSettings = "0x0b";

        /// <summary>
        /// String which represents key in application settings
        /// where username is saved.
        /// </summary>
        private const string UsernameSettings = "0x0c";

        /// <summary>
        /// String which represents key in application settings
        /// where password is saved.
        /// </summary>
        private const string PasswordSettings = "0x0d";

        /// <summary>
        /// String which represents key in application settings
        /// where server is saved.
        /// </summary>
        private const string DatabaseSettings = "0x0e";
        #endregion

        /// <summary>
        /// Class which represents arguments of 'connection model changed' event.
        /// </summary>
        public class ConnectionModelChangedEventArgs : EventArgs { }

        /// <summary>
        /// Class which represents handler of 'connection model changed' event.
        /// </summary>
        /// <param name="args">Arguments of event.</param>
        public delegate void ConnectionModelChangedEventHandler(ConnectionModelChangedEventArgs args);

        /// <summary>
        /// Event invoked when connection model has been changed.
        /// </summary>
        public event ConnectionModelChangedEventHandler? ConnectionModelChanged;

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
        /// Connection model with unknown data.
        /// </summary>
        public static readonly ConnectionModel UnknownModel = new ConnectionModel(
                ConnectionModel.Unknown,
                ConnectionModel.Unknown,
                ConnectionModel.Unknown,
                ConnectionModel.Unknown,
                ConnectionModel.Unknown
            );

        /// <summary>
        /// Creates new model of connection to the database.
        /// </summary>
        public ConnectionModel()
            : this(
                 string.Empty,
                 string.Empty,
                 string.Empty,
                 string.Empty,
                 string.Empty
            )
        { }
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
        /// Loads connection model from application settings asynchronously.
        /// </summary>
        /// <returns>Task which results into model of connection to the database.</returns>
        public static Task<ConnectionModel> LoadAsync()
        {
            return Task.Run(() =>
            {
                return ConnectionModel.Load();
            });
        }

        /// <summary>
        /// Loads connection model from application settings.
        /// </summary>
        /// <returns>Model of connection to the database.</returns>
        public static ConnectionModel Load()
        {
            ConnectionModel reti = ConnectionModel.UnknownModel;
            string key = ConnectionModel.GetKey();
            if (key != string.Empty)
            {
                string server = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.ServerSettings, (object?)ConnectionModel.Unknown), key) ?? ConnectionModel.Unknown;
                string port = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.PortSettings, (object?)ConnectionModel.Unknown), key) ?? ConnectionModel.Unknown;
                string username = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.UsernameSettings, (object?)ConnectionModel.Unknown), key) ?? ConnectionModel.Unknown;
                string password = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.PasswordSettings, (object?)ConnectionModel.Unknown), key) ?? ConnectionModel.Unknown;
                string database = StringUtils.Decrypt((string?)Registry.GetValue(ConnectionModel.SettingsRoot, ConnectionModel.DatabaseSettings, (object?)ConnectionModel.Unknown), key) ?? ConnectionModel.Unknown;
                reti = new ConnectionModel(
                    server,
                    port,
                    username,
                    password,
                    database
                );
            }
            return reti;
        }

        /// <summary>
        /// Gets key which encrypts data stored in registry.
        /// </summary>
        /// <returns>String representing key which encrypts data stored in registry.</returns>
        private static string GetKey()
        {
            string reti = string.Empty;
            CredentialManagement.Credential cred = new CredentialManagement.Credential { Target = ConnectionModel.KeyCredential };
            if (cred.Load())
            {
                reti = cred.Password;
            }
            return reti;
        }

        /// <summary>
        /// Generates key for encrypting data in registry.
        /// </summary>
        /// <returns>String which represents key used to encrypt data in registry.</returns>
        private static string RegenerateKey()
        {
            string reti = StringUtils.Random(ConnectionModel.KeyAlphabet, ConnectionModel.KeyLength);
            CredentialManagement.Credential cred = new CredentialManagement.Credential { Target = ConnectionModel.KeyCredential, Password = reti, PersistanceType = CredentialManagement.PersistanceType.LocalComputer };
            cred.Save();
            return reti;
        }

        /// <summary>
        /// Saves connection model to the application settings.
        /// </summary>
        public void Save()
        {
            string key = ConnectionModel.RegenerateKey();
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.ServerSettings, StringUtils.Encrypt(this.server, key));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.PortSettings, StringUtils.Encrypt(this.port, key));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.UsernameSettings, StringUtils.Encrypt(this.username, key));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.PasswordSettings, StringUtils.Encrypt(this.password, key));
            Registry.SetValue(ConnectionModel.SettingsRoot, ConnectionModel.DatabaseSettings, StringUtils.Encrypt(this.database, key));
            this.ConnectionModelChanged?.Invoke(new ConnectionModelChangedEventArgs());
        }

        /// <summary>
        /// Saves connection model asynchronously.
        /// </summary>
        /// <returns>Saving task.</returns>
        public Task SaveAsync()
        {
            return Task.Run(() =>
            {
                this.Save();
            });
        }

        /// <summary>
        /// Checks, whether model contains some unknown data.
        /// </summary>
        /// <returns>TRUE, if model contains some unknown data, FALSE otherwise.</returns>
        public bool IsUnknown()
        {
            return (
                this.server == string.Empty || this.server == ConnectionModel.Unknown ||
                this.port == string.Empty || this.server == ConnectionModel.Unknown ||
                this.username == string.Empty || this.username == ConnectionModel.Unknown ||
                this.password == string.Empty || this.password == ConnectionModel.Unknown ||
                this.database == string.Empty || this.database == ConnectionModel.Unknown
            );
        }
    }
}
