using SemestralProject.Common.StringProviders;
using SemestralProject.Utils;
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
        /// SQL statements which truncates all tables.
        /// </summary>
        public static IStringProvider Tables = new CombinedStringProvider(
            new ConstantStringProvider("SET TRANSACTION READ WRITE"),
            new FileLinesStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "TRUNCATE")),
            new ConstantStringProvider("COMMIT")
        );

        /// <summary>
        /// SQL statements which resets all sequences.
        /// </summary>
        public static IStringProvider Sequences = new CombinedStringProvider(
            new ConstantStringProvider("SET TRANSACTION READ WRITE"),
            new FileLinesStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "RESTART")),
            new ConstantStringProvider("COMMIT")
        );
    }
}
