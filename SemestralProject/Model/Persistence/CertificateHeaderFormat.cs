using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Persistence
{
    /// <summary>
    /// Class which holds format of certificate file header.
    /// </summary>
    public class CertificateHeaderFormat
    {
        /// <summary>
        /// Default head of certificate file header.
        /// </summary>
        private static readonly string DefaultHead = Assembly.GetExecutingAssembly().FullName ?? "B23Z_BCSH2_SEMESTRAL_PROJECT";

        /// <summary>
        /// Size of header of certificate file.
        /// </summary>
        public static FileObject HeaderSize => new FileObject(0, sizeof(int));

        /// <summary>
        /// Size of version of certificate file.
        /// </summary>
        public static FileObject Version => new FileObject(CertificateHeaderFormat.HeaderSize.Position + 1, sizeof(int));

        /// <summary>
        /// Seed of generator of file. 
        /// </summary>
        public static FileObject Seed => new FileObject(CertificateHeaderFormat.Version.Position + 1, sizeof(int));

        /// <summary>
        /// Head of file.
        /// </summary>
        public FileObject Head {  get; init; }

        /// <summary>
        /// Content of head of file.
        /// </summary>
        public string HeadContent { get; init; }

        /// <summary>
        /// Creates new format of certificate file header.
        /// </summary>
        public CertificateHeaderFormat() : this(CertificateHeaderFormat.DefaultHead) { }

        /// <summary>
        /// Creates new format of certificate file header.
        /// </summary>
        /// <param name="head">Head of certificate file header.</param>
        public CertificateHeaderFormat(string head)
        {
            this.HeadContent = head;
            this.Head = new FileObject(CertificateHeaderFormat.Seed.Position + 1, (uint)Encoding.UTF8.GetByteCount(head));
        }
    }
}
