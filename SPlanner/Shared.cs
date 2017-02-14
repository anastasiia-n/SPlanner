using DataAbstractionLayerSQLite;
using System;

namespace SPlanner.DAL
{
    public static class Shared
    {
        public readonly static string dbfile = "SPlannerDB.db";
        internal readonly static string SQLiteDateFormat = "yyyy-MM-dd";

        internal static string RemoveFromCreateQuery(string sql, string field)
        {
            return sql.Replace(", @" + field, "").Replace(",@" + field, "")
                        .Replace(", " + field, "").Replace("," + field, "");
        }
        internal static string RemoveFromUpdateQuery(string sql, string field)
        {
            return sql.Replace("= @" + field, "").Replace("=@" + field, "")
                        .Replace(", " + field, "").Replace("," + field, "");
        }
        public static void ClearTables(string table)
        {
            DB db = DB.getDB(dbfile);
            string sql = "DELETE FROM " + table;
            db.NonQuery(sql);
        }
        public static DateTime FirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime LastDayOfMonth(DateTime date)
        {
            return FirstDayOfMonth(date).AddMonths(1).AddDays(-1);
        }
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            return date.AddDays(-((int)(date.DayOfWeek + 6) % 7));
        }
    }
}
