using SPlanner.DAL;
using System;
using System.Collections.ObjectModel;

namespace SPlanner.BL
{
    public class Class
    {
        public enum Repeating { Week, TwoWeeks, Month, NoRepeat }
        public long id { get; set; }
        public long Subject_id { get; set; }
        public string Name { get; set; }
        public TimeSpan Start_time { get; set; }
        public TimeSpan End_time { get; set; }
        public string Location { get; set; }
        public long? Professor_id { get; set; }

        //noDB properties
        public Subject subject { get; set; }
        public Professor professor { get; set; }
        public int duration { get; set; }
        public int diff { get; set; }

        public static void CreateTable()
        {
            ClassDAL.CreateTable();
        }

        public bool Create(DateTime from_date, DateTime to_date, Repeating rep)
        {
            if (ClassDAL.Create(this))
            {
                var collection = Class.SelectAll();
                this.id = collection[collection.Count - 1].id;
                return CreateSchedule(from_date, to_date, rep);
            }
            else
                return false;
        }

        public bool Update()
        {
            return (ClassDAL.Update(this));
        }

        public bool Delete()
        {
            ClassDAL.Delete(this);
            Schedule.DeleteByClassId(this.id);
            return true;
        }

        private bool CreateSchedule(DateTime from_date, DateTime to_date, Repeating rep)
        {
            if (to_date >= from_date)
            {
                TimeSpan difference = to_date - from_date;
                if (difference.Days <= 365) //to don't add too many rows in DB
                {
                    var date = from_date;
                    //Schedule.DeleteByClassId(this.id);
                    Schedule sched = new Schedule();
                    sched.Class_id = this.id;

                    switch (rep)
                    {
                        case Repeating.Week:
                            while (date <= to_date)
                            {
                                sched.Date = date;
                                sched.Create();
                                date = date.AddDays(7);
                            }
                            break;
                        case Repeating.TwoWeeks:
                            while (date <= to_date)
                            {
                                sched.Date = date;
                                sched.Create();
                                date = date.AddDays(14);
                            }
                            break;
                        case Repeating.Month:
                            while (date <= to_date)
                            {
                                sched.Date = date;
                                sched.Create();
                                date = date.AddMonths(1);
                            }
                            break;
                        case Repeating.NoRepeat:
                            sched.Date = date;
                            sched.Create();
                            break;
                        default:
                            return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSchedule(DateTime from_date, DateTime to_date, Repeating rep)
        {
            if (to_date >= from_date)
            {
                TimeSpan difference = to_date - from_date;
                if (difference.Days <= 365) //to don't add too many rows in DB
                {
                    Schedule.DeleteByClassId(this.id);
                    return CreateSchedule(from_date, to_date, rep);
                }
            }
            return false;
        }

        public static Class SelectById(long id)
        {
            if (id > 0)
                return ClassDAL.SelectById(id);
            else
                return null;
        }

        public static ObservableCollection<Class> SelectAll()
        {
            return ClassDAL.SelectAll();
        }

        public static ObservableCollection<Class> SelectBySubject(Subject sub)
        {
            if (sub.id != 0)
                return ClassDAL.SelectBySubject(sub);
            else
                return null;
        }

        public static ObservableCollection<Class> SelectByDate(DateTime from, DateTime to)
        {
            if (from < to)
                return ClassDAL.GetClasses(from, to);
            else
                return null;
        }

        public static ObservableCollection<Class> SelectByDate(DateTime date)
        {
            return ClassDAL.GetClasses(date, date);
        }

        public ObservableCollection<Schedule> GetSchedule(DateTime from, DateTime to)
        {
            return Schedule.GetSchedule(this, from, to);
        }

        public Professor GetProfessor()
        {
            if (this.Professor_id != null)
                return Professor.SelectById((long)this.Professor_id);
            else
                return null;
        }

        public Subject GetSubject()
        {
            return Subject.SelectById(this.Subject_id);
        }
    }
}
