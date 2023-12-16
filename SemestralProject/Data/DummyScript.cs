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
    /// Class which holds some information used when creating dummy data.
    /// </summary>
    public static class DummyScript
    {
        /// <summary>
        /// Name of resources file containing all other files.
        /// </summary>
        private const string File = "SemestralProject.Resources.Dummy.Dummy";

        /// <summary>
        /// Basic size of dataset.
        /// </summary>
        private const int BaseSize = 256;

        /// <summary>
        /// Identifier of Czech Republic.
        /// </summary>
        public const int Country = 43;

        /// <summary>
        /// Provider of municipality names.
        /// </summary>
        public static readonly IStringProvider Municipalities = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "MUNICIPALITIES")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of names of municipality parts.
        /// </summary>
        public static readonly IStringProvider MunicipalityParts = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "MUNIPARTS")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of zip codes.
        /// </summary>
        public static readonly IStringProvider ZipCodes = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "ZIPCODES")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of names of streets.
        /// </summary>
        public static readonly IStringProvider Streets = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "STREETS")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of names of persons.
        /// </summary>
        public static readonly IStringProvider Names = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "NAMES")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of surnames of persons.
        /// </summary>
        public static readonly IStringProvider Surnames = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "SURNAMES")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of emails of persons.
        /// </summary>
        public static readonly IStringProvider Emails = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "EMAILS")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of names of stops-
        /// </summary>
        public static readonly IStringProvider Stops = new RandomStringProvider(new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "STOPS")), DummyScript.BaseSize);

        /// <summary>
        /// Provider of names of roles.
        /// </summary>
        public static readonly IStringProvider Roles = new CombinedStringProvider(
            new ConstantStringProvider("INSERT INTO ROLE(id_role, nazev) VALUES(10, 'Správce HR')"),
            new ConstantStringProvider("INSERT INTO ROLE(id_role, nazev) VALUES(11, 'Správce ICT')"),
            new ConstantStringProvider("INSERT INTO ROLE(id_role, nazev) VALUES(12, 'Dispečer')"),
            new ConstantStringProvider("INSERT INTO ROLE(id_role, nazev) VALUES(13, 'Manager')"),
            new ConstantStringProvider("INSERT INTO ROLE(id_role, nazev) VALUES(14, 'Řidič')"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(10, 3)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(10, 7)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(10, 8)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(10, 20)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(11, 3)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(11, 9)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(11, 10)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(11, 11)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(11, 12)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(11, 19)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(11, 21)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 3)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 7)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 13)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 14)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 15)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 16)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 17)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(12, 18)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 3)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 7)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 8)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 11)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 13)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 15)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 17)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 20)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 22)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(13, 23)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(14, 3)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(14, 13)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(14, 15)"),
            new ConstantStringProvider("INSERT INTO PRAVA(role, opravneni) VALUES(14, 17)")
        );

    }
}
