using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SemestralProject.View.Converters
{
    /// <summary>
    /// Class which converts log into its symbol.
    /// </summary>
    public class LogSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string reti = "L";
            if (value is Log)
            {
                Log log = (Log)value;
                if (log.Operation == "insert")
                {
                    reti = (string)Application.Current.Resources["InsertSymbol"];
                }
                else if (log.Operation == "update")
                {
                    reti = (string)Application.Current.Resources["UpdateSymbol"];
                }
                else if (log.Operation == "delete")
                {
                    reti = (string)Application.Current.Resources["DeleteSymbol"];
                }
                else if (log.Operation == "login")
                {
                    reti = (string)Application.Current.Resources["LoginSymbol"];
                }
                else if (log.Operation == "logout")
                {
                    reti = (string)Application.Current.Resources["LogoutSymbol"];
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
