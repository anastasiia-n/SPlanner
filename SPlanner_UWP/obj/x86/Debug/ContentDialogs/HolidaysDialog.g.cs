﻿#pragma checksum "D:\IPB\Visual Studio 2015\Projects\SPlanner\SPlanner_UWP\ContentDialogs\HolidaysDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "210657697783E5051CFA793391FA81C5"
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
    partial class HolidaysDialog : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_DatePicker_Date(global::Windows.UI.Xaml.Controls.DatePicker obj, global::System.DateTimeOffset value)
            {
                obj.Date = value;
            }
        };

        private class HolidaysDialog_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IHolidaysDialog_Bindings
        {
            private global::SPlanner_UWP.HolidaysDialog dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.DatePicker obj2;
            private global::Windows.UI.Xaml.Controls.DatePicker obj3;

            private HolidaysDialog_obj1_BindingsTracking bindingsTracking;

            public HolidaysDialog_obj1_Bindings()
            {
                this.bindingsTracking = new HolidaysDialog_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::Windows.UI.Xaml.Controls.DatePicker)target;
                        (this.obj2).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.DatePicker.DateProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.HolidaysVM.Holidays.Start_date = (global::System.DateTime)this.LookupConverter("dateTimeOffsetConverter").ConvertBack((this.obj2).Date, typeof(global::System.DateTime), null, null);
                                }
                            });
                        break;
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.DatePicker)target;
                        (this.obj3).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.DatePicker.DateProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.HolidaysVM.Holidays.End_date = (global::System.DateTime)this.LookupConverter("dateTimeOffsetConverter").ConvertBack((this.obj3).Date, typeof(global::System.DateTime), null, null);
                                }
                            });
                        break;
                    default:
                        break;
                }
            }

            // IHolidaysDialog_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // HolidaysDialog_obj1_Bindings

            public void SetDataRoot(global::SPlanner_UWP.HolidaysDialog newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }
            public void SetConverterLookupRoot(global::Windows.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Windows.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Windows.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Windows.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Windows.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::SPlanner_UWP.HolidaysDialog obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_HolidaysVM(obj.HolidaysVM, phase);
                    }
                }
            }
            private void Update_HolidaysVM(global::SPlanner_UWP.ViewModel.HolidaysViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_HolidaysVM_Holidays(obj.Holidays, phase);
                    }
                }
            }
            private void Update_HolidaysVM_Holidays(global::SPlanner.BL.Holidays obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_HolidaysVM_Holidays_Start_date(obj.Start_date, phase);
                        this.Update_HolidaysVM_Holidays_End_date(obj.End_date, phase);
                    }
                }
            }
            private void Update_HolidaysVM_Holidays_Start_date(global::System.DateTime obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_DatePicker_Date(this.obj2, (global::System.DateTimeOffset)this.LookupConverter("dateTimeOffsetConverter").Convert(obj, typeof(global::System.DateTimeOffset), null, null));
                }
            }
            private void Update_HolidaysVM_Holidays_End_date(global::System.DateTime obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_DatePicker_Date(this.obj3, (global::System.DateTimeOffset)this.LookupConverter("dateTimeOffsetConverter").Convert(obj, typeof(global::System.DateTimeOffset), null, null));
                }
            }

            private class HolidaysDialog_obj1_BindingsTracking
            {
                global::System.WeakReference<HolidaysDialog_obj1_Bindings> WeakRefToBindingObj; 

                public HolidaysDialog_obj1_BindingsTracking(HolidaysDialog_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<HolidaysDialog_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                }

            }
        }
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
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    #line 13 "..\..\..\ContentDialogs\HolidaysDialog.xaml"
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    #line 14 "..\..\..\ContentDialogs\HolidaysDialog.xaml"
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                    #line 14 "..\..\..\ContentDialogs\HolidaysDialog.xaml"
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).Closing += this.ContentDialog_Closing;
                    #line default
                }
                break;
            case 2:
                {
                    this.Holidays_from_cdp = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    #line 20 "..\..\..\ContentDialogs\HolidaysDialog.xaml"
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.Holidays_from_cdp).DateChanged += this.Holidays_from_dp_DateChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.Holidays_to_cdp = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    #line 23 "..\..\..\ContentDialogs\HolidaysDialog.xaml"
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.Holidays_to_cdp).DateChanged += this.Holidays_to_dp_DateChanged;
                    #line default
                }
                break;
            case 4:
                {
                    this.ErrorTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)target;
                    HolidaysDialog_obj1_Bindings bindings = new HolidaysDialog_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    bindings.SetConverterLookupRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

