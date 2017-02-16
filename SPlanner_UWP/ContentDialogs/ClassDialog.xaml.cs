using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    public sealed partial class ClassDialog : ContentDialog
    {
        ClassViewModel ClassVM { get; set; }
        SubjectViewModel SubjectVM { get; set; }
        ProfessorViewModel ProfessorVM { get; set; }
        private bool PreventClosing;
        private bool editingMode;
        public ClassDialog(ClassViewModel classVM, Class clas = null)
        {
            ClassVM = classVM;
            SubjectVM = new SubjectViewModel();
            ProfessorVM = new ProfessorViewModel();

            this.InitializeComponent();
            Class_from_cdp.MinDate = DateTime.Today;
            Class_to_cdp.MinDate = DateTime.Today;

            if (clas != null)
            {
                ClassVM.Class = clas;
                Title = "EDIT";
                editingMode = true;
                ScheduleToggleSwitch.Visibility = Visibility.Visible;
                ScheduleToggleSwitch.IsOn = false;
                Schedule_editing_sp.Visibility = Visibility.Collapsed;
            }
            else
            {
                ClassVM.Class = new Class();
                ClassVM.from_date = DateTime.Today;
                ClassVM.to_date = DateTime.Today.AddMonths(5);
                Title = "ADD";
                editingMode = false;
                ScheduleToggleSwitch.Visibility = Visibility.Collapsed;
            }

            ClassVM.Class.Start_time = new TimeSpan(7, 0, 0);
            ClassVM.Class.End_time = ClassVM.Class.Start_time.Add(new TimeSpan(0, SettingsManager.GetStandartClassDuration(), 0));
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (ClassVM.Class.Start_time.Hours < 7 || ClassVM.Class.End_time.Hours > 22) 
            {
                ErrorTextBlock.Text = "Class should start after 7:00 / end before 22:00, sorry";
                PreventClosing = true;
                return;
            }
            if (ClassVM.Class.Start_time.TotalMinutes + 10 > ClassVM.Class.End_time.TotalMinutes)
            {
                ErrorTextBlock.Text = "Difference between start and end time must be at least 10 minutes";
                PreventClosing = true;
                return;
            }
            if (ClassVM.Class.Name == null || ClassVM.Class.Name == "")
            {
                ErrorTextBlock.Text = "Name can not be empty";
                PreventClosing = true;
                return;
            }
            if (ClassVM.Class.Subject_id == 0)
            {
                ErrorTextBlock.Text = "Subject is null";
                PreventClosing = true;
                return;
            }
            //if everything is ok:
            PreventClosing = false;
            //if schedule has to be changed
            string repeating = "";
            if (Schedule_editing_sp.Visibility == Visibility.Visible)
            {
                if (Class_repeating_cb.SelectedItem == No_cbi)              repeating = "NoRepeat";
                else if (Class_repeating_cb.SelectedItem == Week_cbi)       repeating = "Week";
                else if (Class_repeating_cb.SelectedItem == TwoWeeks_cbi)   repeating = "TwoWeeks";
                else if (Class_repeating_cb.SelectedItem == Month_cbi)      repeating = "Month";
            }

            if (editingMode)
            {
                try
                {
                    ClassVM.EditClass();
                }
                catch (Exception ex)
                {
                    ErrorTextBlock.Text = ex.Message;
                    PreventClosing = true;
                }
                //if schedule has to be changed
                if (Schedule_editing_sp.Visibility == Visibility.Visible)
                {
                    ClassVM.EditSchedule(repeating);
                }
            }
            else
            {
                try
                {
                    ClassVM.AddClass(repeating);
                }
                catch (Exception ex)
                {
                    ErrorTextBlock.Text = ex.Message;
                    PreventClosing = true;
                }
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            PreventClosing = false;
        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (PreventClosing)
            {
                args.Cancel = true;
            }
        }

        private void ScheduleToggleSwitch_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(ScheduleToggleSwitch.IsOn) Schedule_editing_sp.Visibility = Visibility.Visible;
            else                        Schedule_editing_sp.Visibility = Visibility.Collapsed;
        }

        private void Class_from_cdp_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (Class_from_cdp.Date == null)
                Class_from_cdp.Date = ClassVM.from_date;
            Class_to_cdp.MaxDate = ((DateTimeOffset)Class_from_cdp.Date).AddDays(365);
        }

        private void Class_to_cdp_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (Class_to_cdp.Date == null)
                Class_to_cdp.Date = ClassVM.to_date;
            DateTimeOffset min = ((DateTimeOffset)Class_to_cdp.Date).AddDays(-365);
            if (min > DateTime.Today) Class_from_cdp.MinDate = min;
            else                    Class_from_cdp.MinDate = DateTime.Today;
        }

        private void Class_repeating_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Class_repeating_cb.SelectedItem == No_cbi)
                Class_to_cdp.Visibility = Visibility.Collapsed;
            else
                Class_to_cdp.Visibility = Visibility.Visible;
        }

        private void Class_start_time_tp_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            Class_end_time_tp.Time = Class_start_time_tp.Time.Add(new TimeSpan(0, SettingsManager.GetStandartClassDuration(), 0));
        }
    }
}
