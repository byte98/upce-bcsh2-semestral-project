using Microsoft.CodeAnalysis.CSharp.Syntax;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SemestralProject.Common
{
    /// <summary>
    /// Class which represents image of user.
    /// </summary>
    public class UserImage
    {
        /// <summary>
        /// BASE64 encoded string containing content of image.
        /// </summary>
        private readonly string content;

        /// <summary>
        /// Creates new image.
        /// </summary>
        /// <param name="content">BASE64 encoded string containing image.</param>
        private UserImage(string content)
        {
            this.content = content;
        }

        /// <summary>
        /// Creates user image from image file.
        /// </summary>
        /// <param name="iF">Image file containing image data.</param>
        /// <returns>User image created from image file.</returns>
        public static UserImage FromImageFile(ImageFile iF)
        {
            return UserImage.FromContent(iF.Content.Content);
        }

        /// <summary>
        /// Creates new image from BASE64 encoded string.
        /// </summary>
        /// <param name="base64">BASE64 encoded string containing data of image.</param>
        /// <returns>Image created from BASE64 encoded string.</returns>
        public static UserImage FromBase64(string base64)
        {
            string content = string.Empty;
            byte[] bytes = Convert.FromBase64String(base64);
            byte[] compressed = UserImage.Compress(bytes);
            content = Convert.ToBase64String(compressed);
            return new UserImage(content);
        }

        /// <summary>
        /// Creates image from file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Image with content read from file.</returns>
        public static UserImage FromFile(string path)
        {
            string content = string.Empty;
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    byte[] bytes = ms.ToArray();
                    content = Convert.ToBase64String(UserImage.Compress(bytes));
                }
            }
            return new UserImage(content);
        }

        /// <summary>
        /// Creates new image from its content.
        /// </summary>
        /// <param name="content">BASE64 encoded string containing image.</param>
        /// <returns>Image created from BASE64 encoded string.</returns>
        public static UserImage FromContent(string content)
        {
            return new UserImage(content);
        }

        /// <summary>
        /// Gets bitmap representation of image.
        /// </summary>
        /// <returns>Bitmap with content of image.</returns>
        public BitmapImage ToImage()
        {
            BitmapImage reti = new BitmapImage();
            reti.BeginInit();
            reti.StreamSource = new MemoryStream(UserImage.Decompress(Convert.FromBase64String(content)));
            reti.EndInit();
            return reti;
        }

        /// <summary>
        /// Gets content of image.
        /// </summary>
        /// <returns>String representing BASE64 encoded content of image.</returns>
        public string ToContent()
        {
            return this.content;
        }

        /// <summary>
        /// Compresses data.
        /// </summary>
        /// <param name="data">Array of bytes which will be compressed.</param>
        /// <returns>Array of bytes with compressed data.</returns>
        private static byte[] Compress(byte[] data)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.SmallestSize))
                {
                    gzipStream.Write(data, 0, data.Length);
                }
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Decompresses data.
        /// </summary>
        /// <param name="data">Array of bytes which will be decompressed.</param>
        /// <returns>Array of bytes with decompressed data.</returns>
        private static byte[] Decompress(byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var decompressStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        decompressStream.CopyTo(outputStream);
                    }
                    return outputStream.ToArray();
                }
            }
        }

        /// <summary>
        /// Gets CLOB representation of content of image.
        /// </summary>
        /// <returns>String representing conversion of content of image to CLOB data type.</returns>
        public string ToClob()
        {
            return StringUtils.ToClob(this.content);
        }
    }
}
