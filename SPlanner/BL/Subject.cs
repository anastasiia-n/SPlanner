using SPlanner.DAL;
using System.Collections.ObjectModel;

namespace SPlanner.BL
{
    public class Subject
    {
        public long id { get; set; }
        public string Name { get; set; }

        public static void CreateTable()
        {
            SubjectDAL.CreateTable();
        }

        public bool Create()
        {
            return (SubjectDAL.Create(this));
        }

        public bool Update()
        {
            return (SubjectDAL.Update(this));
        }

        public bool Delete()
        {
            return (SubjectDAL.Delete(this));
        }

        public static Subject SelectById(long id)
        {
            if (id > 0)
                return SubjectDAL.SelectById(id);
            else
                return null;
        }

        public static Subject SelectByName(string name)
        {
            if (name != "" && name != null)
                return SubjectDAL.SelectByName(name);
            else
                return null;
        }

        public static ObservableCollection<Subject> SelectAll()
        {
            return SubjectDAL.SelectAll();
        }
    }
}
