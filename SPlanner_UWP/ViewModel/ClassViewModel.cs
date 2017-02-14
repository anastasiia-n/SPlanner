using SPlanner.BL;
using System;
using System.Collections.ObjectModel;
using static SPlanner.BL.Class;

namespace SPlanner_UWP.ViewModel
{
    public class ClassViewModel
    {
        private ObservableCollection<Class> classCollection;
        public ObservableCollection<Class> ClassCollection
        {
            get { return classCollection; }
            set
            {
                if (value != classCollection)
                {
                    classCollection = value;
                    foreach (var item in classCollection)
                    {
                        item.subject = Subject.SelectById(item.Subject_id);
                        if (item.Professor_id != null)
                            item.professor = Professor.SelectById((long)item.Professor_id);
                    }
                }
            }
        }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
        public Class Class { get; set; }

        public ClassViewModel()
        {
            ClassCollection = Class.SelectAll();
        }
        public ClassViewModel(DateTime date)
        {
            ClassCollection = Class.SelectByDate(date);
        }

        private Repeating stringToRepeating(string str)
        {
            switch (str.ToLower())
            {
                case "week":
                    return Repeating.Week;
                case "twoweeks":
                    return Repeating.TwoWeeks;
                case "month":
                    return Repeating.Month;
                case "norepeat":
                    return Repeating.NoRepeat;
                default:
                    return Repeating.NoRepeat;
            }
        }
        internal void AddClass(string repeating)
        {
            Class.subject = Subject.SelectById(Class.Subject_id);
            if (Class.Professor_id != null)
                Class.professor = Professor.SelectById((long)Class.Professor_id);
            if (CheckExisting(Class)==null)
            {
                Class.Create(from_date, to_date, stringToRepeating(repeating));
                ClassCollection.Add(Class);
            }
            else
            {
                throw new Exception("The same class already exist");
            }
        }
        internal void EditClass()
        {
            Class.subject = Subject.SelectById(Class.Subject_id);
            if (Class.Professor_id != null)
                Class.professor = Professor.SelectById((long)Class.Professor_id);
            var exClass = CheckExisting(Class);
            if (exClass == null || exClass.id==Class.id)
            {
                Class.Update();
                ClassCollection[ClassCollection.IndexOf(Class)] = Class;
            }
            else
            {
                throw new Exception("The same class already exist");
            }
        }
        internal void EditSchedule(string repeating)
        {
            if (stringToRepeating(repeating) == Repeating.NoRepeat)
                to_date = from_date;
            Class.UpdateSchedule(from_date, to_date, stringToRepeating(repeating));
        }
        internal void DeleteClass()
        {
            Class.Delete();
            ClassCollection.Remove(Class);
        }
        private Class CheckExisting(Class cl)
        {
            foreach (var item in ClassCollection)
            {
                if (item.Name == cl.Name && item.Subject_id == cl.Subject_id)
                    return item;
            }
            return null;
        }
    }
}
