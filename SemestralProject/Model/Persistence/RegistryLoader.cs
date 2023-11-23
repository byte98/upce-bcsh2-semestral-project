using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which loads data from Windows Registry.
    /// </summary>
    public class RegistryLoader
    {
        /// <summary>
        /// Path from which all data will be read.
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Creates new loader of data from Windows Registry.
        /// </summary>
        /// <param name="path">Path from which all data will be read.</param>
        public RegistryLoader(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Loads data from registry.
        /// </summary>
        /// <param name="name">Name of data.</param>
        /// <returns>
        /// Data loaded from registry,
        /// or NULL if there is no such data.
        /// </returns>
        public object? Load(string name)
        {
            object? reti = null;
            RegistryKey? registryKey = this.GetRegistry();
            if (registryKey != null && registryKey.GetValueNames().Contains(name))
            {
                reti = registryKey.GetValue(name);
            }
            return reti;
        }

        /// <summary>
        /// Loads data from registry asynchronously.
        /// </summary>
        /// <param name="name">Name of data.</param>
        /// <returns>
        /// Task which resolves into:
        /// data loaded from registry,
        /// or NULL if there is no such data.
        /// </returns>
        public Task<object?> LoadAsync(string name)
        {
            return Task<object?>.Run(() =>
            {
                return this.Load(name);
            });
        }
        
        /// <summary>
        /// Gets registry key corresponding with path.
        /// </summary>
        /// <returns>
        /// Registry key corresponding with path,
        /// or NULL if there is no such registry key.
        /// </returns>
        private RegistryKey? GetRegistry()
        {
            RegistryKey? reti = null;
            string[] pathParts = this.path.Split('\\');
            RegistryHive? hive = RegistryLoader.GetRegistryHive(pathParts[0]);
            if (hive != null)
            {
                reti = RegistryKey.OpenBaseKey((RegistryHive)hive, RegistryView.Default);
                for (int i =  1; i < pathParts.Length; i++)
                {
                    if (reti == null)
                    {
                        break;
                    }
                    else
                    {
                        reti = reti.OpenSubKey(pathParts[i]);
                    }
                }
            }
            return reti;
        }

        /// <summary>
        /// Gets registry hive from its name.
        /// </summary>
        /// <param name="name">Name of searched registry hive.</param>
        /// <returns>
        /// Registry hive with searched name, 
        /// or NULL if there is no such hive.
        /// </returns>
        private static RegistryHive? GetRegistryHive(string name)
        {
            RegistryHive? reti = null;
            switch(name.ToUpper().Trim())
            {
                case "HKEY_CLASSES_ROOT": reti = RegistryHive.ClassesRoot; break;
                case "HKEY_CURRENT_USER": reti = RegistryHive.CurrentUser; break;
                case "HKEY_LOCAL_MACHINE": reti = RegistryHive.LocalMachine; break;
                case "HKEY_USERS": reti = RegistryHive.Users; break;
                case "HKEY_CURRENT_CONFIG": reti = RegistryHive.CurrentConfig; break;
                default: reti = null; break;
            }   
            return reti;
        }

        /// <summary>
        /// Loads all available names.
        /// </summary>
        /// <returns>Array with all available registry names.</returns>
        public string[] LoadAllNames()
        {
            string[] reti = new string[0];
            RegistryKey? registryKey = this.GetRegistry();
            if (registryKey != null)
            {
                reti = registryKey.GetValueNames();
            }
            return reti;
        }

        /// <summary>
        /// Loads all available names asynchronously.
        /// </summary>
        /// <returns>Task which resolves in array with all available registry names.</returns>
        public Task<string[]> LoadAllNamesAsync()
        {
            return Task<string[]>.Run(() =>
            {
                return this.LoadAllNames();
            });
        }
    }
}
