using SPlanner_UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsView : Page
    {
        ClassViewModel ClassVM { get; set; }
        Color color;
        public SettingsView()
        {
            this.InitializeComponent();
            ClassVM = new ClassViewModel();
            color = new Color();
            ColorsComboBox.ItemsSource = typeof(Colors).GetProperties();
            Duration_TextBox.Text = SettingsManager.GetStandartClassDuration().ToString();
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClassColorStackPanel.Visibility = 
                ClassColorStackPanel.Visibility == Visibility.Visible ? 
                Visibility.Collapsed : Visibility.Visible;
        }

        private void AddColor_Click(object sender, RoutedEventArgs e)
        {
            if (color != null && ClassVM.Class != null) 
            {
                SettingsManager.AddColor(ClassVM.Class.id, color);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (ClassVM.Class != null)
            {
                SettingsManager.RemoveColor(ClassVM.Class.id);
            }
        }

        private void StackPanelDuration_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClassDurationStackPanel.Visibility =
                ClassDurationStackPanel.Visibility == Visibility.Visible ?
                Visibility.Collapsed : Visibility.Visible;
        }

        private void Duration_TextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (sender.Text == "")
            {
                sender.Text = "0";
                sender.SelectionStart = 1;
                return;
            }
            uint durationValue;
            if (uint.TryParse(sender.Text, out durationValue)) //if value is a number
            {
                if (durationValue <= 12 * 60) //if value equal or less than 12 hours
                {
                    if (sender.Text.Substring(0, 1) == "0") //if  value starts from zero, remove it ("01" -> "1")
                    {
                        sender.Text = sender.Text.Substring(1, sender.Text.Length - 1);
                        sender.SelectionStart = sender.SelectionStart + 1;
                    }
                    return;
                }
            }
            // if tryParse failed:
            int pos = sender.SelectionStart - 1;
            sender.Text = sender.Text.Remove(pos, 1); //remove last added character
            sender.SelectionStart = pos;
        }

        private void SetDurationButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsManager.SetStandartClassDuration(Convert.ToUInt32(Duration_TextBox.Text));
        }
    }
}
