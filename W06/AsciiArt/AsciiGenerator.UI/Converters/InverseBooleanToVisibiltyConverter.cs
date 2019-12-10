using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AsciiGenerator.UI.Converters
{
    public class InverseBooleanToVisibiltyConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool) value ? Visibility.Collapsed : Visibility.Visible;
            }

            throw new NotSupportedException("Converter is only supported for bools");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
