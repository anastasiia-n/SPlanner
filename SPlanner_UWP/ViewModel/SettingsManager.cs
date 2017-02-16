using SPlanner.BL;
using System;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace SPlanner_UWP
{
    public static class SettingsManager
    {
        static ApplicationDataContainer localSettings;
        static StorageFolder localFolder;
        static SettingsManager()
        {
            localSettings = ApplicationData.Current.LocalSettings;
            localFolder = ApplicationData.Current.LocalFolder;
        }
        internal static void SaveHelpPhase(int phaseNumber)
        {
            localSettings.Values["HelpPhase"] = phaseNumber;
        }
        internal static int GetHelpPhase()
        {
            if (localSettings.Values["HelpPhase"] == null) return 0;
            else return (int)localSettings.Values["HelpPhase"];
        }
        internal static void AddColor(long classId, Color col)
        {
            string key = classId + "ClassColor";
            localSettings.Values[key] = col.ToString();
        }
        internal static void RemoveColor(long classId)
        {
            string key = classId + "ClassColor";
            localSettings.Values.Remove(key);
        }
        internal static void SetStandartClassDuration(uint durationInMinutes)
        {
            localSettings.Values["duration"] = durationInMinutes.ToString();
        }
        internal static int GetStandartClassDuration()
        {
            if (localSettings.Values["duration"] == null) return 0;
            return Convert.ToInt32(localSettings.Values["duration"]);
        }
        internal static SolidColorBrush GetColor(long classId)
        {
            SolidColorBrush brush = null;
            string key = classId + "ClassColor";
            string color = (string)localSettings.Values[key];
            if (color != null)
            {
                brush = GetSolidColorBrush(color);
            }
            return brush;
        }
        private static SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush scb = new SolidColorBrush(Color.FromArgb(a, r, g, b));
            return scb;
        }

    }
}
