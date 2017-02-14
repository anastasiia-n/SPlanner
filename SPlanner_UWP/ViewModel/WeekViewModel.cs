using SPlanner.BL;
using SPlanner.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SPlanner_UWP.ViewModel
{
    public class WeekViewModel : INotifyPropertyChanged
    {
        public List<int> timeLimit { get; set; }
        private ObservableCollection<Day_Info> day_Week_InfoCollection;
        public ObservableCollection<Day_Info> Day_Week_InfoCollection
        {
            get { return day_Week_InfoCollection; }
            set
            {
                if (value != day_Week_InfoCollection)
                {
                    day_Week_InfoCollection = value;
                    foreach (var day in day_Week_InfoCollection)
                    {
                        day.timeLimit = this.timeLimit;
                        foreach (var item in day.Classes)
                        {
                            item.duration = (item.End_time.Hours - item.Start_time.Hours) * 60
                                + item.End_time.Minutes - item.Start_time.Minutes;
                            item.subject = Subject.SelectById(item.Subject_id);
                            if (item.Professor_id != null)
                                item.professor = Professor.SelectById((long)item.Professor_id);
                        }
                    }
                    NotifyPropertyChanged();
                }
            }
        }
        private Day_Info selectedDay;
        public Day_Info SelectedDay
        {
            get { return selectedDay; }
            set
            {
                if (value != selectedDay && value!=null) 
                {
                    selectedDay = value;
                    foreach (var item in selectedDay.Classes)
                    {
                        item.subject = Subject.SelectById(item.Subject_id);
                        if(item.Professor_id!=null)
                            item.professor = Professor.SelectById((long)item.Professor_id);
                    }
                }
            }
        }
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
        public WeekViewModel(DateTime date)
        {
            timeLimit = new List<int>();
            for (int i = 6; i < 22; i++)
            {
                timeLimit.Add(i);
            }
            SelectedDay = Day_Info.GetDay(date);
            SelectedDate = date;
            Day_Week_InfoCollection = Day_Info.GetInfo(Shared.FirstDayOfWeek(date),
                Shared.FirstDayOfWeek(date).AddDays(6));
        }
        public void ChangeCollection(DateTime date)
        {
            SelectedDate = date;
            Day_Week_InfoCollection = Day_Info.GetInfo(Shared.FirstDayOfWeek(date),
                Shared.FirstDayOfWeek(date).AddDays(6));
        }
    }
}
