using SPlanner.BL;
using System.Collections.ObjectModel;

namespace SPlanner_UWP.ViewModel
{
    public class ProfessorViewModel
    {
        public ObservableCollection<Professor> ProfessorCollection { get; set; }
        public Professor Professor { get; set; }

        public ProfessorViewModel()
        {
            ProfessorCollection = Professor.SelectAll();
        }
        public void AddProfessor()
        {
            if (Professor.SelectByName(Professor.Name) != null)
                throw new System.ArgumentException(string.Format("Professor '{0}' already exist", Professor.Name));
            Professor.Create();
            ProfessorCollection.Add(Professor);
        }
        public void EditProfessor()
        {
            Professor.Update();
            ProfessorCollection[ProfessorCollection.IndexOf(Professor)] = Professor;
        }
        public void DeleteProfessor()
        {
            Professor.Delete();
            ProfessorCollection.Remove(Professor);
        }

    }
}
