using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AutoUi
{
    public class ExpensiveCarToBrushConverter : IValueConverter
    {
        public object Convert(object price, Type targetType, object parameter, CultureInfo culture)
        {
            var expensiveBrush = Brushes.Red;
            var normalBrush = Brushes.Black;

            return (decimal)price > 1000 ? expensiveBrush : normalBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
