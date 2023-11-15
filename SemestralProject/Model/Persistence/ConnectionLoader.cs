using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which performs loading of connection information from the system.
    /// </summary>
    public class ConnectionLoader
    {
        /// <summary>
        /// Format of saved data.
        /// </summary>
        private readonly ConnectionFormat format;

        /// <summary>
        /// Creates new connection loader.
        /// </summary>
        /// <param name="format">Format of data saved to the system.</param>
        public ConnectionLoader(ConnectionFormat format)
        {
            this.format = format;
        }

        /// <summary>
        /// Loads connection from system.
        /// </summary>
        /// <returns>
        /// Connection loaded from system,
        /// or NULL if connection cannot be loaded.
        /// </returns>
        public Connection? Load()
        {
            Connection? reti = null;
            string? key = this.LoadKey();
            if (key != null)
            {
                DecryptedConnection decrypted = this.LoadRegistry();
                decrypted.Decrypt(key);
                reti = decrypted.Connection;
            }
            return reti;
        }

        /// <summary>
        /// Loads connection from system asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// connection loaded from system,
        /// or NULL if connection cannot be loaded.
        /// </returns>
        public Task<Connection?> LoadAsync()
        {
            return Task<Connection?>.Run(async () =>
            {
                Connection? reti = null;
                string? key = await this.LoadKeyAsync();
                if (key != null)
                {
                    DecryptedConnection decrypted = await this.LoadRegistryAsync();
                    await decrypted.DecryptAsync(key);
                    reti = decrypted.Connection;
                }
                return reti;
            });
        }

        /// <summary>
        /// Loads connection from system.
        /// </summary>
        /// <returns>
        /// Connection loaded from system,
        /// or <see cref="Connection.Unknown"/> if connection cannot be loaded.
        /// </returns>
        public Connection LoadUnknown()
        {
            Connection reti = Connection.Unknown;
            Connection? loaded = this.Load();
            if (loaded != null)
            {
                reti = loaded;
            }
            return reti;
        }

        /// <summary>
        /// Loads connection from system asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// connection loaded from system,
        /// or <see cref="Connection.Unknown"/> if connection cannot be loaded.
        /// </returns>
        public Task<Connection> LoadUnknownAsync()
        {
            return Task<Connection>.Run(async () =>
            {
                Connection reti = Connection.Unknown;
                Connection? loaded = await this.LoadAsync();
                if (loaded != null)
                {
                    reti = loaded;
                }
                return reti;
            });
        }

        /// <summary>
        /// Loads key which will be used data decryption.
        /// </summary>
        /// <returns>
        /// String representing key which can be used for data decryption,
        /// or NULL if key cannot be loaded.
        /// </returns>
        private string? LoadKey()
        {
            string? reti = null;
            CredentialManagement.Credential credential = new CredentialManagement.Credential
            {
                Target = this.format.Credentials.Name
            };
            if (credential.Load())
            {
                reti = credential.Password;
            }
            return reti;
        }

        /// <summary>
        /// Loads key which will be used data decryption asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// string representing key which can be used for data decryption,
        /// or NULL if key cannot be loaded.
        /// </returns>
        private Task<string?> LoadKeyAsync()
        {
            return Task<string?>.Run(() =>
            {
                return this.LoadKey();
            });
        }

        /// <summary>
        /// Loads data from registry.
        /// </summary>
        /// <returns>Connection structure with encrypted data.</returns>
        private DecryptedConnection LoadRegistry()
        {
            string server = (string)(Registry.GetValue(this.format.Registry.Path, this.format.Registry.Server, string.Empty) ?? string.Empty);
            string port = (string)(Registry.GetValue(this.format.Registry.Path, this.format.Registry.Port, string.Empty) ?? string.Empty);
            string database = (string)(Registry.GetValue(this.format.Registry.Path, this.format.Registry.Database, string.Empty) ?? string.Empty);
            string username = (string)(Registry.GetValue(this.format.Registry.Path, this.format.Registry.Username, string.Empty) ?? string.Empty);
            string password = (string)(Registry.GetValue(this.format.Registry.Path, this.format.Registry.Password, string.Empty) ?? string.Empty);
            return new DecryptedConnection(
                server,
                port,
                database,
                username,
                password
            );
        }

        /// <summary>
        /// Loads data from registry asynchronously.
        /// </summary>
        /// <returns>Task which resolves into connection structure with encrypted data.</returns>
        private Task<DecryptedConnection> LoadRegistryAsync()
        {
            return Task<DecryptedConnection>.Run(() =>
            {
                return this.LoadRegistry();
            });
        }
    }
}
