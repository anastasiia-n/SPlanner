using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    public sealed partial class TaskDialog : ContentDialog
    {
        TasksViewModel TaskVM { get; set; }
        SubjectViewModel SubjectVM { get; set; }
        private bool preventClosing;
        private bool editingMode;
        public TaskDialog(TasksViewModel taskVM, Task task = null)
        {
            //get ViewModel from the View
            TaskVM = taskVM;
            SubjectVM = new SubjectViewModel();

            this.InitializeComponent();
            DataContext = this;

            //if task is null -> user is adding a new one
            if (task != null)
            {
                taskVM.Task = task;
                if (task.Deadline != null) DeadlineToggleSwitch.IsOn = true;
                else DeadlineToggleSwitch.IsOn = false;
                Title = "EDIT";
                editingMode = true;
            }
            //task is not null -> user is editing it
            else
            {
                TaskVM.Task = new Task();
                Title = "ADD";
                editingMode = false;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (TaskVM.Task.Text == null || TaskVM.Task.Text == "")
            {
                ErrorTextBlock.Text = "Text can not be empty";
                preventClosing = true;
                return;
            }
            if(TaskVM.Task.Subject_id == 0)
            {
                ErrorTextBlock.Text = "Subject can not be empty";
                preventClosing = true;
                return;
            }
            if (TaskVM.Task.Date == null) 
            {
                ErrorTextBlock.Text = "Date can not be empty";
                preventClosing = true;
                return;
            }

            preventClosing = false;

            //if deadline is not selected
            if (Task_deadline_cdp.Visibility == Visibility.Collapsed)
                TaskVM.Task.Deadline = null;

            if (editingMode) TaskVM.EditTask();
            else TaskVM.AddTask();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            preventClosing = false;
        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (preventClosing)
            {
                args.Cancel = true;
            }
        }

        private void ToggleSwitch_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //change visibility of Deadline control
            if (Task_deadline_cdp.Visibility == Visibility.Visible)
            {
                Task_deadline_cdp.Visibility = Visibility.Collapsed;
            }
            else
            {
                Task_deadline_cdp.Visibility = Visibility.Visible;
            }
        }
    }
}
