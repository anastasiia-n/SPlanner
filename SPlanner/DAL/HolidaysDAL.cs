using DataAbstractionLayerSQLite;
using SPlanner.BL;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SPlanner.DAL
{
    class HolidaysDAL
    {
        static string dbfile = Shared.dbfile;
        public static void CreateTable()
        {
            DB db = DB.getDB(dbfile);
            string sql = @"CREATE TABLE IF NOT EXISTS Holidays(
                    id          INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    start_date  DATE NOT NULL,
                    end_date    DATE NOT NULL); ";
            db.NonQuery(sql);
        }
        public static bool Create(Holidays inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"INSERT INTO Holidays (start_date,end_date) 
                            VALUES (@start_date,@end_date)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@start_date", inst.Start_date.ToString(Shared.SQLiteDateFormat));
            parms.Add("@end_date", inst.End_date.ToString(Shared.SQLiteDateFormat));
            return db.NonQuery(sql, parms);
        }
        public static bool Update(Holidays inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"UPDATE Holidays 
                SET start_date = @start_date, end_date = @end_date 
                WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            parms.Add("@start_date", inst.Start_date.ToString(Shared.SQLiteDateFormat));
            parms.Add("@end_date", inst.End_date.ToString(Shared.SQLiteDateFormat));
            return db.NonQuery(sql, parms);
        }
        public static bool Delete(Holidays inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "DELETE FROM Holidays WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            return db.NonQuery(sql, parms);
        }
        public static Holidays SelectById(long id)
        {
            Holidays inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Holidays WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", id);
            var statement = db.Query(sql, parms);
            if (SQLiteResult.DONE == statement.Step())
            {
                inst = new Holidays()
                {
                    id = (long)statement[0],
                    Start_date = (DateTime)statement[1],
                    End_date = (DateTime)statement[2],
                };
            }
            return inst;
        }
        public static ObservableCollection<Holidays> SelectAll()
        {
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Holidays";
            var statement = db.Query(sql);
            return CollectionToReturn(statement);
        }
        public static ObservableCollection<Holidays> GetHolidays(DateTime from, DateTime to)
        {
            DB db = DB.getDB(dbfile);
            var sql = @"SELECT * 
                FROM Holidays
                WHERE start_date BETWEEN date(@from) AND date(@to)
                OR end_date BETWEEN date(@from) AND date(@to);";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@from", from.ToString(Shared.SQLiteDateFormat));
            parms.Add("@to", to.ToString(Shared.SQLiteDateFormat));
            var statement = db.Query(sql, parms);
            return CollectionToReturn(statement);
        }
        public static ObservableCollection<Holidays> GetHolidays(DateTime from)
        {
            DB db = DB.getDB(dbfile);
            var sql = @"SELECT * 
                FROM Holidays
                WHERE end_date >= date(@from);";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@from", from.ToString(Shared.SQLiteDateFormat));
            var statement = db.Query(sql, parms);
            return CollectionToReturn(statement);
        }
        private static ObservableCollection<Holidays> CollectionToReturn(ISQLiteStatement statement)
        {
            var result = new ObservableCollection<Holidays>();
            Holidays inst = null;
            while (statement.Step() == SQLiteResult.ROW)
            {
                inst = new Holidays()
                {
                    id = (long)statement[0],
                    Start_date = DateTime.Parse((string)statement[1]),
                    End_date = DateTime.Parse((string)statement[2]),
                };
                result.Add(inst);
            }
            return result;
        }
    }
}
