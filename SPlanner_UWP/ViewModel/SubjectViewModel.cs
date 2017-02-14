using SPlanner.BL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SPlanner_UWP.ViewModel
{
    public class SubjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Subject> SubjectCollection { get; set; }
        private Subject subject;
        public Subject Subject
        {
            get { return subject; }
            set
            {
                if (value != subject) 
                {
                    subject = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public SubjectViewModel()
        {
            SubjectCollection = Subject.SelectAll();
            Subject = new Subject();
        }
        public SubjectViewModel(Subject subject)
        {
            Subject = subject;
        }
        public void AddSubject()
        {
            if (Subject.SelectByName(Subject.Name) != null) 
                throw new System.Exception(string.Format("Subject '{0}' already exist", Subject.Name));
            Subject.Create();
            SubjectCollection.Add(Subject);
        }
        public void EditSubject()
        {
            Subject.Update();
            SubjectCollection[SubjectCollection.IndexOf(Subject)] = Subject;
        }
        public void DeleteSubject()
        {
            Subject.Delete();
            SubjectCollection.Remove(Subject);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
