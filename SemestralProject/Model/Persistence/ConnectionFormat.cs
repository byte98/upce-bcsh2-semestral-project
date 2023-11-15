using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Structure which holds information about format of connection used
    /// when saving and loading.
    /// </summary>
    public struct ConnectionFormat
    {
        /// <summary>
        /// Registry paths used for
        /// saving and loading information about connection.
        /// </summary>
        public ConnectionRegistry Registry { get; init; }

        /// <summary>
        /// Credential manager settings used for
        /// saving and loading connection information.
        /// </summary>
        public ConnectionCredential Credentials { get; init; }

        /// <summary>
        /// Default holder of information about format
        /// used for saving and loading connection information.
        /// </summary>
        public static readonly ConnectionFormat Default = new ConnectionFormat(ConnectionRegistry.Default, ConnectionCredential.Default);

        /// <summary>
        /// Creates new holder of information about format used
        /// for saving and loading connection information.
        /// </summary>
        public ConnectionFormat(): this(new ConnectionRegistry(), new ConnectionCredential()) { }

        /// <summary>
        /// Creates new holder of information about format used
        /// for saving and loading connection information.
        /// </summary>
        /// <param name="registry">Registry paths used for loading and saving connection information.</param>
        /// <param name="credential">Credential manager settings used for saving and loading connection information.</param>
        public ConnectionFormat(ConnectionRegistry registry, ConnectionCredential credential)
        {
            this.Registry = registry;
            this.Credentials = credential;
        }
    }
}
