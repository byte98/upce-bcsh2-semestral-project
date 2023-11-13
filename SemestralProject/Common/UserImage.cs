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
