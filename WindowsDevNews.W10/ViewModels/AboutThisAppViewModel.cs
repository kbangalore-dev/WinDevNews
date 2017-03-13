using System;
using System.Windows.Input;

using Windows.ApplicationModel;
using Windows.UI.Xaml.Media.Imaging;

using AppStudio.Uwp;
using AppStudio.Uwp.Commands;

namespace WindowsDevNews.ViewModels
{
    public class AboutThisAppViewModel : PageViewModelBase
    {
		public AboutThisAppViewModel()
        {
            this.AppName = "Windows Dev News";
            this.Title = "NavigationPaneAbout".StringResource();
            this.Publisher = "Ronav Apps";
            this.AppVersion = string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            this.AboutText = "This app gives you the latest news for Windows App Developers, it also gives you " +
    "videos that will help you learn quickly how to create a UWP App and some sample " +
    "videos that will help you create your dream app - using weather, location etc.";
            this.AppLogo = new BitmapImage(new Uri("ms-appx:///Assets/ApplicationLogo.png"));
            this.Privacy = "http://1drv.ms/1jzSlV5";
            this.WasLibs = "https://github.com/wasteam/waslibs";
            this.WindowsAppStudioWeb = "https://appstudio.windows.com/";
            this.NewtonsoftWeb = "http://www.newtonsoft.com/json";
        }

		public string AppName { get; set; }
        public string Publisher { get; set; }
        public string AppVersion { get; set; }
        public string AboutText { get; set; }
        public string Privacy { get; set; }
        public string WasLibs { get; set; }
        public string WindowsAppStudioWeb { get; set; }
        public string NewtonsoftWeb { get; set; }
        public BitmapImage AppLogo { get; set; }

		private bool _isMoreInfoVisible;
        public bool IsMoreInfoVisible
        {
            get { return _isMoreInfoVisible; }
            set { SetProperty(ref _isMoreInfoVisible, value); }
        }

        private ICommand _viewMoreInfoCommand;
        public ICommand ViewMoreInfoCommand
        {
            get
            {
                if (_viewMoreInfoCommand == null)
                {
                    _viewMoreInfoCommand = new RelayCommand(() => { IsMoreInfoVisible = !IsMoreInfoVisible; });
                }
                return _viewMoreInfoCommand;
            }
        }
    }
}

