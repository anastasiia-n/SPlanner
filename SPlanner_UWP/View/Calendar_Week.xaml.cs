using SPlanner.DAL;
using SPlanner_UWP.ViewModel;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calendar_Week : Page
    {
        public WeekViewModel WeekVM { get; set; }

        public Calendar_Week()
        {
            this.InitializeComponent();
            WeekVM = new WeekViewModel(DateTime.Today);
            DayFrame.Navigate(typeof(DayView), WeekVM.SelectedDate);
        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {
            var mydate = Shared.FirstDayOfWeek(WeekVM.SelectedDate).AddDays(-7);
            WeekVM.ChangeCollection(mydate);
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            var mydate = Shared.FirstDayOfWeek(WeekVM.SelectedDate).AddDays(7);
            WeekVM.ChangeCollection(mydate);
        }

        private void CalendarGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Day_Info di = e.ClickedItem as Day_Info;
            if (di != null)
            {
                WeekVM.SelectedDate = di.date;
                DayFrame.Navigate(typeof(DayView), WeekVM.SelectedDate);
            }
        }
    }
}
