using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Data
{
    /// <summary>
    /// Class which holds script needed to be run to truncate database.
    /// </summary>
    public static class TruncateScript
    {
        /// <summary>
        /// Array with tables which needed to be truncated
        /// in this specific sequence.
        /// </summary>
        public static readonly string[] Tables = new string[]
        {
            "soupravy_metra",
            "zabezpecovace",
            "trolejbusy",
            "tramvaje",
            "autobusy",
            "prevodovky",
            "skutecne_rady",
            "plany_smen",
            "jizdni_rady",
            "zastavky",
            "linky",
            "smeny",
            "vozidla",
            "modely",
            "vyrobci",
            "provozy",
            "cipove_karty",
            "uzivatele",
            "stavy",
            "role",
            "zamestnanci",
            "osoby",
            "adresy",
            "obce",
            "staty"
        };
    }
}
