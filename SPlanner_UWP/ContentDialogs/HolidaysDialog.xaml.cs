using SPlanner.BL;
using SPlanner_UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    public sealed partial class HolidaysDialog : ContentDialog
    {
        HolidaysViewModel HolidaysVM { get; set; }
        private bool closeDisabling;
        private bool editing;
        public HolidaysDialog(HolidaysViewModel holildaysVM, Holidays hol = null)
        {
            HolidaysVM = holildaysVM;
            this.InitializeComponent();
            if (hol != null)
            {
                HolidaysVM.Holidays = hol;
                Title = "EDIT";
                editing = true;
            }
            else
            {
                HolidaysVM.Holidays = new Holidays()
                {
                    Start_date = DateTime.Today,
                    End_date = DateTime.Today
                };
                Title = "ADD";
                editing = false;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (HolidaysVM.Holidays.End_date >= HolidaysVM.Holidays.Start_date) 
            {
                closeDisabling = false;
                if (editing)
                {
                    HolidaysVM.EditHolidays();
                }
                else
                {
                    try
                    {
                        HolidaysVM.AddHolidays();
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
                ErrorTextBlock.Text = "End date must be later than start date";
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

        private void Holidays_from_dp_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            Holidays_to_cdp.MinYear = Holidays_from_cdp.Date;
        }

        private void Holidays_to_dp_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            Holidays_from_cdp.MaxYear = Holidays_to_cdp.Date;
        }
    }
}
