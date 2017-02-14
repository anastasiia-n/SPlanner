using SPlanner_UWP.ViewModel;
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace SPlanner_UWP.Converters
{
    public sealed class MonthDayItemColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool actualMonth = (bool)value;
            if (actualMonth) return new SolidColorBrush(Colors.Black);
            else return new SolidColorBrush(Colors.LightGray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
    public sealed class MonthDayItemBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var color = new SolidColorBrush(Colors.WhiteSmoke);
            var date = (DateTime)value;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return color;
            HolidaysViewModel hvm = new HolidaysViewModel();
            foreach (var item in hvm.HolidaysCollection)
            {
                if (date >= item.Start_date && date <= item.End_date)
                    return color;
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
