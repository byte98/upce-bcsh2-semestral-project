using SemestralProject.Common.Exceptions;
using SemestralProject.Model.Exceptions;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which represents storage which stores data securely in some kind of way.
    /// </summary>
    public class SecureStorage: AbstractExceptionThrownSource
    {
        /// <summary>
        /// Default root path to registry.
        /// </summary>
        private static readonly string defaultRoot = "HKEY_CURRENT_USER\\SOFTWARE\\" + (Assembly.GetExecutingAssembly().GetName().Name ?? "BCSH2_SEMESTRAL_PROJECT") + "\\0x0a";

        /// <summary>
        /// Default name of credential to store key to storage.
        /// </summary>
        private static readonly string defaultCredential = (Assembly.GetExecutingAssembly().GetName().Name ?? "BCSH2_SEMESTRAL_PROJECT") + ".storage";

        /// <summary>
        /// Lazy loader of default secure storage.
        /// </summary>
        private static readonly Lazy<SecureStorage> lazy
            = new Lazy<SecureStorage>(() => new SecureStorage(SecureStorage.defaultRoot, SecureStorage.defaultCredential));

        /// <summary>
        /// Default secured storage.
        /// </summary>
        public static SecureStorage Default
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// Object which hanldes saving data to registry.
        /// </summary>
        private readonly RegistrySaver registrySaver;

        /// <summary>
        /// Object which handles loading data from registry.
        /// </summary>
        private readonly RegistryLoader registryLoader;

        /// <summary>
        /// Object which handles saving key to Windows Credentials.
        /// </summary>
        private readonly KeySaver keySaver;

        /// <summary>
        /// Object which handles loading key from Windows Credentials.
        /// </summary>
        private readonly KeyLoader keyLoader;

        /// <summary>
        /// Actually used key.
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Root path to registry.
        /// </summary>
        private readonly string root;

        /// <summary>
        /// Name of credential to store key to storage.
        /// </summary>
        private readonly string credential;

        /// <summary>
        /// List of names with saved values.
        /// </summary>
        private IList<string> savedValues;

        /// <summary>
        /// Creates new secured storage.
        /// </summary>
        /// <param name="root">Root path to registry.</param>
        /// <param name="credential">Name of credential to store key to storage.</param>
        private SecureStorage(string root, string credential)
        {
            this.root = root;
            this.credential = credential;
            this.registrySaver = new RegistrySaver(root);
            this.registryLoader = new RegistryLoader(root);
            this.keyLoader = new KeyLoader(credential);
            this.keySaver = new KeySaver(credential);
            this.savedValues = new List<string>();
        }
        
        /// <summary>
        /// Regenerates key used for encrypting data.
        /// </summary>
        private void RegenarateKey()
        {
            string key = StringUtils.Shuffle(StringUtils.Random(StringUtils.EnglishBothAndNumbers, 256));
            if (this.keySaver.Save(key))
            {
                this.key = key;
            }
            else
            {
                this.ThrowException("Cannot save key to credentials!");
            }
        }

        /// <summary>
        /// Saves value to secure storage.
        /// </summary>
        /// <param name="name">Name of value.</param>
        /// <param name="value">String representation of value.</param>
        public void Save(string name, string value)
        {
            this.ReSave();
            this.registrySaver.Save(StringUtils.Hash(name), StringUtils.Encrypt(value, this.key));
        }

        /// <summary>
        /// Resaves all saved values with new key.
        /// </summary>
        private void ReSave()
        {
            IDictionary<string, string> storage = this.LoadAll();
            this.RegenarateKey();
            foreach (string name in storage.Keys)
            {
                this.registrySaver.Save(name, StringUtils.Encrypt(storage[name], this.key));
            }
        }

        /// <summary>
        /// Saves value to secure storage asynchronously.
        /// </summary>
        /// <param name="name">Name of value.</param>
        /// <param name="value">String representation of value.</param>
        /// <returns>Task which performs saving data to storage.</returns>
        public Task SaveAsync(string name, string value)
        {
            return Task.Run(() =>
            {
                this.Save(name, value);
            });
        }

        /// <summary>
        /// Loads all data.
        /// </summary>
        /// <returns>Dicrtionary of name value pairs of all data.</returns>
        private IDictionary<string, string> LoadAll()
        {
            this.LoadSavedNames();
            IDictionary<string,string> reti = new Dictionary<string,string>();
            foreach(string name in this.savedValues)
            {
                if (reti.ContainsKey(name))
                {
                    reti.Remove(name);
                }
                reti.Add(name, this.Load(name, false) ?? string.Empty);
            }
            return reti;
        }

        /// <summary>
        /// Loads all saved names of data.
        /// </summary>
        private void LoadSavedNames()
        {
            this.savedValues.Clear();
            string[] registryNames = this.registryLoader.LoadAllNames();
            foreach(string regName in registryNames)
            {
                this.savedValues.Add(regName);
            }
        }

        /// <summary>
        /// Loads data from secure storage.
        /// </summary>
        /// <param name="name">Name of value</param>
        /// <param name="useHash">Flag, whether name should be hashed.</param>
        /// <returns>
        /// Value loaded from secure storage, 
        /// or NULL if there is no such value.
        /// </returns>
        private string? Load(string name, bool useHash)
        {
            string? reti = null;
            string valName = name;
            if (useHash == true)
            {
                valName = StringUtils.Hash(name);
            }
            if (this.savedValues.Count == 0)
            {
                this.LoadSavedNames();
            }
            if (this.savedValues.Contains(valName))
            {
                string? key = this.keyLoader.Load();
                if (key != null)
                {
                    object? val = this.registryLoader.Load(valName);
                    if (val != null)
                    {
                        string strVal = string.Empty;
                        if (val.GetType() == typeof(string))
                        {
                            strVal = (string)val;
                        }
                        else
                        {
                            strVal = val.ToString() ?? string.Empty;
                        }
                        reti = StringUtils.Decrypt(strVal, key);
                    }
                }
                else
                {
                    this.ThrowException("Cannot load key to storage!");
                }
            }
            return reti;
        }

        /// <summary>
        /// Loads data from secure storage.
        /// </summary>
        /// <param name="name">Name of data.</param>
        /// <returns>
        /// String representation of data,
        /// or NULL if there is no such data.
        /// </returns>
        public string? Load(string name)
        {
            return this.Load(name, true);
        }

        /// <summary>
        /// Loads data from secure storage asynchronously.
        /// </summary>
        /// <param name="name">Name of data.</param>
        /// <returns>
        /// Task which resolves into:
        /// string representation of data,
        /// or NULL if there is no such data.
        /// </returns>
        public Task<string?> LoadAsync(string name)
        {
            return Task.Run<string?>(() =>
            {
                return this.Load(name);
            });
        }

        /// <summary>
        /// Throws exception.
        /// </summary>
        /// <param name="message">Message of exception.</param>
        private void ThrowException(string message)
        {
            this.ThrowException(new SecureStorageException(this.root, this.credential, message));
        }


    }
}
