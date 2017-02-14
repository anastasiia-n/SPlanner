using DataAbstractionLayerSQLite;
using SPlanner.BL;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SPlanner.DAL
{
    static class ClassDAL
    {
        static string dbfile = Shared.dbfile;
        public static void CreateTable()
        {
            DB db = DB.getDB(dbfile);
            string sql = @"CREATE TABLE IF NOT EXISTS Class(
                id              INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                subject_id      INTEGER NOT NULL,
                name            VARCHAR(45) NOT NULL,
                start_time      TIME NOT NULL,
                end_time        TIME NOT NULL,
                location        VARCHAR(45),
                professor_id    INTEGER,
                CONSTRAINT fk_Class_Professor
                    FOREIGN KEY(professor_id)
                    REFERENCES Professor(id),
                CONSTRAINT fk_Class_Subject
                    FOREIGN KEY(subject_id)
                    REFERENCES Subject(id)); ";
            db.NonQuery(sql);
        }
        public static bool Create(Class inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"INSERT INTO Class (subject_id,name,start_time,end_time,location,professor_id)
                           VALUES (@subject_id,@name,@start_time,@end_time,@location,@professor_id)";
            if (inst.Location == "")
                sql = Shared.RemoveFromCreateQuery(sql, "location");
            if (inst.Professor_id == null)
                sql = Shared.RemoveFromCreateQuery(sql, "professor_id");
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@subject_id", inst.Subject_id);
            parms.Add("@name", inst.Name);
            parms.Add("@start_time", inst.Start_time.ToString());
            parms.Add("@end_time", inst.End_time.ToString());
            parms.Add("@location", inst.Location);
            parms.Add("@professor_id", inst.Professor_id);
            return db.NonQuery(sql, parms);
        }
        public static bool Update(Class inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"UPDATE Class 
            SET name=@name,start_time=@start_time,end_time=@end_time,location=@location,professor_id=@professor_id 
            WHERE id = @id";
            if (inst.Location == "")
                sql = Shared.RemoveFromCreateQuery(sql, "location");
            if (inst.Professor_id == 0)
                sql = Shared.RemoveFromCreateQuery(sql, "professor_id");
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            parms.Add("@name", inst.Name);
            parms.Add("@start_time", inst.Start_time.ToString());
            parms.Add("@end_time", inst.End_time.ToString());
            parms.Add("@location", inst.Location);
            parms.Add("@professor_id", inst.Professor_id);
            return db.NonQuery(sql, parms);
        }
        public static bool Delete(Class inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "DELETE FROM Class WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            return db.NonQuery(sql, parms);
        }
        public static Class SelectById(long id)
        {
            Class inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Class WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", id);
            var statement = db.Query(sql, parms);
            if (SQLiteResult.DONE == statement.Step())
            {
                inst = new Class()
                {
                    id = (int)statement[0],
                    Subject_id = (int)statement[1],
                    Name = (string)statement[2],
                    Start_time = (TimeSpan)statement[3],
                    End_time = (TimeSpan)statement[4],
                    Location = (string)statement[5],
                    Professor_id = (int?)statement[6]
                };
            }
            return inst;
        }
        public static ObservableCollection<Class> SelectAll()
        {
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Class";
            var statement = db.Query(sql);
            return CollectionToReturn(statement);
        }
        public static ObservableCollection<Class> SelectBySubject(Subject sub)
        {
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Class WHERE subject_id = @sid";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@sid", sub.id);
            var statement = db.Query(sql, parms);
            return CollectionToReturn(statement);
        }
        public static ObservableCollection<Class> GetClasses(DateTime from, DateTime to)
        {
            DB db = DB.getDB(dbfile);
            var sql = @"SELECT *
                FROM Class, Schedule
                WHERE Class.id=Schedule.class_id
                AND Schedule.date BETWEEN date(@from) AND date(@to)
                GROUP BY Class.id;";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@from", from.ToString(Shared.SQLiteDateFormat));
            parms.Add("@to", to.ToString(Shared.SQLiteDateFormat));
            var statement = db.Query(sql, parms);
            return CollectionToReturn(statement);
        }
        private static ObservableCollection<Class> CollectionToReturn(ISQLiteStatement statement)
        {
            var result = new ObservableCollection<Class>();
            Class inst;
            while (statement.Step() == SQLiteResult.ROW)
            {
                inst = new Class()
                {
                    id = (long)statement[0],
                    Subject_id = (long)statement[1],
                    Name = (string)statement[2],
                    Start_time = TimeSpan.Parse((string)statement[3]),
                    End_time = TimeSpan.Parse((string)statement[4]),
                    Location = (string)statement[5],
                    Professor_id = (long?)statement[6]
                };
                result.Add(inst);
            }
            return result;
        }
    }
}
