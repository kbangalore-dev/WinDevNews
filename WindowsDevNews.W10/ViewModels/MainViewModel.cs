using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Navigation;
using AppStudio.Uwp.Commands;
using AppStudio.DataProviders;

using AppStudio.DataProviders.Rss;
using AppStudio.DataProviders.YouTube;
using AppStudio.DataProviders.Twitter;
using AppStudio.DataProviders.LocalStorage;
using WindowsDevNews.Sections;


namespace WindowsDevNews.ViewModels
{
    public class MainViewModel : PageViewModelBase
    {
        public ListViewModel WindowsDeveloperBlog { get; private set; }
        public ListViewModel DeveloperVideos { get; private set; }
        public ListViewModel UWPDevForBeginners { get; private set; }
        public ListViewModel Twitter { get; private set; }
        public ListViewModel AppDevSamplesForWin10 { get; private set; }
        public ListViewModel MSFTNews { get; private set; }
		public AdvertisingViewModel SectionAd { get; set; }

        public MainViewModel(int visibleItems) : base()
        {
            Title = "Windows Dev News";
			this.SectionAd = new AdvertisingViewModel();
            WindowsDeveloperBlog = ViewModelFactory.NewList(new WindowsDeveloperBlogSection(), visibleItems);
            DeveloperVideos = ViewModelFactory.NewList(new DeveloperVideosSection(), visibleItems);
            UWPDevForBeginners = ViewModelFactory.NewList(new UWPDevForBeginnersSection(), visibleItems);
            Twitter = ViewModelFactory.NewList(new TwitterSection(), visibleItems);
            AppDevSamplesForWin10 = ViewModelFactory.NewList(new AppDevSamplesForWin10Section(), visibleItems);
            MSFTNews = ViewModelFactory.NewList(new MSFTNewsSection(), visibleItems);

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = RefreshCommand,
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }

        }

		#region Commands
		public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var refreshDataTasks = GetViewModels()
                        .Where(vm => !vm.HasLocalData).Select(vm => vm.LoadDataAsync(true));

                    await Task.WhenAll(refreshDataTasks);
					LastUpdated = GetViewModels().OrderBy(vm => vm.LastUpdated, OrderType.Descending).FirstOrDefault()?.LastUpdated;
                    OnPropertyChanged("LastUpdated");
                });
            }
        }
		#endregion

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);
			LastUpdated = GetViewModels().OrderBy(vm => vm.LastUpdated, OrderType.Descending).FirstOrDefault()?.LastUpdated;
            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<ListViewModel> GetViewModels()
        {
            yield return WindowsDeveloperBlog;
            yield return DeveloperVideos;
            yield return UWPDevForBeginners;
            yield return Twitter;
            yield return AppDevSamplesForWin10;
            yield return MSFTNews;
        }
    }
}
