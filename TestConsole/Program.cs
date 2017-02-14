
//#define CREATE
//#define CLEAR
//#define UPDATE
//#define DELETE

using SPlanner.BL;
using SPlanner.DAL;
using System;
using System.Collections.ObjectModel;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Professor> collProfessor;
            ObservableCollection<Subject> collSubject;
            ObservableCollection<Class> collClass;
            ObservableCollection<Schedule> collSchedule;
            ObservableCollection<Task> collTasks;
            ObservableCollection<Holidays> collHolidays;

            Professor.CreateTable();
            Subject.CreateTable();
            Class.CreateTable();
            Schedule.CreateTable();
            Task.CreateTable();
            Holidays.CreateTable();
#if CLEAR
            Shared.ClearTables("Class");
            Shared.ClearTables("Schedule");
            Shared.ClearTables("Task");
            Shared.ClearTables("Holidays");
            Shared.ClearTables("Professor");
            Shared.ClearTables("Subject");
#endif
#if CREATE
            #region ProfessorCreating
            Professor p0 = new Professor() { Name = "John Smith", Office = "23B" };
            p0.Create();
            Professor p1 = new Professor() { Name = "Randall Morrison", Email = "ran@mail.com", Office = "11" };
            p1.Create();
            Professor p2 = new Professor() { Name = "Howard Howell", Email = "how@mail.com" };
            p2.Create();
            Professor p3 = new Professor() { Name = "Mathew Lyons" };
            p3.Create();
            Professor p4 = new Professor() { Name = "Annie Roberson", Office = "43" };
            p4.Create();
            #endregion
            #region SubjectCreating
            Subject s0 = new Subject() { Name = "Math" };
            s0.Create();
            Subject s1 = new Subject() { Name = "Programming" };
            s1.Create();
            Subject s2 = new Subject() { Name = "Electronics" };
            s2.Create();
            Subject s3 = new Subject() { Name = "Some subject" };
            s3.Create();
            #endregion
            #region ClassCreating
            Class c0 = new Class()
            {
                Name = "Theory",
                Start_time = new TimeSpan(15, 00, 00),
                End_time = new TimeSpan(16, 00, 00),
                Location = "112",
                Subject_id = Subject.SelectAll()[1].id,
                Professor_id = Professor.SelectAll()[0].id
            };
            c0.Create(DateTime.Today, DateTime.Today.AddDays(120), Class.Repeating.Week);

            Class c1 = new Class()
            {
                Name = "Practice",
                Start_time = new TimeSpan(9, 00, 00),
                End_time = new TimeSpan(11, 00, 00),
                Location = "102",
                Subject_id = Subject.SelectAll()[2].id,
                Professor_id = Professor.SelectAll()[1].id
            };
            c1.Create(DateTime.Today.AddDays(2), DateTime.Today.AddDays(120), Class.Repeating.TwoWeeks);

            Class c2 = new Class()
            {
                Name = "Statistics",
                Start_time = new TimeSpan(16, 00, 00),
                End_time = new TimeSpan(17, 30, 00),
                Location = "205",
                Subject_id = Subject.SelectAll()[0].id,
                Professor_id = Professor.SelectAll()[2].id
            };
            c2.Create(DateTime.Today.AddDays(-10), DateTime.Today.AddDays(60), Class.Repeating.Week);

            Class c3 = new Class()
            {
                Name = "C#",
                Start_time = new TimeSpan(14, 00, 00),
                End_time = new TimeSpan(16, 00, 00),
                Location = "302",
                Subject_id = Subject.SelectAll()[1].id,
                Professor_id = Professor.SelectAll()[3].id
            };
            c3.Create(DateTime.Today.AddDays(2), DateTime.Today.AddDays(120), Class.Repeating.TwoWeeks);
            #endregion(+Schedule)
            #region HolidayCreating
            Holidays h0 = new Holidays() { Start_date = DateTime.Parse("12.12.2016"), End_date = DateTime.Parse("5.1.2017") };
            h0.Create();
            Holidays h1 = new Holidays() { Start_date = DateTime.Parse("12.2.2017"), End_date = DateTime.Parse("15.2.2017") };
            h1.Create();
            #endregion
            #region TasksCreating
            Tasks t0 = new Tasks()
            {
                Subject_id = Subject.SelectAll()[0].id,
                Text = "my homework: chapter 1.3, exerc 2,6,7",
                Deadline = DateTime.Parse("10.12.2016")
            };
            t0.Create();
            Tasks t1 = new Tasks()
            {
                Subject_id = Subject.SelectAll()[1].id,
                Text = "some notes: blablablablabla"
            };
            t1.Create();
            #endregion
#endif
            //*
            #region Selects
            Console.WriteLine("----Professors:----");
            collProfessor = Professor.SelectAll();
            foreach (var item in collProfessor)
            {
                Console.WriteLine(item.id + "; " + item.Name + "; " + item.Email + "; " + item.Office);
            }

            Console.WriteLine("\n----Subjects:----");
            collSubject = Subject.SelectAll();
            foreach (var item in collSubject)
            {
                Console.WriteLine(item.id + "; " + item.Name);
            }

            Console.WriteLine("\n----Classes:----");
            collClass = Class.SelectAll();
            foreach (var item in collClass)
            {
                Console.WriteLine(item.id + "; " + item.Name + "; " + item.Start_time + "; " +
                    item.End_time + "; " + item.Location + " - " +
                    item.GetProfessor().Name + ", " + item.GetSubject().Name);
            }
            Console.WriteLine("For the next 5 days:");
            collClass = Class.SelectByDate(DateTime.Today, DateTime.Today.AddDays(5));
            foreach (var item in collClass)
            {
                Console.WriteLine(item.id + "; " + item.Name + "; " + item.Start_time + "; " +
                    item.End_time + "; " + item.Location + " - " +
                    item.GetProfessor().Name + ", " + item.GetSubject().Name);
            }

            Console.WriteLine("\n----Holidays:----");
            collHolidays = Holidays.SelectAll();
            foreach (var item in collHolidays)
            {
                Console.WriteLine(item.id + "; " + string.Format("{0:MM/dd/yyyy}", item.Start_date) + " - " + string.Format("{0:MM/dd/yyyy}", item.End_date));
            }
            Console.WriteLine("For the next 40 days:");
            collHolidays = Holidays.SelectByDate(DateTime.Today, DateTime.Today.AddDays(40));
            foreach (var item in collHolidays)
            {
                Console.WriteLine(item.id + "; " + string.Format("{0:MM/dd/yyyy}", item.Start_date) + " - " + string.Format("{0:MM/dd/yyyy}", item.End_date));
            }

            Console.WriteLine("\n----Tasks:----");
            collTasks = Task.SelectAll();
            foreach (var item in collTasks)
            {
                Console.WriteLine(item.id + "; " + string.Format("{0:MM/dd/yyyy}", item.Date) + "; '" + item.Text + "'; " + item.Deadline);
            }

            Console.WriteLine("\n----Schedule for this month:----");
            collSchedule = Schedule.GetSchedule(Shared.FirstDayOfMonth(DateTime.Today), Shared.LastDayOfMonth(DateTime.Today));
            Console.WriteLine("Busy days: " + Schedule.GetBusyDaysCount(Shared.FirstDayOfMonth(DateTime.Today), Shared.LastDayOfMonth(DateTime.Today)));
            foreach (var item in collSchedule)
            {
                Console.WriteLine(item.id + "; " + item.Class_id + "; " + string.Format("{0:MM/dd/yyyy}", item.Date));
            }
            #endregion
            //*/
#if UPDATE
            Professor updateProf = Professor.SelectByName("John Smith");
            updateProf.Email = "new@email.com";
            updateProf.Update();
#endif

#if DELETE
            Subject deleteSub = Subject.SelectByName("Some subject");
            deleteSub.Delete();
#endif
            //*/


            Console.ReadKey();
        }
    }
}
