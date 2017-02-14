using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPlanner.BL
{
    public class Database
    {
        public static void CreateTables()
        {
            Professor.CreateTable();
            Subject.CreateTable();
            Class.CreateTable();
            Schedule.CreateTable();
            Task.CreateTable();
            Holidays.CreateTable();
        }
    }
}
