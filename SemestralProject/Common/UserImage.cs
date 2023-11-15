using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

                    content = Convert.ToBase64String(bytes);
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
            reti.StreamSource = new MemoryStream(Convert.FromBase64String(content));
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
    }
}
