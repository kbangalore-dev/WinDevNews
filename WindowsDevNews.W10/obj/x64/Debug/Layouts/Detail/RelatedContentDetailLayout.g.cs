﻿#pragma checksum "C:\Users\kiranban\Source\Repos\WinDevNews\WindowsDevNews.W10\Layouts\Detail\RelatedContentDetailLayout.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1262688D2F8661FE6D8E732DBB1AA5BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsDevNews.Layouts.Detail
{
    partial class RelatedContentDetailLayout : 
        global::WindowsDevNews.Layouts.Detail.BaseDetailLayout, 
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
                    this.root = (global::WindowsDevNews.Layouts.Detail.BaseDetailLayout)(target);
                }
                break;
            case 2:
                {
                    this.cd1 = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 3:
                {
                    this.contentGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4:
                {
                    this.portraitRelatedContent = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5:
                {
                    this.wideRelatedContent = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6:
                {
                    this.control = (global::AppStudio.Uwp.Controls.HtmlBlock)(target);
                }
                break;
            case 7:
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

