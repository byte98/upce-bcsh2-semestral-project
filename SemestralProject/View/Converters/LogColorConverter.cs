using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SemestralProject.View.Converters
{
    /// <summary>
    /// Converts log into its color.
    /// </summary>
    public class LogColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object reti = (SolidColorBrush)Application.Current.Resources["SystemAltHighColorBrush"];
            if (value is Log)
            {
                Log log = (Log)value;
                if (log.Operation == "insert")
                {
                    reti = (SolidColorBrush)Application.Current.Resources["InsertColorBrush"];
                }
                else if (log.Operation == "update")
                {
                    reti = (SolidColorBrush)Application.Current.Resources["UpdateColorBrush"];
                }
                else if (log.Operation == "delete")
                {
                    reti = (SolidColorBrush)Application.Current.Resources["DeleteColorBrush"];
                }
                else if (log.Operation == "login")
                {
                    reti = (SolidColorBrush)Application.Current.Resources["LoginColorBrush"];
                }
                else if (log.Operation == "logout")
                {
                    reti = (SolidColorBrush)Application.Current.Resources["LogoutColorBrush"];
                }
            }
            return reti;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
