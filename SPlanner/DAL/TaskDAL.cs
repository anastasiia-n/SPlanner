using DataAbstractionLayerSQLite;
using SPlanner.BL;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SPlanner.DAL
{
    class TaskDAL
    {
        static string dbfile = Shared.dbfile;
        public static void CreateTable()
        {
            DB db = DB.getDB(dbfile);
            string sql = @"CREATE TABLE IF NOT EXISTS Task(
                    id         INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    text       VARCHAR(100) NOT NULL,
                    date       DATE NOT NULL,
                    subject_id INTEGER,
                    deadline   DATE,
                    done       INT DEFAULT 0,
                    CONSTRAINT fk_Task_Subject
                    FOREIGN KEY(subject_id)
                    REFERENCES Subject(id)); ";
            db.NonQuery(sql);
        }

        public static bool Create(Task inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"INSERT INTO Task (text,date,subject_id,deadline,done)
                            VALUES (@text,@date,@subject_id,@deadline,@done)";
            if (inst.Deadline == null)
                sql = Shared.RemoveFromCreateQuery(sql, "deadline");
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@text", inst.Text);
            parms.Add("@date", inst.Date.ToString(Shared.SQLiteDateFormat));
            parms.Add("@subject_id", inst.Subject_id);
            parms.Add("@done", inst.Done ? 1 : 0);
            if (inst.Deadline != null)
                parms.Add("@deadline", ((DateTime)inst.Deadline).ToString(Shared.SQLiteDateFormat));
            return db.NonQuery(sql, parms);
        }
        public static bool Update(Task inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"UPDATE Task 
                SET text = @text, date = @date, subject_id = @subject_id, deadline = @deadline, done=@done
                WHERE id = @id";
            if (inst.Subject_id == 0)
                sql = Shared.RemoveFromUpdateQuery(sql, "subject_id");
            if (inst.Deadline == default(DateTime))
                sql = Shared.RemoveFromUpdateQuery(sql, "deadline");
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            parms.Add("@text", inst.Text);
            parms.Add("@date", inst.Date.ToString(Shared.SQLiteDateFormat));
            parms.Add("@subject_id", inst.Subject_id);
            parms.Add("@done", Convert.ToInt64(inst.Done));
            if (inst.Deadline != null)
                parms.Add("@deadline", ((DateTime)inst.Deadline).ToString(Shared.SQLiteDateFormat));
            return db.NonQuery(sql, parms);
        }
        public static bool Delete(Task inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "DELETE FROM Task WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            return db.NonQuery(sql, parms);
        }
        public static Task SelectById(long id)
        {
            Task inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Subject WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", id);
            var statement = db.Query(sql, parms);
            if (SQLitePCL.SQLiteResult.DONE == statement.Step())
            {
                inst = new Task()
                {
                    id = (int)statement[0],
                    Text = (string)statement[1],
                    Date = DateTime.Parse((string)statement[2]),
                    Subject_id = (int)statement[3],
                    Done = ((long)statement[5] == 1)
                };
                if (statement[4] == null) inst.Deadline = null;
                else inst.Deadline = DateTime.Parse(statement[4].ToString());
            }
            return inst;
        }
        public static ObservableCollection<Task> SelectAll()
        {
            DB db = DB.getDB(dbfile);
            var sql = @"SELECT * FROM Task;";
            var statement = db.Query(sql);
            return CollectionToReturn(statement);
        }
        public static ObservableCollection<Task> SelectByDate(DateTime from, DateTime to)
        {
            DB db = DB.getDB(dbfile);
            var sql = @"SELECT * 
                FROM Task
                WHERE date BETWEEN date(@from) AND date(@to);";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@from", from.ToString(Shared.SQLiteDateFormat));
            parms.Add("@to", to.ToString(Shared.SQLiteDateFormat));
            var statement = db.Query(sql, parms);
            return CollectionToReturn(statement);
        }
        private static ObservableCollection<Task> CollectionToReturn(ISQLiteStatement statement)
        {
            var result = new ObservableCollection<Task>();
            Task inst = null;
            while (statement.Step() == SQLiteResult.ROW)
            {
                inst = new Task()
                {
                    id = (long)statement[0],
                    Text = (string)statement[1],
                    Date = DateTime.Parse((string)statement[2]),
                    Subject_id = (long)statement[3],
                    Done = ((long)statement[5] == 1)
                };
                if (statement[4] == null) inst.Deadline = null;
                else inst.Deadline = DateTime.Parse(statement[4].ToString());
                result.Add(inst);

            }
            return result;
        }
    }
}
