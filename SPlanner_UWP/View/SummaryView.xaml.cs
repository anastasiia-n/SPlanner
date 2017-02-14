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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SPlanner_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SummaryView : Page
    {
        public SummaryViewModel SummaryVM { get; set; }
        public SummaryView()
        {
            this.InitializeComponent();
            SummaryVM = new SummaryViewModel();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            SummaryVM.GoToNextMonth();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            SummaryVM.GoToPrevMonth();
        }
    }
}
