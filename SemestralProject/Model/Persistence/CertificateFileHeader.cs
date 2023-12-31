using SemestralProject.Common;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which represents header of certificate file.
    /// </summary>
    public class CertificateFileHeader
    {
        /// <summary>
        /// Head of file.
        /// </summary>
        public string Head { get; init; }

        /// <summary>
        /// Version of file.
        /// </summary>
        public int Version { get; init; }

        /// <summary>
        /// Seed of generator of file.
        /// </summary>
        public int Seed { get; init; }

        /// <summary>
        /// Size of header of file.
        /// </summary>
        public int HeaderSize { get; init; }

        /// <summary>
        /// Raw representation of certificate file header.
        /// </summary>
        public byte[] Data { get; init; }

        /// <summary>
        /// Creates new header of certificate file.
        /// </summary>
        /// <param name="head">Head of file.</param>
        /// <param name="version">Version of file.</param>
        /// <param name="seed">Seed of generator of file.</param>
        /// <param name="headerSize">Size of header of file.</param>
        private CertificateFileHeader(string head, int version, int seed, int headerSize)
        {
            this.Head = head;
            this.Version = version;
            this.Seed = seed;
            this.HeaderSize = headerSize;
        }

        /// <summary>
        /// Creates certificate file header from data.
        /// </summary>
        /// <param name="data">Binary representation of certification header data.</param>
        /// <returns>Header of certification file.</returns>
        public static CertificateFileHeader FromData(byte[] data)
        {
            FileAddresser fa = new FileAddresser(CertificateFileHeader.GetFileObjects());
            byte[] version = ArrayUtils<byte>.Part(data, fa.GetAddress(nameof(CertificateHeaderFormat.Version)), )
        }

        /// <summary>
        /// Gets file objects according to specified format.
        /// </summary>
        /// <returns>Dictionary containing file objects parsed from specified format.</returns>
        private static IDictionary<string, FileObject> GetFileObjects()
        {
            IDictionary<string, FileObject> reti = new Dictionary<string, FileObject>();
            CertificateHeaderFormat format = new CertificateHeaderFormat();
            reti.Add(nameof(CertificateHeaderFormat.HeaderSize), CertificateHeaderFormat.HeaderSize);
            reti.Add(nameof(CertificateHeaderFormat.Version), CertificateHeaderFormat.Version);
            reti.Add(nameof(CertificateHeaderFormat.Seed), CertificateHeaderFormat.Seed);
            reti.Add(nameof(format.Head), format.Head);
            return reti;
        }
    }
}
