using DataAbstractionLayerSQLite;
using SPlanner.BL;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SPlanner.DAL
{
    class ScheduleDAL
    {
        static string dbfile = Shared.dbfile;
        public static void CreateTable()
        {
            DB db = DB.getDB(dbfile);
            string sql = @"CREATE TABLE IF NOT EXISTS Schedule(
                id        INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                class_id  INTEGER NOT NULL,
                date      DATE,
                CONSTRAINT fk_Schedule_Class1
                    FOREIGN KEY(class_id)
                    REFERENCES Class(id)); ";
            db.NonQuery(sql);
        }
        public static bool Create(Schedule inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "INSERT INTO Schedule (class_id,date) VALUES (@class_id,@date)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@class_id", inst.Class_id);
            parms.Add("@date", inst.Date.ToString(Shared.SQLiteDateFormat));
            return db.NonQuery(sql, parms);
        }
        public static bool Delete(long class_id)
        {
            DB db = DB.getDB(dbfile);
            string sql = "DELETE FROM Schedule WHERE class_id = @class_id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@class_id", class_id);
            return db.NonQuery(sql, parms);
        }
        public static ObservableCollection<Schedule> GetSchedule(Class _class, DateTime from, DateTime to)
        {
            DB db = DB.getDB(dbfile);
            var sql = @"SELECT *
                FROM Schedule
                WHERE class_id=@class_id
                AND date BETWEEN date(@from) AND date(@to);";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@class_id", _class.id);
            parms.Add("@from", from.ToString(Shared.SQLiteDateFormat));
            parms.Add("@to", to.ToString(Shared.SQLiteDateFormat));
            var statement = db.Query(sql, parms);
            return CollectionToReturn(statement);
        }
        public static ObservableCollection<Schedule> GetSchedule(DateTime from, DateTime to)
        {
            DB db = DB.getDB(dbfile);
            var sql = @"SELECT *
                FROM Schedule
                WHERE date BETWEEN date(@from) AND date(@to);";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@from", from.ToString(Shared.SQLiteDateFormat));
            parms.Add("@to", to.ToString(Shared.SQLiteDateFormat));
            var statement = db.Query(sql, parms);
            return CollectionToReturn(statement);
        }
        private static ObservableCollection<Schedule> CollectionToReturn(ISQLiteStatement statement)
        {
            var result = new ObservableCollection<Schedule>();
            Schedule inst = null;
            while (statement.Step() == SQLiteResult.ROW)
            {
                inst = new Schedule()
                {
                    id = (long)statement[0],
                    Class_id = (long)statement[1],
                    Date = DateTime.Parse((string)statement[2]),
                };
                result.Add(inst);
            }
            return result;
        }
    }
}
