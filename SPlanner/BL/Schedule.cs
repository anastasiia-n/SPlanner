using SPlanner.DAL;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SPlanner.BL
{
    public class Schedule
    {
        public long id { get; set; }
        public long Class_id { get; set; }
        public DateTime Date { get; set; }

        public static void CreateTable()
        {
            ScheduleDAL.CreateTable();
        }

        public bool Create()
        {
            return (ScheduleDAL.Create(this));
        }

        public static bool DeleteByClassId(long id)
        {
            if (id > 0) return (ScheduleDAL.Delete(id));
            else return false;
        }

        public static ObservableCollection<Schedule> GetSchedule(Class inst, DateTime from, DateTime to)
        {
            if (from < to)
                return ScheduleDAL.GetSchedule(inst, from, to);
            else
                return null;
        }

        public static ObservableCollection<Schedule> GetSchedule(DateTime from, DateTime to)
        {
            if (from < to)
                return ScheduleDAL.GetSchedule(from, to);
            else
                return null;
        }

        public static int GetBusyDaysCount(DateTime from, DateTime to)
        {
            if (from < to)
            {
                var result = ScheduleDAL.GetSchedule(from, to).Select(s => s.Date).Distinct();
                return result.Count();
            }
            else
                return 0;
        }
    }
}
