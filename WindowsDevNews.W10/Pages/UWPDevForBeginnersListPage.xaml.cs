//---------------------------------------------------------------------------
//
// <copyright file="UWPDevForBeginnersListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>3/12/2017 6:01:03 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.YouTube;
using WindowsDevNews.Sections;
using WindowsDevNews.ViewModels;
using AppStudio.Uwp;

namespace WindowsDevNews.Pages
{
    public sealed partial class UWPDevForBeginnersListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public UWPDevForBeginnersListPage()
        {
			ViewModel = ViewModelFactory.NewList(new UWPDevForBeginnersSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("0a64b5ad-fb8f-444c-b539-35e481497ee7");
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
