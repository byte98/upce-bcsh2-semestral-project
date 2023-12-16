using SemestralProject.Model;
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
    /// Converter of employee to its inicials.
    /// </summary>
    class EmployeeInicialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object reti = string.Empty;
            if (value is Employee)
            {
                Employee e = (Employee)value;
                reti = e.PersonalData.Name.ToUpper()[0].ToString() + e.PersonalData.Surname.ToUpper()[0].ToString();
            }
            else if (value is UsersView)
            {
                UsersView u = (UsersView)value;
                Employee e = u.User.Employee;
                reti = e.PersonalData.Name.ToUpper()[0].ToString() + e.PersonalData.Surname.ToUpper()[0].ToString();
            }
            return reti;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
