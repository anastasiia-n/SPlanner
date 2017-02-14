using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace SPlanner_UWP.Converters
{
    public sealed class ClassToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            long classId = (long)value;
            if (classId != 0)
            {
                var result = SettingsManager.GetColor(classId);
                if (result != null) return result;
            }
            return new SolidColorBrush(Colors.Gainsboro);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
