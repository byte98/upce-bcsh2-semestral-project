using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which loads key from Windows Credentials.
    /// </summary>
    public class KeyLoader
    {
        /// <summary>
        /// Name of credential.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Creates new loader of key from Window Credentials.
        /// </summary>
        /// <param name="name">Name of credential.</param>
        public KeyLoader(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Loads key from Windows Credentials.
        /// </summary>
        /// <returns>
        /// String representing loaded key,
        /// or NULL if key cannot be loaded.
        /// </returns>
        public string? Load()
        {
            string? reti = null;
            CredentialManagement.Credential credential = new CredentialManagement.Credential
            {
                Target = this.name
            };
            if (credential.Load())
            {
                reti = credential.Password;
            }
            return reti;
        }

        /// <summary>
        /// Loads key from Windows Credentials asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// string representing loaded key,
        /// or NULL if key cannot be loaded.
        /// </returns>
        public Task<string?> LoadAsync()
        {
            return Task<string?>.Run(() =>
            {
                return this.Load();
            });
        }
    }
}
