using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Structure which holds information used in credential manager
    /// when loading and saving connection information.
    /// </summary>
    public struct ConnectionCredential
    {
        /// <summary>
        /// Alphabet used for key generator for keys in
        /// credential manager.
        /// </summary>
        public string Alphabet { get; init; }

        /// <summary>
        /// Length of keys used for key generator for keys
        /// in credential manager.
        /// </summary>
        public uint Length { get; init; }

        /// <summary>
        /// Name of credential in credential manager
        /// used for saving and loading keys.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Default settings of credentials used for saving and loading connection information.
        /// </summary>
        public static readonly ConnectionCredential Default = new ConnectionCredential(
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789",
            32,
            (Assembly.GetExecutingAssembly().GetName().Name ?? "BCSH2_SEMESTRAL_PROJECT")
        );

        /// <summary>
        /// Creates new structure which holds information about used credential details
        /// when saving and loading connection information.
        /// </summary>
        public ConnectionCredential() : this(string.Empty, 0, string.Empty) { }

        /// <summary>
        /// Creates new structure which holds information about used credential details
        /// when saving and loading connection information.
        /// </summary>
        /// <param name="alphabet">Alphabet used for key generator for keys in credential manager.</param>
        /// <param name="length">Length of keys used for key generator for keys in credential manager.</param>
        /// <param name="name">Name of credential in credential manager used for saving and loading keys.</param>
        public ConnectionCredential(string alphabet, uint length, string name)
        {
            this.Alphabet = alphabet;
            this.Length = length;
            this.Name = name;
        }

        /// <summary>
        /// Generates key according to credential settings.
        /// </summary>
        /// <returns>String containing key generated according to credential settings.</returns>
        public String GenerateKey()
        {
            return StringUtils.Random(this.Alphabet, this.Length);
        }

        /// <summary>
        /// Generates key according to credential settings asynchronously.
        /// </summary>
        /// <returns>Task which resolves into string containing key generated according to credential settings.</returns>
        public Task<String> GenerateKeyAsync()
        {
            return StringUtils.RandomAsync(this.Alphabet, this.Length);
        }
    }
}
