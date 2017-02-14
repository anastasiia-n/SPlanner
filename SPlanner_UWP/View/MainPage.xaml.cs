using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(Calendar_Month));
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Content.ToString() == "Week view")
            {
                b.Content = "Month view";
                MainFrame.Navigate(typeof(Calendar_Week));
            }
            else
            {
                b.Content = "Week view";
                MainFrame.Navigate(typeof(Calendar_Month));
            }
        }

        private void MenuOpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (Menu.IsPaneOpen)
            {
                Menu.IsPaneOpen = false;
                Menu.Width = 50;
            }
            else
            {
                Menu.IsPaneOpen = true;
                Menu.Width = 200;
            }
        }

        private void MenuIconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalendarButton.Content = "Show calendar";
            if (CalendarListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(Calendar_Month));
                CalendarButton.Content = "Week view";
            }
            else if (TasksListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(TaskView));
            }
            else if (SubjectsListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(SubjectView));
            }
            else if (ClassesListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(ClassView));
            }
            else if (HolidaysListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(HolidaysView));
            }
            else if (ProfessorsListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(ProfessorView));
            }
            else if (SummaryListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(SummaryView));
            }
            else if (SettingsListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(SettingsView));
            }
            else if (HelpListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(HelpView));
            }
        }
    }
}
