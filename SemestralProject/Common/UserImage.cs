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
        public static UserImage Default = new UserImage("H4sIAAAAAAACCgG2Bkn5iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAMAAAD04JH5AAAABGdBTUEAALGPC/xhBQAAAYZQTFRFqKiomJiYb29vUVFROzs7JCQkFRUVDQ0NBAQEkJCQVVVVICAgAAAAe3t7LCwsiYmJODg4lpaWRUVFRkZGbm5uAwMDWFhYMzMzXFxcbGxsfX19jo6On5+fQ0NDCQkJoaGhnJycLi4uTU1Nnp6ePj4+j4+PDw8PeXl5JiYmkZGRDg4OGBgYIiIiXV1dgoKCp6enMjIyZmZmaGhoMTExNTU1eHh4NDQ0f39/gYGBPDw8PT09mpqaERERa2trcHBwNzc3oKCgLS0tHBwcNjY2paWlS0tLR0dHBQUFXl5enZ2dOTk5IyMjJSUlHh4ek5OThISEampqGxsbd3d3X19fjIyMl5eXoqKipKSkYGBgBwcHFBQUSkpKfn5+hYWFExMTVlZWWlpaHx8fQkJCJycnKCgoo6OjdHR0lJSUmZmZAgICFhYWAQEBcnJyU1NTg4ODKysrGRkZm5ubWVlZMDAwREREcXFxFxcXgICAdXV1aWlpOjo6pqamDAwMbW1tT09PPz8/HR0diIiINZREqwAAAAlwSFlzAAAOwgAADsIBFShKgAAABMZJREFUeF7tmmlDW0UUhiEkXJbLEhrCEsoOge6itoXaWsBSqkIttIK0aF1K1brUfbf6zw1znsQAuclsV7/c59t7MuedwJ3McuY2JSQkJCQkJNjTnGpJZ1qDtragNZNuSTUT/o9o7+gMj9HZ0c6H8dPVTafH6O6iQbz09NJfDXp7aBQf2T76iuBUloYxkeuno0j6czSNhTy9KAYGh4YLIyOF4aHBAUKKPI1j4DRdhOFoOjdGUDGWS4/yURieJuib8Qk6CMPJKWJVTE3yYRhOjBPzS6X/6Rkix5iZpkE4QcQr5f//bJFADYqzNIrhKZTH39w8gZrMz9HM+0jMYTyNjqT8GDz/GrP8/hv2X/kG/X5npFPiOoesC0+hD+mFHvGcrfv8y8wzEn2uC6w/dcZ/NUVp3Yv0QJc4agwAgWHgb3Vm/Y+Yf04yI+27kc60i98kUgNmZV97pA7lNlpj/o9iSlamDqQrsv9Lo7RIq5ROlCPNysxsamPi9LNXTonZkfW/EWOSk0K60aK8BlCayB6pBeWGPM9BlCaDKslo3ESSUV5DKE2GVFIG5Uar8hpGaTKsklpRbgTKq4DSpKCSApQbbcprBKXJiEpqQ7nxv3+BM8rL6hGcQblxVnlZDcKzKDfOKS+rn+E5lBuyHbKaiPxsis4rL6up+DzKjQvKy2oxuoB046KcCSyW4/6LSEcuKTeLDckllCsvKTeLLdkC0pVx5WaxKTX4yvV5WfxMt+WvIN15VQxNDyaGk2c9+BeYHc0uI31wRSzNDqdX0V5YFE+T4/kS0g/XZE02KFC85rlSdl1s9Us0N9De4CHoFqliKJOVy4RaZbrXCfjkppwPSjQuVC4T8Ut2BfuGpdo5wx2sLlOX6aBBsXr1DaL+uUUXiqhy/RqNY2HhNr1Es07TmLjzJv1E8Fbsd2fNb9NVTTY2aRYXd/+9tIig+wpN46DYsPtDMu/Q3Dftq/TQkHtbpHhl++iN3crS9tbV+w/e3RnPFoq7a8vvERf6bpLljZ5lrA/Ze/joZAf769VN3vdTIKvwAb4lgrXIvd7m4w9pVGLJ53z4Eaal7vM7xGqT+piGYfiJtyv9J5U1IMg/IRbNwQaNw3v3CTnytLIOL35KqD75z2g/62VO2P8cu+A6kYYUyi8YPPuCiAPZPcxWrxHR4UuSnn1FwJ6vsTJcZKlwh8+/IWBL+cL2W7Q2W8xb36EteSwu4fdoA3b5Bk77kx/Ew/zvP2SL5G20DT+KheUfwTi4/QBtDmN5FWkM+daHFCm3hoHJ7+8ozAc/IU1h+6c9/5ykIHOi5Q3mzyo5XERawWsPvyDNkCUg0Jv/o5CV6TnKiLsq1fVdjANxsdmjranMoPH6Wx/ZH/yKMuA3Oes5v4xyQ9mE5g9yQeUF");

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
            return StringUtils.ToClob(this.content);
        }
    }
}
