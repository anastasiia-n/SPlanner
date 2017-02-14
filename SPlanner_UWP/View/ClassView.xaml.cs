using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClassView : Page
    {
        public ClassViewModel ClassVM { get; set; }
        public ClassView()
        {
            this.InitializeComponent();
            ClassVM = new ClassViewModel();
        }

        private async void AddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ClassDialog cd = new ClassDialog(ClassVM);
            await cd.ShowAsync();
        }

        private async void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                ClassVM.Class = fe.DataContext as Class;
                if (ClassVM.Class != null)
                {
                    string message = string.Format("Class {0} ({1})", ClassVM.Class.Name, ClassVM.Class.subject.Name);
                    DeleteDialog dialog = new DeleteDialog(message);
                    var result = await dialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        ClassVM.DeleteClass();
                    }
                }
            }
        }

        private async void EditButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                ClassVM.Class = fe.DataContext as Class;
                if (ClassVM.Class != null)
                {
                    ClassDialog sd = new ClassDialog(ClassVM, ClassVM.Class);
                    await sd.ShowAsync();
                }
            }
        }
    }
}
