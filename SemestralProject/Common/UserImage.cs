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
        /// Default image of user.
        /// </summary>
        public static UserImage Default = new UserImage("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");

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
            StringBuilder reti = new StringBuilder();
            string[] parts = StringUtils.SplitBySize(this.content, 1024);
            for (int i = 0; i < parts.Length; i++)
            {
                reti.Append("TO_CLOB('");
                reti.Append(parts[i]);
                reti.Append("')");
                if (i < parts.Length - 1)
                {
                    reti.Append("||");
                }
            }
            return reti.ToString();
        }
    }
}
