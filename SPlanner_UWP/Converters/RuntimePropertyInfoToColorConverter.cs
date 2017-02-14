using System;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace SPlanner_UWP.Converters
{
    public sealed class RuntimePropertyInfoToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var selectedItem = (PropertyInfo)value;
            var color = (Color)selectedItem.GetValue(null, null);
            return color;
        }
    }
}
