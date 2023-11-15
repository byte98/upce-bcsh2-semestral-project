using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which holds decrypted information about connection.
    /// </summary>
    public class DecryptedConnection
    {
        /// <summary>
        /// Address of server with database.
        /// </summary>
        private readonly string server;

        /// <summary>
        /// Port on which is database running.
        /// </summary>
        private readonly string port;

        /// <summary>
        /// Name of database to which application will connect to.
        /// </summary>
        private readonly string database;

        /// <summary>
        /// Username of user with access to database.
        /// </summary>
        private readonly string username;

        /// <summary>
        /// Password of user with access to database.
        /// </summary>
        private readonly string password;

        /// <summary>
        /// Connection with decrypted data.
        /// </summary>
        public Connection Connection { get; private set; } = Connection.Unknown;

        /// <summary>
        /// Key used for data decryption.
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Creates new connection which data will be decrypted.
        /// </summary>
        /// <param name="server">Encrypted address of server with database.</param>
        /// <param name="port">Encrypted port on which is database running</param>
        /// <param name="database">Encrypted name of database to which application will connect to.</param>
        /// <param name="username">Encrypted username of user with access to database.</param>
        /// <param name="password">Encrypted password of user with access to database.</param>
        public DecryptedConnection(string server, string port, string database, string username, string password)
        {
            this.server = server;
            this.port = port;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Performs data decryption.
        /// </summary>
        public void Decrypt()
        {
            string dServer = StringUtils.Decrypt(this.server, this.key) ?? string.Empty;
            string dPort = StringUtils.Decrypt(this.port, this.key) ?? string.Empty;
            string dDatabase = StringUtils.Decrypt(this.database, this.key) ?? string.Empty;
            string dUsername = StringUtils.Decrypt(this.username, this.key) ?? string.Empty;
            string dPassword = StringUtils.Decrypt(this.password, this.key) ?? string.Empty;
            this.Connection = new Connection(
                dServer,
                dPort,
                dDatabase,
                dUsername,
                dPassword
            );
        }

        /// <summary>
        /// Decrypts connection data.
        /// </summary>
        /// <param name="key">Key which will be used to decryption.</param>
        public void Decrypt(string key)
        {
            this.key = key;
            this.Decrypt();
        }

        /// <summary>
        /// Creates new action which performs data decryption.
        /// </summary>
        /// <returns>Action which performs data decryption.</returns>
        private Action GetDecryptionAction() => new Action(this.Decrypt);


        /// <summary>
        /// Performs asynchronous data decryption.
        /// </summary>
        /// <returns>Task which performs asynchronous data decryption.</returns>
        private Task DecryptAsync() => Task.Run(this.GetDecryptionAction());

        /// <summary>
        /// Decrypts data asynchronously.
        /// </summary>
        /// <param name="key">Key which will be used for data decryption.</param>
        /// <returns>Task which performs data decryption.</returns>
        public Task DecryptAsync(string key)
        {
            this.key = key;
            return this.DecryptAsync();
        }
    }
}
