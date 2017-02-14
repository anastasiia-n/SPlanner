using DataAbstractionLayerSQLite;
using SPlanner.BL;
using SQLitePCL;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SPlanner.DAL
{
    class SubjectDAL
    {
        static string dbfile = Shared.dbfile;
        public static void CreateTable()
        {
            DB db = DB.getDB(dbfile);
            string sql = @"CREATE TABLE IF NOT EXISTS Subject(
                    id     INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    name   VARCHAR(45) NOT NULL UNIQUE); ";
            db.NonQuery(sql);
        }
        public static bool Create(Subject inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "INSERT INTO Subject (name) VALUES (@name)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@name", inst.Name);
            return db.NonQuery(sql, parms);
        }
        public static bool Update(Subject inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"UPDATE Subject 
                SET name = @name
                WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            parms.Add("@name", inst.Name);
            return db.NonQuery(sql, parms);
        }
        public static bool Delete(Subject inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "DELETE FROM Subject WHERE id = (@id)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            return db.NonQuery(sql, parms);
        }
        public static Subject SelectById(long id)
        {
            Subject inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Subject WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", id);
            var statement = db.Query(sql, parms);
            if (SQLiteResult.ROW == statement.Step())
            {
                inst = new Subject()
                {
                    id = (long)statement[0],
                    Name = (string)statement[1]
                };
            }
            return inst;
        }
        public static Subject SelectByName(string name)
        {
            Subject inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Subject WHERE name = @name";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@name", name);
            var statement = db.Query(sql, parms);
            if (SQLiteResult.ROW == statement.Step())
            {
                inst = new Subject()
                {
                    id = (long)statement[0],
                    Name = (string)statement[1]
                };
            }
            return inst;
        }
        public static ObservableCollection<Subject> SelectAll()
        {
            var result = new ObservableCollection<Subject>();
            Subject inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Subject";
            var statement = db.Query(sql);
            while (statement.Step() == SQLiteResult.ROW)
            {
                inst = new Subject()
                {
                    id = (long)statement[0],
                    Name = (string)statement[1]
                };
                result.Add(inst);
            }
            return result;
        }
    }
}
