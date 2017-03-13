//---------------------------------------------------------------------------
//
// <copyright file="WindowsDeveloperBlogListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>3/12/2017 6:01:03 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Rss;
using WindowsDevNews.Sections;
using WindowsDevNews.ViewModels;
using AppStudio.Uwp;

namespace WindowsDevNews.Pages
{
    public sealed partial class WindowsDeveloperBlogListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public WindowsDeveloperBlogListPage()
        {
			ViewModel = ViewModelFactory.NewList(new WindowsDeveloperBlogSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("5e597719-d5e6-4390-aed4-3218963bdc78");
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
