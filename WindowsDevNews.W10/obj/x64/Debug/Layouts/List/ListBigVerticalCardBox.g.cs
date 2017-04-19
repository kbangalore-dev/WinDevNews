﻿#pragma checksum "C:\Users\kiranban\Source\Repos\WinDevNews\WindowsDevNews.W10\Layouts\List\ListBigVerticalCardBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DE40A58BE558CD49F3A3DA91826A1DED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsDevNews.Layouts.List
{
    partial class ListBigVerticalCardBox : 
        global::WindowsDevNews.Layouts.List.ListLayoutBase, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_FrameworkElement_MaxHeight(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Double value)
            {
                obj.MaxHeight = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        private class ListBigVerticalCardBox_obj3_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IListBigVerticalCardBox_Bindings
        {
            private global::WindowsDevNews.ViewModels.ItemViewModel dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Grid obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;
            private global::Windows.UI.Xaml.Controls.TextBlock obj6;

            private ListBigVerticalCardBox_obj3_BindingsTracking bindingsTracking;

            public ListBigVerticalCardBox_obj3_Bindings()
            {
                this.bindingsTracking = new ListBigVerticalCardBox_obj3_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::WindowsDevNews.ViewModels.ItemViewModel data = args.NewValue as global::WindowsDevNews.ViewModels.ItemViewModel;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::WindowsDevNews.ViewModels.ItemViewModel was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = 1;
                        this.SetDataRoot(args.Item as global::WindowsDevNews.ViewModels.ItemViewModel);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Grid)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                    case 1:
                        Windows.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj5);
                        Windows.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj6);
                        nextPhase = -1;
                        break;
                }
                this.Update_((global::WindowsDevNews.ViewModels.ItemViewModel) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                this.bindingsTracking.ReleaseAllListeners();
                Windows.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj5);
                Windows.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj6);
            }

            // IListBigVerticalCardBox_Bindings

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

            // ListBigVerticalCardBox_obj3_Bindings

            public void SetDataRoot(global::WindowsDevNews.ViewModels.ItemViewModel newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
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
            private void Update_(global::WindowsDevNews.ViewModels.ItemViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ImageUrl(obj.ImageUrl, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0) | (1 << 1))) != 0)
                    {
                        this.Update_Title(obj.Title, phase);
                        this.Update_SubTitle(obj.SubTitle, phase);
                    }
                }
            }
            private void Update_ImageUrl(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_MaxHeight(this.obj4, (global::System.Double)this.LookupConverter("StringToSizeConverter").Convert(obj, typeof(global::System.Double), null, null));
                }
            }
            private void Update_Title(global::System.String obj, int phase)
            {
                if((phase & ((1 << 1) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                }
            }
            private void Update_SubTitle(global::System.String obj, int phase)
            {
                if((phase & ((1 << 1) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj, null);
                }
            }

            private class ListBigVerticalCardBox_obj3_BindingsTracking
            {
                global::System.WeakReference<ListBigVerticalCardBox_obj3_Bindings> WeakRefToBindingObj; 

                public ListBigVerticalCardBox_obj3_BindingsTracking(ListBigVerticalCardBox_obj3_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ListBigVerticalCardBox_obj3_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ListBigVerticalCardBox_obj3_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::WindowsDevNews.ViewModels.ItemViewModel obj = sender as global::WindowsDevNews.ViewModels.ItemViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ImageUrl(obj.ImageUrl, DATA_CHANGED);
                                    bindings.Update_Title(obj.Title, DATA_CHANGED);
                                    bindings.Update_SubTitle(obj.SubTitle, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "ImageUrl":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ImageUrl(obj.ImageUrl, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Title":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_Title(obj.Title, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SubTitle":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_SubTitle(obj.SubTitle, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::WindowsDevNews.ViewModels.ItemViewModel obj)
                {
                    ListBigVerticalCardBox_obj3_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
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
                    this.root = (global::WindowsDevNews.Layouts.List.ListLayoutBase)(target);
                }
                break;
            case 2:
                {
                    this.vbp = (global::AppStudio.Uwp.Controls.VisualBreakpoints)(target);
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
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Grid element3 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    ListBigVerticalCardBox_obj3_Bindings bindings = new ListBigVerticalCardBox_obj3_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::WindowsDevNews.ViewModels.ItemViewModel) element3.DataContext);
                    bindings.SetConverterLookupRoot(this);
                    element3.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element3, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

