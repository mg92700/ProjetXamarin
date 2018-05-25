using System;
using System.Globalization;
using Xamarin.Forms;

namespace Apu.Converters
{
    public class IconConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return $"http://openweathermap.org/img/w/{value.ToString()}.png";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}