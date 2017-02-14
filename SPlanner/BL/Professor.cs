using SPlanner.DAL;
using System.Collections.ObjectModel;
using System.Linq;

namespace SPlanner.BL
{
    public class Professor
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Office { get; set; }

        public static void CreateTable()
        {
            ProfessorDAL.CreateTable();
        }

        public bool Create()
        {
            return (ProfessorDAL.Create(this));
        }

        public bool Update()
        {
            return (ProfessorDAL.Update(this));
        }

        public bool Delete()
        {
            return (ProfessorDAL.Delete(this));
        }

        public static Professor SelectById(long id)
        {
            if (id > 0)
                return ProfessorDAL.SelectById(id);
            else
                return null;
        }

        public static Professor SelectByName(string name)
        {
            if (name != "" && name != null)
                return ProfessorDAL.SelectByName(name);
            else
                return null;
        }

        public static ObservableCollection<Professor> SelectAll()
        {
            return ProfessorDAL.SelectAll();
        }
    }
}
