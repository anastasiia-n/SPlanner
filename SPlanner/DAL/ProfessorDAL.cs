using DataAbstractionLayerSQLite;
using SPlanner.BL;
using SQLitePCL;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SPlanner.DAL
{
    static class ProfessorDAL
    {
        static string dbfile = Shared.dbfile;
        public static void CreateTable()
        {
            DB db = DB.getDB(dbfile);
            string sql = @"CREATE TABLE IF NOT EXISTS Professor(
                    id     INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    name   VARCHAR(45) NOT NULL UNIQUE,
                    email  VARCHAR(45),
                    office VARCHAR(45));";
            db.NonQuery(sql);
        }
        public static bool Create(Professor inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "INSERT INTO Professor (name,email,office) VALUES (@name,@email,@office)";
            if (inst.Email == "")
                sql = Shared.RemoveFromCreateQuery(sql, "email");
            if (inst.Office == "")
                sql = Shared.RemoveFromCreateQuery(sql, "office");
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@name", inst.Name);
            parms.Add("@email", inst.Email);
            parms.Add("@office", inst.Office);
            return db.NonQuery(sql, parms);
        }
        public static bool Update(Professor inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = @"UPDATE Professor 
                SET name = @name, email = @email, office = @office 
                WHERE id = @id";
            if (inst.Email == "")
                sql = Shared.RemoveFromUpdateQuery(sql, "email");
            if (inst.Office == "")
                sql = Shared.RemoveFromUpdateQuery(sql, "office");
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            parms.Add("@name", inst.Name);
            parms.Add("@email", inst.Email);
            parms.Add("@office", inst.Office);
            return db.NonQuery(sql, parms);
        }
        public static bool Delete(Professor inst)
        {
            DB db = DB.getDB(dbfile);
            string sql = "DELETE FROM Professor WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", inst.id);
            return db.NonQuery(sql, parms);
        }
        public static Professor SelectById(long id)
        {
            Professor inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Professor WHERE id = @id";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@id", id);
            var statement = db.Query(sql, parms);
            if (SQLiteResult.ROW == statement.Step())
            {
                inst = new Professor()
                {
                    id = (long)statement[0],
                    Name = (string)statement[1],
                    Email = (string)statement[2],
                    Office = (string)statement[3]
                };
            }
            return inst;
        }
        public static Professor SelectByName(string name)
        {
            Professor inst = null;
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Professor WHERE name = @name";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@name", name);
            var statement = db.Query(sql, parms);
            if (SQLiteResult.ROW == statement.Step())
            {
                inst = new Professor()
                {
                    id = (long)statement[0],
                    Name = (string)statement[1],
                    Email = (string)statement[2],
                    Office = (string)statement[3]
                };
            }
            return inst;
        }
        public static ObservableCollection<Professor> SelectAll()
        {
            DB db = DB.getDB(dbfile);
            var sql = "SELECT * FROM Professor";
            var statement = db.Query(sql);
            return CollectionToReturn(statement);
        }

        private static ObservableCollection<Professor> CollectionToReturn(ISQLiteStatement statement)
        {
            var result = new ObservableCollection<Professor>();
            Professor inst = null;
            while (statement.Step() == SQLiteResult.ROW)
            {
                inst = new Professor()
                {
                    id = (long)statement[0],
                    Name = (string)statement[1],
                    Email = (string)statement[2],
                    Office = (string)statement[3]
                };
                result.Add(inst);
            }
            return result;
        }
    }
}
