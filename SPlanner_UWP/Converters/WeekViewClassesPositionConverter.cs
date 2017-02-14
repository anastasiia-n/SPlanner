using SPlanner.BL;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SPlanner_UWP.Converters
{
    public sealed class WeekViewClassesPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var mytime = ((Class)value).Start_time;
            int duration = ((Class)value).duration;
            if (mytime == null) return new Thickness();
            int margintop = (mytime.Hours - 6) * 60 + mytime.Minutes;
            return new Thickness(0, margintop, 0, -(margintop+duration));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public sealed class WeekViewClassesHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return double.Parse(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
