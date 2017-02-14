using SPlanner.DAL;
using SPlanner_UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SPlanner_UWP.Converters
{
    public sealed class DateHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;
            if (date == null) return "";
            return date.ToString("MMMM, yyyy", CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
    public sealed class DateWeekHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateFrom = (DateTime)value;
            dateFrom = Shared.FirstDayOfWeek(dateFrom);
            DateTime dateTo = dateFrom.AddDays(6);
            string dateStr = dateFrom.Day.ToString();
            if (dateFrom.Month != dateTo.Month)
                dateStr += dateFrom.ToString(" MMM", CultureInfo.CurrentCulture);
            if (dateFrom.Year != dateTo.Year)
                dateStr += dateFrom.ToString(" yyyy", CultureInfo.CurrentCulture);
            dateStr += " - " + dateTo.ToString("d MMM yyyy", CultureInfo.CurrentCulture);
            return dateStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
    public sealed class DayOfWeekHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;
            if (date == null) return "";
            return date.ToString("d, ddd", CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
