using SPlanner.DAL;
using SPlanner_UWP.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calendar_Month : Page
    {
        public MonthViewModel MonthVM { get; set; }

        public Calendar_Month()
        {
            this.InitializeComponent();
            MonthVM = new MonthViewModel(DateTime.Today);
            DayFrame.Navigate(typeof(DayView), MonthVM.SelectedDate);
        }

        private void CalendarGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Day_Info di = e.ClickedItem as Day_Info;
            if (di != null)
            {
                MonthVM.SelectedDate = di.date;
                DayFrame.Navigate(typeof(DayView), MonthVM.SelectedDate);
            }
        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {
            var mydate = Shared.FirstDayOfMonth(MonthVM.SelectedDate).AddMonths(-1);
            MonthVM.ChangeCollection(mydate);
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            var mydate = Shared.FirstDayOfMonth(MonthVM.SelectedDate).AddMonths(1);
            MonthVM.ChangeCollection(mydate);
        }

    }
}
