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
    /// Class which converts role to string representing count of permissions.
    /// </summary>
    public class RolePermissionsCounterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string reti = string.Empty;
            if (value is Role)
            {
                Role r = (Role)value;
                reti = r.GetPermissions().Length.ToString() + " oprávnění";
            }
            return reti;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
