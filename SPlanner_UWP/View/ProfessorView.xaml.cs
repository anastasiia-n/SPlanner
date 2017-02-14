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
    public sealed partial class ProfessorView : Page
    {
        public ProfessorViewModel ProfessorVM { get; set; }
        public ProfessorView()
        {
            this.InitializeComponent();
            ProfessorVM = new ProfessorViewModel();
        }

        private async void AddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ProfessorDialog sd = new ProfessorDialog(ProfessorVM);
            await sd.ShowAsync();
        }

        private async void EditButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                ProfessorVM.Professor = fe.DataContext as Professor;
                if (ProfessorVM.Professor != null)
                {
                    ProfessorDialog sd = new ProfessorDialog(ProfessorVM, ProfessorVM.Professor);
                    await sd.ShowAsync();
                }
            }
        }

        private async void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                ProfessorVM.Professor = fe.DataContext as Professor;
                if (ProfessorVM.Professor != null)
                {
                    DeleteDialog dialog = new DeleteDialog(ProfessorVM.Professor.Name);
                    var result = await dialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        ProfessorVM.DeleteProfessor();
                    }
                }
            }
        }
    }
}
