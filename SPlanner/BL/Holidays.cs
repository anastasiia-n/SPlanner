using SPlanner.DAL;
using System;
using System.Collections.ObjectModel;

namespace SPlanner.BL
{
    public class Holidays
    {
        public long id { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }

        public static void CreateTable()
        {
            HolidaysDAL.CreateTable();
        }

        public bool Create()
        {
            if (this.End_date < this.Start_date)
                return false;
            else
                return (HolidaysDAL.Create(this));
        }

        public bool Update()
        {
            return (HolidaysDAL.Update(this));
        }

        public bool Delete()
        {
            return (HolidaysDAL.Delete(this));
        }

        public static Holidays SelectById(long id)
        {
            if (id > 0)
                return HolidaysDAL.SelectById(id);
            else
                return null;
        }

        public static ObservableCollection<Holidays> SelectAll()
        {
            return HolidaysDAL.SelectAll();
        }

        public static ObservableCollection<Holidays> SelectByDate(DateTime from)
        {
            return HolidaysDAL.GetHolidays(from);
        }

        public static ObservableCollection<Holidays> SelectByDate(DateTime from, DateTime to)
        {
            return HolidaysDAL.GetHolidays(from, to);
        }

        public static int GetHolidaysCount(DateTime from, DateTime to)
        {
            if (from < to)
            {
                int result = 0;
                var holidays = HolidaysDAL.GetHolidays(from, to);
                foreach (Holidays item in holidays)
                {
                    var first = (item.Start_date >= from) ? item.Start_date : from;
                    var last = (item.End_date <= to) ? item.End_date : to;
                    result += (last - first).Days;
                }
                return result;
            }
            else
                return 0;
        }
    }
}
