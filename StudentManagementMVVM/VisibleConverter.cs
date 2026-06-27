using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StudentManagementMVVM
{
    public class VisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == false && parameter.ToString() == "Forward")
            {
                return Visibility.Visible;
            }
            else if ((bool)value == true && parameter.ToString() == "Forward")
            {
                return Visibility.Collapsed;
            }
            else if ((bool)value == false && parameter.ToString() == "Reverse")
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
