using System;
using Windows.UI.Xaml.Data;

namespace SPlanner_UWP.Converters
{
    public sealed class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset resultTime;
            if (value == null || (DateTime)value == default(DateTime)) resultTime = DateTime.Today;
            else resultTime = (DateTime)value;
            return resultTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;
            DateTimeOffset sourceTime = (DateTimeOffset)value;
            DateTime targetTime = sourceTime.DateTime;
            return targetTime;
        }
    }
}
