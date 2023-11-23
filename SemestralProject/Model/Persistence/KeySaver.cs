using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which saves key using Windows Credentials API.
    /// </summary>
    public class KeySaver
    {
        /// <summary>
        /// Name of key as credential.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Creates new saver of key to Windows Credentials.
        /// </summary>
        /// <param name="name">Name of key credential.</param>
        public KeySaver(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Saves key.
        /// </summary>
        /// <param name="key">Key which will be saved.</param>
        /// <returns>
        /// TRUE, if key has been successfully saved,
        /// FALSE otherwise.
        /// </returns>
        public bool Save(string key)
        {
            CredentialManagement.Credential credential = new CredentialManagement.Credential
            {
                Target = this.name,
                Password = key,
                PersistanceType = CredentialManagement.PersistanceType.LocalComputer
            };
            return credential.Save();
        }

        /// <summary>
        /// Saves key asynchronously.
        /// </summary>
        /// <param name="key">Key which will be saved.</param>
        /// <returns>
        /// Task which resolves into:
        /// TRUE, if key has been successfully saved,
        /// FALSE otherwise.
        /// </returns>
        public Task<bool> SaveAsync(string key)
        {
            return Task<bool>.Run(() =>
            {
                return this.Save(key);
            });
        }
    }
}
