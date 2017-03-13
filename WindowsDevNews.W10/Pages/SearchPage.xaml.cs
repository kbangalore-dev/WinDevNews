//---------------------------------------------------------------------------
//
// <copyright file="SearchPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>3/12/2017 6:01:03 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsDevNews.ViewModels;

namespace WindowsDevNews.Pages
{
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            ViewModel = new SearchViewModel();
            this.InitializeComponent();
        }
        public SearchViewModel ViewModel { get; private set; }
		protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.SearchDataAsync(e.Parameter.ToString());
        }
    }    
}
