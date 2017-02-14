using SPlanner.BL;
using System;
using System.Collections.ObjectModel;

namespace SPlanner_UWP.ViewModel
{
    public class HolidaysViewModel
    {
        public ObservableCollection<Holidays> HolidaysCollection { get; set; }
        public Holidays Holidays { get; set; }

        public HolidaysViewModel()
        {
            HolidaysCollection = Holidays.SelectAll();
            Holidays = new Holidays();
        }
        public void AddHolidays()
        {
            Holidays.Create();
            HolidaysCollection.Add(Holidays);
        }
        public void EditHolidays()
        {
            Holidays.Update();
            HolidaysCollection[HolidaysCollection.IndexOf(Holidays)] = Holidays;
        }
        public void DeleteHolidays()
        {
            Holidays.Delete();
            HolidaysCollection.Remove(Holidays);
        }
    }
}
