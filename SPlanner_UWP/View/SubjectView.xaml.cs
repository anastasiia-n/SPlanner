using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectView : Page
    {
        public SubjectViewModel SubjectVM { get; set; }
        public SubjectView()
        {
            this.InitializeComponent();
            SubjectVM = new SubjectViewModel();
        }

        private async void EditButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                SubjectVM.Subject = fe.DataContext as Subject;
                if (SubjectVM.Subject != null)
                {
                    SubjectDialog sd = new SubjectDialog(SubjectVM, SubjectVM.Subject);
                    await sd.ShowAsync();
                }
            }
        }

        private async void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                SubjectVM.Subject = fe.DataContext as Subject;
                if (SubjectVM.Subject != null)
                {
                    DeleteDialog dialog = new DeleteDialog(SubjectVM.Subject.Name);
                    var result = await dialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        SubjectVM.DeleteSubject();
                    }
                }
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectDialog sd = new SubjectDialog(SubjectVM);
            await sd.ShowAsync();
        }
    }
}
