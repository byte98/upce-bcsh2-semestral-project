using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which performs saving connection information to the system.
    /// </summary>
    public class ConnectionSaver
    {
        /// <summary>
        /// Format of saved data.
        /// </summary>
        private readonly ConnectionFormat format;

        /// <summary>
        /// Connection which will be saved.
        /// </summary>
        private readonly Connection connection;

        /// <summary>
        /// Creates new saver of connection to the system.
        /// </summary>
        /// <param name="format">Format of saved data.</param>
        /// <param name="connection">Connection which will be saved.</param>
        public ConnectionSaver(ConnectionFormat format, Connection connection)
        {
            this.format = format;
            this.connection = connection;
        }

        /// <summary>
        /// Saves connection information to the system.
        /// </summary>
        /// <returns>
        /// TRUE if connection information has been saved successfully,
        /// FALSE otherwise.
        /// </returns>
        public bool Save()
        {
            bool reti = false;
            string key = this.format.Credentials.GenerateKey();
            if (this.SaveKey(key) == true)
            {
                EncryptedConnection encrypted = new EncryptedConnection(this.connection);
                encrypted.Encrypt(key);
                this.SaveRegistry(encrypted);
                reti = true;
            }
            return reti;
        }

        /// <summary>
        /// Saves connection information to the system asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// TRUE if connection information has been saved successfully,
        /// FALSE otherwise.</returns>
        public Task<bool> SaveAsync()
        {
            return Task<bool>.Run(async () =>
            {
                bool reti = false;
                string key = await this.format.Credentials.GenerateKeyAsync();
                bool saved = await this.SaveKeyAsync(key);
                if (saved == true)
                {
                    EncryptedConnection encrypted = new EncryptedConnection(this.connection);
                    await encrypted.EncryptAsync(key);
                    await this.SaveRegistryAsync(encrypted);
                    reti = true;
                }
                return reti;
            });
        }


        /// <summary>
        /// Saves key generated to encrypt data.
        /// </summary>
        /// <param name="key">Key which will be saved.</param>
        /// <returns>TRUE, if key has been successfully saved, FALSE otherwise.</returns>
        private bool SaveKey(string key)
        {
            CredentialManagement.Credential credential = new CredentialManagement.Credential
            {
                Target = this.format.Credentials.Name,
                Password = key,
                PersistanceType = CredentialManagement.PersistanceType.LocalComputer
            };
            return credential.Save();
        }

        /// <summary>
        /// Saves key generated to encrypt data asynchronously.
        /// </summary>
        /// <param name="key">Key which will be saved.</param>
        /// <returns>
        /// Task which resolves into:
        /// TRUE, if key has been successfully saved, 
        /// FALSE otherwise.
        /// </returns>
        private Task<bool> SaveKeyAsync(string key)
        {
            return Task<bool>.Run(() =>
            {
                return this.SaveKey(key);
            });
        }

        /// <summary>
        /// Saves data to system registry.
        /// </summary>
        /// <param name="encrypted">Connection data which will be saved.</param>
        private void SaveRegistry(EncryptedConnection encrypted)
        {
            Registry.SetValue(this.format.Registry.Path, this.format.Registry.Server, encrypted.Server);
            Registry.SetValue(this.format.Registry.Path, this.format.Registry.Port, encrypted.Port);
            Registry.SetValue(this.format.Registry.Path, this.format.Registry.Database, encrypted.Database);
            Registry.SetValue(this.format.Registry.Path, this.format.Registry.Username, encrypted.Username);
            Registry.SetValue(this.format.Registry.Path, this.format.Registry.Password, encrypted.Password);
        }

        /// <summary>
        /// Saves data to system registry asynchronously.
        /// </summary>
        /// <param name="encrypted">Connection data which will be saved.</param>
        /// <returns>Task which performs saving data to system registry.</returns>
        private Task SaveRegistryAsync(EncryptedConnection encrypted)
        {
            return Task.Run(() =>
            {
                this.SaveRegistry(encrypted);
            });
        }
    }
}
