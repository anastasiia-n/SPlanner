using System;
using SPlanner_UWP.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using SPlanner.BL;
using System.Globalization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskView : Page
    {
        public TasksViewModel TasksVM { get; set; }
        public TaskView()
        {
            this.InitializeComponent();
            TasksVM = new TasksViewModel();
        }

        private async void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                TasksVM.Task = fe.DataContext as Task;
                if (TasksVM.Task != null)
                {
                    string taskText = "'";
                    if (TasksVM.Task.Text.Length > 10) taskText += TasksVM.Task.Text.Substring(0, 10) + "...";
                    else                               taskText += TasksVM.Task.Text;
                    taskText += "'";
                    
                    string message = taskText + " (" + TasksVM.Task.Date.ToString("d MMM yyyy", CultureInfo.CurrentCulture) + ")";
                    DeleteDialog dialog = new DeleteDialog(message);
                    var result = await dialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        TasksVM.DeleteTask();
                    }
                }
            }
        }

        private async void EditButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                TasksVM.Task = fe.DataContext as Task;
                if (TasksVM.Task != null)
                {
                    TaskDialog sd = new TaskDialog(TasksVM, TasksVM.Task);
                    await sd.ShowAsync();
                }
            }
        }

        private async void AddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TaskDialog td = new TaskDialog(TasksVM);
            await td.ShowAsync();
        }

        private void CloseFullMode_Click(object sender, RoutedEventArgs e)
        {
            FullModeScrollViewer.Visibility = Visibility.Collapsed;
        }

        private void FullModeButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                TasksVM.Task = fe.DataContext as Task;
                FullModeScrollViewer.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                bool isDone = (bool)((CheckBox)fe).IsChecked;
                TasksVM.Task = fe.DataContext as Task;
                if (TasksVM.Task.Done != isDone)
                {
                    TasksVM.Task.Done = isDone;
                    TasksVM.EditTask();
                }
            }
        }
    }
}
