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
    public sealed partial class HelpView : Page
    {
        public int phase;
        public HelpView()
        {
            this.InitializeComponent();
            phase = SettingsManager.GetHelpPhase();
            GoToPhase(phase);
        }
        private void GoToPhase(int number)
        {
            SettingsManager.SaveHelpPhase(phase);

            #region CollapseAllControls
            FirstStepPanel.Visibility = Visibility.Collapsed;
            SubjectPanel.Visibility = Visibility.Collapsed;
            ProfessorPanel.Visibility = Visibility.Collapsed;
            ClassPanel.Visibility = Visibility.Collapsed;
            LastStepPanel.Visibility = Visibility.Collapsed;
            #endregion

            switch (number)
            {
                case 0:
                    FirstStepPanel.Visibility = Visibility.Visible;
                    break;
                case 1:
                    SubjectPanel.Visibility = Visibility.Visible;
                    break;
                case 2:
                    ProfessorPanel.Visibility = Visibility.Visible;
                    break;
                case 3:
                    ClassPanel.Visibility = Visibility.Visible;
                    break;
                case 4:
                    LastStepPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void FirstClickButton_Click(object sender, RoutedEventArgs e)
        {
            phase = 1;
            GoToPhase(phase);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            phase = 0;
            GoToPhase(phase);
        }

        private void SubjectsDoneCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            phase = 2;
            GoToPhase(phase);
        }

        private void ProfessorsDoneCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            phase = 3;
            GoToPhase(phase);
        }

        private void ClasssDoneCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            phase = 4;
            GoToPhase(phase);
        }
    }
}
