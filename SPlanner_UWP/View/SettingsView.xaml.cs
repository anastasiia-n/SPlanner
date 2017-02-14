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
    }
}
