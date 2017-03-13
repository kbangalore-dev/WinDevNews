//---------------------------------------------------------------------------
//
// <copyright file="TwitterListPage.xaml.cs" company="Microsoft">
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
    public sealed partial class TwitterListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public TwitterListPage()
        {
			ViewModel = ViewModelFactory.NewList(new TwitterSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("b61bb08e-626e-404b-b8c3-4cfff81f54eb");
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
