using Microsoft.CodeAnalysis.CSharp.Syntax;
using SemestralProject.AsynchronousMethod;
using SemestralProject.Common;
using SemestralProject.DatabaseObject.DatabaseClass;
using SemestralProject.DatabaseObject.DatabaseColummn;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents image file in database.
    /// </summary>
    [DatabaseClass("proc_obrazky_create", "func_obrazky_read", "", "proc_obrazky_delete", "obrazky_seq", "id_obrazek")]
    public partial class ImageFile
    {
        /// <summary>
        /// Content of image.
        /// </summary>
        [DatabaseColumn("obsah")]
        public Clob Content { get; set; }

        /// <summary>
        /// Hash of file.
        /// </summary>
        [DatabaseColumn("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Name of file.
        /// </summary>
        [DatabaseColumn("nazev")]
        public string Name { get; set; }

        /// <summary>
        /// Date of upload of file.
        /// </summary>
        [DatabaseColumn("datum_nahrani")]
        public DateTime UploadDate { get; set; }

        /// <summary>
        /// Default image file.
        /// </summary>
        public static readonly ImageFile Default = new ImageFile(0, new Clob(

            //"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"
            //"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"
            ), "575C07830791B35BD5144405DC958ADD55928F9E752F8278F0DB8AF68A9D2628", "<výchozí obrázek>", new DateTime(1970, 1, 1, 0, 0, 0));

        /// <summary>
        /// Creates image file from file in storage.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Image file created from file in storage.</returns>
        [AsynchronousMethod]
        public static ImageFile FromFile(string path)
        {
            UserImage image = UserImage.FromFile(path);
            
            return ImageFile.Create(
                new Clob(image.ToContent()),
                StringUtils.Hash(image.ToContent()),
                Path.GetFileName(path),
                DateTime.Now
            );
        }
    }
}
