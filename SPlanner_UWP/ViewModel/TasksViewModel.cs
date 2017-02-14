using SPlanner.BL;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SPlanner_UWP.ViewModel
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Task> tasksCollection;
        public ObservableCollection<Task> TasksCollection
        {
            get { return tasksCollection; }
            set
            {
                if(value!=tasksCollection)
                {
                    tasksCollection = value;
                    foreach (var item in tasksCollection)
                    {
                        item.subject = Subject.SelectById(item.Subject_id);
                    }
                }
            }
        }
        private Task task { get; set; }
        public Task Task
        {
            get { return task; }
            set
            {
                if (value != task && value != null) 
                {
                    task = value;
                    if(task.subject == null)
                        task.subject = Subject.SelectById(task.Subject_id);
                    NotifyPropertyChanged();
                }
            }
        }
        public TasksViewModel()
        {
            TasksCollection = Task.SelectAll();
            Task = new Task();
            Task.Date = DateTime.Today;
        }
        public TasksViewModel(DateTime date)
        {
            TasksCollection = Task.SelectByDate(date);
        }
        internal void AddTask()
        {
            Task.subject = Subject.SelectById(Task.Subject_id);
            Task.Create();
            TasksCollection.Add(Task);
        }
        internal void EditTask()
        {
            Task.subject = Subject.SelectById(Task.Subject_id);
            Task.Update();
            int indexOfTask = TasksCollection.IndexOf(Task);
            if(indexOfTask>=0)
                TasksCollection[indexOfTask] = Task;
        }
        internal void DeleteTask()
        {
            Task.Delete();
            TasksCollection.Remove(Task);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
