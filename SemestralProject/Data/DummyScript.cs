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
        /// Provider of names of roles.
        /// </summary>
        public static readonly IStringProvider Roles = new FileLinesStringProvider(FileUtils.ReadFromResources(DummyScript.File, "ROLES"));

    }
}
