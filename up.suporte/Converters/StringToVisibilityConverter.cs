using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace up.suporte.Converters
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool invert = bool.TryParse((string)parameter, out bool result) ? result : false;

            if (invert)
            {
                return String.IsNullOrEmpty((string)value) ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return String.IsNullOrEmpty((string)value) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
