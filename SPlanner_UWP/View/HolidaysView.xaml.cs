using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class HolidaysView : Page
    {
        public HolidaysViewModel HolidaysVM { get; set; }
        public HolidaysView()
        {
            this.InitializeComponent();
            HolidaysVM = new HolidaysViewModel();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            HolidaysDialog sd = new HolidaysDialog(HolidaysVM);
            await sd.ShowAsync();
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                HolidaysVM.Holidays = fe.DataContext as Holidays;
                if (HolidaysVM.Holidays != null)
                {
                    HolidaysDialog sd = new HolidaysDialog(HolidaysVM, HolidaysVM.Holidays);
                    await sd.ShowAsync();
                }
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                HolidaysVM.Holidays = fe.DataContext as Holidays;
                if (HolidaysVM.Holidays != null)
                {
                    string message = "Holidays from " + HolidaysVM.Holidays.Start_date.ToString("d.M.yy") +
                        " to " + HolidaysVM.Holidays.End_date.ToString("d.M.yy");
                    DeleteDialog dialog = new DeleteDialog(message);
                    var result = await dialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        HolidaysVM.DeleteHolidays();
                    }
                }
            }
        }
    }
}
