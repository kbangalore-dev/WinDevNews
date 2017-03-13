//---------------------------------------------------------------------------
//
// <copyright file="MSFTNewsListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>3/12/2017 6:01:03 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Twitter;
using WindowsDevNews.Sections;
using WindowsDevNews.ViewModels;
using AppStudio.Uwp;

namespace WindowsDevNews.Pages
{
    public sealed partial class MSFTNewsListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public MSFTNewsListPage()
        {
			ViewModel = ViewModelFactory.NewList(new MSFTNewsSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("fd8b4e61-ca8f-4d5f-acd2-48772f668306");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
