﻿#pragma checksum "D:\IPB\Visual Studio 2015\Projects\SPlanner\SPlanner_UWP\View\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D76C4142881547C1E4535AAE078D6B48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPlanner_UWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.IconStyle = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 2:
                {
                    this.DescriptionStyle = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 3:
                {
                    this.MenuOpenButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 35 "..\..\..\View\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.MenuOpenButton).Click += this.MenuOpenButton_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.Menu = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 5:
                {
                    this.CalendarButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 111 "..\..\..\View\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.CalendarButton).Click += this.CalendarButton_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.MainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 7:
                {
                    this.MenuIconListBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 39 "..\..\..\View\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.MenuIconListBox).SelectionChanged += this.MenuIconListBox_SelectionChanged;
                    #line default
                }
                break;
            case 8:
                {
                    this.CalendarListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 9:
                {
                    this.TasksListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 10:
                {
                    this.SubjectsListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 11:
                {
                    this.ClassesListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 12:
                {
                    this.HolidaysListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 13:
                {
                    this.ProfessorsListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 14:
                {
                    this.SummaryListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 15:
                {
                    this.SettingsListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 16:
                {
                    this.HelpListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 17:
                {
                    this.CalendarIconTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18:
                {
                    this.ResultTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
