using SPlanner.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace SPlanner_UWP.ViewModel
{
    public class MonthViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Day_Info> day_Month_InfoCollection;
        public ObservableCollection<Day_Info> Day_Month_InfoCollection
        {
            get { return day_Month_InfoCollection; }
            set
            {
                if (value != day_Month_InfoCollection)
                {
                    day_Month_InfoCollection = value;
                    foreach (var item in day_Month_InfoCollection)
                    {
                        if (item.date.Month != SelectedDate.Month)
                            item.isActualMonth = false;
                        else item.isActualMonth = true;
                    }
                    NotifyPropertyChanged();
                }
            }
        }
        public List<string> daysOfWeek = new List<string>();
        public Day_Info SelectedDay { get; set; }
        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (value != selectedDate)
                {
                    selectedDate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MonthViewModel(DateTime date)
        {
            SelectedDay = Day_Info.GetDay(date);
            SelectedDate = date;
            var first = Shared.FirstDayOfWeek(Shared.FirstDayOfMonth(date));
            var last = Shared.FirstDayOfWeek(Shared.LastDayOfMonth(date)).AddDays(6);
            Day_Month_InfoCollection = Day_Info.GetInfo(first, last);

            //add days of week
            DateTime day = Shared.FirstDayOfWeek(DateTime.Today);
            for (int i = 0; i < 7; i++)
            {
                daysOfWeek.Add(day.ToString("ddd", CultureInfo.CurrentCulture));
                day = day.AddDays(1);
            }
        }
        public void ChangeCollection(DateTime date)
        {
            SelectedDate = date;
            Day_Month_InfoCollection = Day_Info.GetInfo(Shared.FirstDayOfWeek(Shared.FirstDayOfMonth(date)),
                Shared.FirstDayOfWeek(Shared.LastDayOfMonth(date)).AddDays(6));
        }
    }
}