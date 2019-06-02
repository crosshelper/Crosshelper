using System;
using System.Globalization;
using Xamarin.Forms;

namespace Crosshelper.Converters
{
    public class TypeToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int parameterType = int.Parse(parameter.ToString());
            DateTime createtimestamp = DateTime.Now;
            var timestamp = (long)value;
            createtimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
            return createtimestamp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw null;
        }
    }
}
