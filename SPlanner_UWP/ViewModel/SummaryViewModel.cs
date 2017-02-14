using SPlanner.BL;
using SPlanner.DAL;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SPlanner_UWP.ViewModel
{
    public class SummaryViewModel : INotifyPropertyChanged
    {
        public DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<int> countCollection;
        public SummaryViewModel()
        {
            Date = DateTime.Today;
            countCollection = new ObservableCollection<int>() { 0, 0, 0, 0 };
            Calculate();
        }
        internal void GoToNextMonth()
        {
            Date = Date.AddMonths(1);
            Calculate();
        }
        internal void GoToPrevMonth()
        {
            Date = Date.AddMonths(-1);
            Calculate();
        }
        private void Calculate()
        {
            var first = Shared.FirstDayOfMonth(Date);
            var last = Shared.LastDayOfMonth(Date);
            //tasks count
            countCollection[0] = Task.GetTaskCount(first, last);
            //classes count
            countCollection[1] = Schedule.GetSchedule(first, last).Count;
            //busy days count
            countCollection[2] = Schedule.GetBusyDaysCount(first, last);
            //free days count
            countCollection[3] = last.Day - countCollection[2];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
