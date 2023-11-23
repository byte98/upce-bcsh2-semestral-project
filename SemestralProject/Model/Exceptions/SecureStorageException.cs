using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Exceptions
{
    /// <summary>
    /// Class representing exception thrown when something happened with secure storage.
    /// </summary>
    public class SecureStorageException: Exception
    {
        /// <summary>
        /// Creates new secure storage exception.
        /// </summary>
        /// <param name="root">Root path to registry of secure storage.</param>
        /// <param name="credential">Name of credential.</param>
        /// <param name="message">Message of exception.</param>
        public SecureStorageException(string root, string credential, string message)
            : base($"Secure Storage (root: {root}, credential: {credential} resulted into exception: {message}") { }
    }
}
