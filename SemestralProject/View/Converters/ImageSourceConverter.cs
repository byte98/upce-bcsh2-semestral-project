using SemestralProject.Common;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SemestralProject.View.Converters
{
    /// <summary>
    /// Class which converts user image to image source.
    /// </summary>
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object reti = value;
            if (value is ImageFile)
            {
                ImageFile imageFile = (ImageFile)value;
                reti = UserImage.FromImageFile(imageFile).ToImage();
            }
            return reti;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
