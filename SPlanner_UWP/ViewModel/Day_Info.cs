﻿using SPlanner.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SPlanner_UWP.ViewModel
{
    public class Day_Info
    {
        public DateTime date { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        public bool isActualMonth { get; set; }
        public List<int> timeLimit { get; set; }

        public static ObservableCollection<Day_Info> GetInfo(DateTime from, DateTime to)
        {
            ObservableCollection<Day_Info> diCollection = new ObservableCollection<Day_Info>();
            Day_Info di = null;
            DateTime mydate = from;
            while (mydate <= to)
            {
                di = new Day_Info()
                {
                    date = mydate,
                    Classes = Class.SelectByDate(mydate),
                    Tasks = Task.SelectByDate(mydate)
                };
                SortClasses(di.Classes);
                diCollection.Add(di);
                mydate = mydate.AddDays(1);
            }
            return diCollection;
        }
        public static Day_Info GetDay(DateTime selected_date)
        {
            Day_Info di = new Day_Info();
            di.date = selected_date;
            di.Classes = Class.SelectByDate(selected_date);
            SortClasses(di.Classes);
            di.Tasks = Task.SelectByDate(selected_date);
            return di;
        }
        private static void SortClasses(ObservableCollection<Class> collection)
        {
            var list = collection.OrderBy(c => c.Start_time).ToList();
            collection.Clear();
            foreach (Class clas in list)
            {
                collection.Add(clas);
            }
        }
    }
}
