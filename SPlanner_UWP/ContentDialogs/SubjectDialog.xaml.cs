using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using System;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    public sealed partial class SubjectDialog : ContentDialog
    {
        SubjectViewModel SubjectVM { get; set; }
        private bool closeDisabling;
        private bool editing;
        public SubjectDialog(SubjectViewModel subjectVM, Subject sub=null)
        {
            SubjectVM = subjectVM;
            this.InitializeComponent();
            if (sub != null)
            {
                SubjectVM.Subject = sub;
                Title = "EDIT";
                editing = true;
            }
            else
            {
                SubjectVM.Subject = new Subject();
                Title = "ADD";
                editing = false;
            }
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (SubjectVM.Subject.Name != null && SubjectVM.Subject.Name != "")
            {
                if (editing)
                {
                    SubjectVM.EditSubject();
                }
                else
                {
                    try
                    {
                        SubjectVM.AddSubject();
                    }
                    catch (Exception ex)
                    {
                        ErrorTextBlock.Text = ex.Message;
                        closeDisabling = true;
                    }
                }
            }
            else
            {
                ErrorTextBlock.Text = "Name can not be empty";
                closeDisabling = true;
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
