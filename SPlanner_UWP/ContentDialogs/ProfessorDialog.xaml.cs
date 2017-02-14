using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using System;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    public sealed partial class ProfessorDialog : ContentDialog
    {
        ProfessorViewModel ProfessorVM { get; set; }
        private bool closeDisabling;
        private bool editing;
        public ProfessorDialog(ProfessorViewModel professorVM, Professor prof = null)
        {
            ProfessorVM = professorVM;

            this.InitializeComponent();

            if (prof != null)
            {
                ProfessorVM.Professor = prof;
                Title = "EDIT";
                editing = true;
            }
            else
            {
                ProfessorVM.Professor = new Professor();
                Title = "ADD";
                editing = false;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (ProfessorVM.Professor.Name == null || ProfessorVM.Professor.Name == "")
            {
                ErrorTextBlock.Text = "Name can not be empty";
                closeDisabling = true;
                return;
            }

            //if everything is ok:
            if (editing)
            {
                ProfessorVM.EditProfessor();
            }
            else
            {
                try
                {
                    ProfessorVM.AddProfessor();
                }
                catch (ArgumentException ex)
                {
                    ErrorTextBlock.Text = ex.Message;
                    closeDisabling = true;
                }
            }

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        closeDisabling = false;
    }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (closeDisabling)
            {
                args.Cancel = true;
            }
        }
    }
}
