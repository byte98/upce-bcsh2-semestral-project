using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Common
{
    /// <summary>
    /// Class which provides ability to address file.
    /// </summary>
    public class FileAddresser
    {
        /// <summary>
        /// Dictionary of addresses in file.
        /// </summary>
        private IDictionary<string, int> addresses;

        /// <summary>
        /// Source of addresses.
        /// </summary>
        private IDictionary<string, FileObject> objects;

        /// <summary>
        /// Creates new addresser of file.
        /// </summary>
        /// <param name="source">Source of addresses.</param>
        public FileAddresser(IDictionary<string, FileObject> source)
        {
            this.objects = source;
            this.addresses = new Dictionary<string, int>();
            this.Parse();
        }

        /// <summary>
        /// Gets address in file.
        /// </summary>
        /// <param name="address">Name of address.</param>
        /// <returns>
        /// Address in file,
        /// or NULL if no address can be found.
        /// </returns>
        public int? GetAddress(string address)
        {
            int? reti = null;
            if (this.addresses.ContainsKey(address))
            {
                reti = this.addresses[address];
            }
            return reti;
        }

        /// <summary>
        /// Parses file structure to get addresses.
        /// </summary>
        private void Parse()
        {
            IList<FileObject> sources = new List<FileObject>();
            foreach(FileObject source in this.objects.Values)
            {
                sources.Add(source);
            }
            IList<FileObject> sortedSources = sources.OrderBy(fo => fo.Position).ToList();
            uint counter = 0;
            foreach(FileObject source in sortedSources)
            {
                this.addresses.Add(this.objects.FirstOrDefault(o => o.Value.Equals(source)).Key, (int)counter);
                counter += source.Size;
            }
        }

    }

}