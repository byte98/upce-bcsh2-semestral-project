using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which holds encrypted information about connection.
    /// </summary>
    public class EncryptedConnection
    {
        /// <summary>
        /// Address of server with database.
        /// </summary>
        public string Server { get; private set; } = string.Empty;

        /// <summary>
        /// Port on which is database running.
        /// </summary>
        public string Port { get; private set; } = string.Empty;

        /// <summary>
        /// Name of database to which application will connect to.
        /// </summary>
        public string Database { get; private set; } = string.Empty;

        /// <summary>
        /// Username of user with access to database.
        /// </summary>
        public string Username { get; private set; } = string.Empty;

        /// <summary>
        /// Password of user with access to database.
        /// </summary>
        public string Password { get; private set; } = string.Empty;

        /// <summary>
        /// Connection which data will be encrypted.
        /// </summary>
        private readonly Connection connection;

        /// <summary>
        /// Key used for data encryption.
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Creates new connection information with encrypted data.
        /// </summary>
        /// <param name="connection">Connection which data will be encrypted.</param>
        public EncryptedConnection(Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Encrypts data from provided connection.
        /// </summary>
        /// <param name="key">Key used for encrypting data.</param>
        public void Encrypt(string key)
        {
            this.key = key;
            this.Encrypt();
        }

        /// <summary>
        /// Performs data encryption.
        /// </summary>
        private void Encrypt()
        {
            this.Server = StringUtils.Encrypt(this.connection.Server, this.key);
            this.Port = StringUtils.Encrypt(this.connection.Port, this.key);
            this.Database = StringUtils.Encrypt(this.connection.Database, this.key);
            this.Username = StringUtils.Encrypt(this.connection.Username, this.key);
            this.Password = StringUtils.Encrypt(this.connection.Password, this.key);
        }

        /// <summary>
        /// Generates action which performs data encryption.
        /// </summary>
        /// <returns>Action which performs data encryption.</returns>
        private Action GetEncryptionAction()
        {
            return new Action(this.Encrypt);
        }

        /// <summary>
        /// Performs asynchronous data encryption.
        /// </summary>
        /// <returns>Task which performs asynchronous data encryption.</returns>
        private Task EncryptAsync()
        {
            return Task.Run(this.GetEncryptionAction());
        }

        /// <summary>
        /// Encrypts data from provided connection asynchronously.
        /// </summary>
        /// <param name="key">Key used for encrypting data.</param>
        /// <returns>Task which performs data encryption.</returns>
        public Task EncryptAsync(string key)
        {
            this.key = key;
            return this.EncryptAsync();
        }
    }
}
