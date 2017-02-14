using SPlanner_UWP.ViewModel;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DayView : Page
    {
        public TasksViewModel TasksVM { get; set; }
        public ClassViewModel ClassVM { get; set; }
        private DateTime selectedDate;
        DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; }
        }

        public DayView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedDate = (DateTime)e.Parameter;
            TasksVM = new TasksViewModel(SelectedDate);
            ClassVM = new ClassViewModel(SelectedDate);
        }
    }
}
