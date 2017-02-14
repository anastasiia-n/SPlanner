using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace SPlanner_UWP.Converters
{
    public class SimpleDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return "";
            DateTime date = (DateTime)value;
            return date.ToString("d MMM yyyy", CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null || value.ToString() == "") return null;
            DateTime date = DateTime.Parse(value.ToString());
            return date;
        }
    }
}
