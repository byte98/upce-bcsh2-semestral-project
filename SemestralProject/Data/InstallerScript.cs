using SemestralProject.Common;
using SemestralProject.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SemestralProject.Data
{
    /// <summary>
    /// Class which holds all installation SQL statements.
    /// </summary>
    public abstract class InstallerScript
    {
        /// <summary>
        /// Dictionary with all kind of drops.
        /// </summary>
        public static readonly IDictionary<IConnection.DatabaseObject, IDictionary<string, IStringProvider>> Drops = new Dictionary<IConnection.DatabaseObject, IDictionary<string, IStringProvider>>()
        {
            {
                IConnection.DatabaseObject.Trigger, new Dictionary<string, IStringProvider>()
                {
                    {"ARC_VOZIDLA_ARC_TRAMVAJE", new ConstantStringProvider("DROP TRIGGER arc_vozidla_arc_tramvaje")},
                    {"ARC_VOZIDLA_ARC_AUTOBUSY", new ConstantStringProvider("DROP TRIGGER arc_vozidla_arc_autobusy")},
                    {"ARC_VOZIDLA_ARC_TROLEJBUSY", new ConstantStringProvider("DROP TRIGGER arc_vozidla_arc_trolejbusy")},
                    {"ARC_VOZIDLA_ARC_SOUPRAVY_METRA", new ConstantStringProvider("DROP TRIGGER arc_vozidla_arc_soupravy_metra")}
                }
            },
            {
                IConnection.DatabaseObject.Table, new Dictionary<string, IStringProvider>()
                {
                    {"ADRESY", new ConstantStringProvider("DROP TABLE adresy CASCADE CONSTRAINTS PURGE")},
                    {"AUTOBUSY", new ConstantStringProvider("DROP TABLE autobusy CASCADE CONSTRAINTS PURGE")},
                    {"CIPOVE_KARTY", new ConstantStringProvider("DROP TABLE cipove_karty CASCADE CONSTRAINTS PURGE")},
                    {"JIZDNI_RADY", new ConstantStringProvider("DROP TABLE jizdni_rady CASCADE CONSTRAINTS PURGE")},
                    {"LINKY", new ConstantStringProvider("DROP TABLE linky CASCADE CONSTRAINTS PURGE")},
                    {"MODELY", new ConstantStringProvider("DROP TABLE modely CASCADE CONSTRAINTS PURGE")},
                    {"OBCE", new ConstantStringProvider("DROP TABLE obce CASCADE CONSTRAINTS PURGE")},
                    {"OSOBY", new ConstantStringProvider("DROP TABLE osoby CASCADE CONSTRAINTS PURGE")},
                    {"PLANY_SMEN", new ConstantStringProvider("DROP TABLE plany_smen CASCADE CONSTRAINTS PURGE")},
                    {"PREVODOVKY", new ConstantStringProvider("DROP TABLE prevodovky CASCADE CONSTRAINTS PURGE")},
                    {"PROVOZY", new ConstantStringProvider("DROP TABLE provozy CASCADE CONSTRAINTS PURGE")},
                    {"ROLE", new ConstantStringProvider("DROP TABLE role CASCADE CONSTRAINTS PURGE")},
                    {"SKUTECNE_RADY", new ConstantStringProvider("DROP TABLE skutecne_rady CASCADE CONSTRAINTS PURGE")},
                    {"SMENY", new ConstantStringProvider("DROP TABLE smeny CASCADE CONSTRAINTS PURGE")},
                    {"SOUPRAVY_METRA", new ConstantStringProvider("DROP TABLE soupravy_metra CASCADE CONSTRAINTS PURGE")},
                    {"STATY", new ConstantStringProvider("DROP TABLE staty CASCADE CONSTRAINTS PURGE")},
                    {"STAVY", new ConstantStringProvider("DROP TABLE stavy CASCADE CONSTRAINTS PURGE")},
                    {"TRAMVAJE", new ConstantStringProvider("DROP TABLE tramvaje CASCADE CONSTRAINTS PURGE")},
                    {"TROLEJBUSY", new ConstantStringProvider("DROP TABLE trolejbusy CASCADE CONSTRAINTS PURGE")},
                    {"UZIVATELE", new ConstantStringProvider("DROP TABLE uzivatele CASCADE CONSTRAINTS PURGE")},
                    {"VOZIDLA", new ConstantStringProvider("DROP TABLE vozidla CASCADE CONSTRAINTS PURGE")},
                    {"VYROBCI", new ConstantStringProvider("DROP TABLE vyrobci CASCADE CONSTRAINTS PURGE")},
                    {"ZABEZPECOVACE", new ConstantStringProvider("DROP TABLE zabezpecovace CASCADE CONSTRAINTS PURGE")},
                    {"ZAMESTNANCI", new ConstantStringProvider("DROP TABLE zamestnanci CASCADE CONSTRAINTS PURGE")},
                    {"ZASTAVKY", new ConstantStringProvider("DROP TABLE zastavky CASCADE CONSTRAINTS PURGE")}
                }
            },
            {
                IConnection.DatabaseObject.Sequence, new Dictionary<string, IStringProvider>()
                {
                    {"ADRESY_SEQ", new ConstantStringProvider("DROP SEQUENCE adresy_seq")},
                    {"CIPOVE_KARTY_SEQ", new ConstantStringProvider("DROP SEQUENCE cipove_karty_seq")},
                    {"JIZDNI_RADY_SEQ", new ConstantStringProvider("DROP SEQUENCE jizdni_rady_seq")},
                    {"LINKY_SEQ", new ConstantStringProvider("DROP SEQUENCE linky_seq")},
                    {"MODELY_SEQ", new ConstantStringProvider("DROP SEQUENCE modely_seq")},
                    {"OBCE_SEQ", new ConstantStringProvider("DROP SEQUENCE obce_seq")},
                    {"OSOBY_SEQ", new ConstantStringProvider("DROP SEQUENCE osoby_seq")},
                    {"OSOBNI_CISLA_SEQ", new ConstantStringProvider("DROP SEQUENCE osobni_cisla_seq")},
                    {"PLANY_SMEN_SEQ", new ConstantStringProvider("DROP SEQUENCE plany_smen_seq")},
                    {"PREVODOVKY_SEQ", new ConstantStringProvider("DROP SEQUENCE prevodovky_seq")},
                    {"PROVOZY_SEQ", new ConstantStringProvider("DROP SEQUENCE provozy_seq")},
                    {"ROLE_SEQ", new ConstantStringProvider("DROP SEQUENCE role_seq")},
                    {"SKUTECNE_RADY_SEQ", new ConstantStringProvider("DROP SEQUENCE skutecne_rady_seq")},
                    {"SMENY_SEQ", new ConstantStringProvider("DROP SEQUENCE smeny_seq")},
                    {"STATY_SEQ", new ConstantStringProvider("DROP SEQUENCE staty_seq")},
                    {"STAVY_SEQ", new ConstantStringProvider("DROP SEQUENCE stavy_seq")},
                    {"TYPY_VOZIDEL_SEQ", new ConstantStringProvider("DROP SEQUENCE typy_vozidel_seq")},
                    {"UZIVATELE_SEQ", new ConstantStringProvider("DROP SEQUENCE uzivatele_seq")},
                    {"VOZIDLA_SEQ", new ConstantStringProvider("DROP SEQUENCE vozidla_seq")},
                    {"VYROBCI_SEQ", new ConstantStringProvider("DROP SEQUENCE vyrobci_seq")},
                    {"ZABEZPECOVACE_SEQ", new ConstantStringProvider("DROP SEQUENCE zabezpecovace_seq")},
                    {"ZASTAVKY_SEQ", new ConstantStringProvider("DROP SEQUENCE zastavky_seq")},
                    {"ZAMESTNANCI_SEQ", new ConstantStringProvider("DROP SEQUENCE zamestnanci_seq")}
                }
            },
            {
                IConnection.DatabaseObject.View, new Dictionary<string, IStringProvider>()
            },
            {
                IConnection.DatabaseObject.Function, new Dictionary<string, IStringProvider>()
            },
            {
                IConnection.DatabaseObject.Procedure, new Dictionary<string, IStringProvider>()
            },
            {
                IConnection.DatabaseObject.Package, new Dictionary<string, IStringProvider>()
                {
                    {"SEMPR_CRUD", new ConstantStringProvider("DROP PACKAGE sempr_crud")},
                    {"SEMPR_UTILS", new ConstantStringProvider("DROP PACKAGE sempr_utils")},
                    {"SEMPR_API", new ConstantStringProvider("DROP PACKAGE sempr_api") }
                }
            }
        };

        /// <summary>
        /// Statements which creates all sequences.
        /// </summary>
        public static readonly IStringProvider Sequences = new FileLinesStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEQUENCES"));

        /// <summary>
        /// l SQL statements which creates all necessary tables.
        /// </summary>
        public static readonly IStringProvider Tables = new EmptyLineSplittedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "TABLES"));

        /// <summary>
        /// SQL statements which establish all necessary relations.
        /// </summary>
        public static readonly IStringProvider Relations = new EmptyLineSplittedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "RELATIONS"));

        /// <summary>
        /// SQL statements which creates all views.
        /// </summary>
        public static readonly IStringProvider Views = new EmptyStringProvider();

        /// <summary>
        /// SQL statements which creates all triggers.
        /// </summary>
        public static readonly IStringProvider Triggers = new EmptyStringProvider();

        /// <summary>
        ///  SQL statements which inserts all data into database.
        /// </summary>
        public static readonly IStringProvider Data = new CombinedStringProvider(
            new ConstantStringProvider("SET TRANSACTION READ WRITE"),
            new FileLinesStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "ROLES")),
            new FileLinesStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "COUNTRIES")),
            new FileLinesStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "STATES")),
            new ConstantStringProvider("COMMIT")
        );

        /// <summary>
        /// SQl statements which creates all used packages.
        /// </summary>
        public static readonly IStringProvider Packages = new CombinedStringProvider(
            new CompactStringProvider(
                new MergedStringProvider(
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_CRUD_HEADER"), "--" + Environment.NewLine),
                    new FunctionStringProvider((str) =>
                    {
                        string reti = str;
                        if (str.EndsWith(Environment.NewLine))
                        {
                            str = str.Substring(0, str.Length - Environment.NewLine.Length);
                        }
                        return reti;
                    }, new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_CRUD_DOCS"), "--" + Environment.NewLine))
                )
            ),
            new CompactStringProvider(
                new MergedStringProvider(
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_CRUD_BODY"), "--" + Environment.NewLine),
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_CRUD_DOCS"), "--" + Environment.NewLine)
                )
            ),
            new CompactStringProvider(
                new MergedStringProvider(
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_UTILS_HEADER"), "--" + Environment.NewLine),
                    new FunctionStringProvider((str) =>
                    {
                        string reti = str;
                        if (str.EndsWith(Environment.NewLine))
                        {
                            str = str.Substring(0, str.Length - Environment.NewLine.Length);
                        }
                        return reti;
                    }, new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_UTILS_DOCS"), "--" + Environment.NewLine))
                )
            ),
            new CompactStringProvider(
                new MergedStringProvider(
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_UTILS_BODY"), "--" + Environment.NewLine),
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_UTILS_DOCS"), "--" + Environment.NewLine)
                )
            ),
            new CompactStringProvider(
                new MergedStringProvider(
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_API_HEADER"), "--" + Environment.NewLine),
                    new FunctionStringProvider((str) =>
                    {
                        string reti = str;
                        if (str.EndsWith(Environment.NewLine))
                        {
                            str = str.Substring(0, str.Length - Environment.NewLine.Length);
                        }
                        return reti;
                    }, new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_API_DOCS"), "--" + Environment.NewLine))
                )
            ),
            new CompactStringProvider(
                new MergedStringProvider(
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_API_BODY"), "--" + Environment.NewLine),
                    new SeparatedFileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_API_DOCS"), "--" + Environment.NewLine)
                )
            )
        );

    }
}
