using SemestralProject.Common;
using SemestralProject.Common.StringProviders;
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
                { }
            },
            {
                IConnection.DatabaseObject.Table, new Dictionary<string, IStringProvider>()
                {
                    {"ADRESY", new ConstantStringProvider("DROP TABLE adresy CASCADE CONSTRAINTS PURGE")},
                    {"JIZDNI_RADY", new ConstantStringProvider("DROP TABLE jizdni_rady CASCADE CONSTRAINTS PURGE")},
                    {"LINKY", new ConstantStringProvider("DROP TABLE linky CASCADE CONSTRAINTS PURGE")},
                    {"OBCE", new ConstantStringProvider("DROP TABLE obce CASCADE CONSTRAINTS PURGE")},
                    {"OPRAVNENI", new ConstantStringProvider("DROP TABLE opravneni CASCADE CONSTRAINTS PURGE")},
                    {"OSOBY", new ConstantStringProvider("DROP TABLE osoby CASCADE CONSTRAINTS PURGE")},
                    {"PLANY_SMEN", new ConstantStringProvider("DROP TABLE plany_smen CASCADE CONSTRAINTS PURGE")},
                    {"PRAVA", new ConstantStringProvider("DROP TABLE prava CASCADE CONSTRAINTS PURGE")},
                    {"ROLE", new ConstantStringProvider("DROP TABLE role CASCADE CONSTRAINTS PURGE")},
                    {"SKUTECNE_RADY", new ConstantStringProvider("DROP TABLE skutecne_rady CASCADE CONSTRAINTS PURGE")},
                    {"SMENY", new ConstantStringProvider("DROP TABLE smeny CASCADE CONSTRAINTS PURGE")},
                    {"STATY", new ConstantStringProvider("DROP TABLE staty CASCADE CONSTRAINTS PURGE")},
                    {"STAVY", new ConstantStringProvider("DROP TABLE stavy CASCADE CONSTRAINTS PURGE")},
                    {"UZIVATELE", new ConstantStringProvider("DROP TABLE uzivatele CASCADE CONSTRAINTS PURGE")},
                    {"VYROBCI", new ConstantStringProvider("DROP TABLE vyrobci CASCADE CONSTRAINTS PURGE")},
                    {"ZAMESTNANCI", new ConstantStringProvider("DROP TABLE zamestnanci CASCADE CONSTRAINTS PURGE")},
                    {"ZASTAVKY", new ConstantStringProvider("DROP TABLE zastavky CASCADE CONSTRAINTS PURGE")},
                    {"LOGS", new ConstantStringProvider("DROP TABLE logs CASCADE CONSTRAINTS PURGE")}
                }
            },
            {
                IConnection.DatabaseObject.Sequence, new Dictionary<string, IStringProvider>()
                {
                    {"ADRESY_SEQ", new ConstantStringProvider("DROP SEQUENCE adresy_seq")},
                    {"JIZDNI_RADY_SEQ", new ConstantStringProvider("DROP SEQUENCE jizdni_rady_seq")},
                    {"LINKY_SEQ", new ConstantStringProvider("DROP SEQUENCE linky_seq")},
                    {"OBCE_SEQ", new ConstantStringProvider("DROP SEQUENCE obce_seq")},
                    {"OPRAVNENI_SEQ", new ConstantStringProvider("DROP SEQUENCE opravneni_seq")},
                    {"OSOBY_SEQ", new ConstantStringProvider("DROP SEQUENCE osoby_seq")},
                    {"OSOBNI_CISLA_SEQ", new ConstantStringProvider("DROP SEQUENCE osobni_cisla_seq")},
                    {"PLANY_SMEN_SEQ", new ConstantStringProvider("DROP SEQUENCE plany_smen_seq")},
                    {"PRAVA_SEQ", new ConstantStringProvider("DROP SEQUENCE prava_seq")},
                    {"PROVOZY_SEQ", new ConstantStringProvider("DROP SEQUENCE provozy_seq")},
                    {"ROLE_SEQ", new ConstantStringProvider("DROP SEQUENCE role_seq")},
                    {"SKUTECNE_RADY_SEQ", new ConstantStringProvider("DROP SEQUENCE skutecne_rady_seq")},
                    {"SMENY_SEQ", new ConstantStringProvider("DROP SEQUENCE smeny_seq")},
                    {"STATY_SEQ", new ConstantStringProvider("DROP SEQUENCE staty_seq")},
                    {"STAVY_SEQ", new ConstantStringProvider("DROP SEQUENCE stavy_seq")},
                    {"UZIVATELE_SEQ", new ConstantStringProvider("DROP SEQUENCE uzivatele_seq")},
                    {"ZASTAVKY_SEQ", new ConstantStringProvider("DROP SEQUENCE zastavky_seq")},
                    {"ZAMESTNANCI_SEQ", new ConstantStringProvider("DROP SEQUENCE zamestnanci_seq")},
                    {"LOGS_SEQ", new ConstantStringProvider("DROP SEQUENCE logs_seq")}
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
            new FileLinesStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "PERMISSIONS")),
            new FileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SUPERUSER")),
            new ConstantStringProvider("COMMIT")
        );

        /// <summary>
        /// SQl statements which creates all used packages.
        /// </summary>
        public static readonly IStringProvider Packages = new CombinedStringProvider(
            new CombinedStringProvider(
                new FileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_CRUD_HEADER")),
                new FileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_CRUD_BODY")),
                new FileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_UTILS_HEADER")),
                new FileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_UTILS_BODY")),
                new FileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_API_HEADER")),
                new FileStringProvider(FileUtils.ReadFromResources("SemestralProject.Resources.Installer", "SEMPR_API_BODY"))
            )
        );

    }
}
