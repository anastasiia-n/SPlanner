using SPlanner.DAL;
using System;
using System.Collections.ObjectModel;

namespace SPlanner.BL
{
    public class Task
    {
        public long id { get; set; }
        public long Subject_id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Deadline { get; set; }
        public bool Done { get; set; }

        public Subject subject { get; set; }

        public Task()
        {
            this.Date = DateTime.Now;
        }
        public static void CreateTable()
        {
            TaskDAL.CreateTable();
        }

        public bool Create()
        {
            if (this.Subject_id == 0)
                return false;
            else
                return (TaskDAL.Create(this));
        }

        public bool Update()
        {
            if (this.Subject_id == 0)
                return false;
            else
                return (TaskDAL.Update(this));
        }

        public bool Delete()
        {
            return (TaskDAL.Delete(this));
        }

        public static Task SelectById(long id)
        {
            if (id > 0)
                return TaskDAL.SelectById(id);
            else
                return null;
        }

        public static ObservableCollection<Task> SelectAll()
        {
            return TaskDAL.SelectAll();
        }

        public static ObservableCollection<Task> SelectByDate(DateTime from, DateTime to)
        {
            if (from < to)
                return TaskDAL.SelectByDate(from, to);
            else
                return null;
        }

        public static ObservableCollection<Task> SelectByDate(DateTime date)
        {
            return TaskDAL.SelectByDate(date, date);
        }

        public static int GetTaskCount(DateTime from, DateTime to)
        {
            if (from < to)
            {
                var result = TaskDAL.SelectByDate(from, to);
                return result.Count;
            }
            else
                return 0;
        }
    }
}
