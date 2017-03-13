using System;
using System.Collections.Generic;
using AppStudio.Uwp;
using AppStudio.Uwp.Commands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsDevNews.Sections;
namespace WindowsDevNews.ViewModels
{
    public class SearchViewModel : PageViewModelBase
    {
        public SearchViewModel() : base()
        {
			Title = "Windows Dev News";
            WindowsDeveloperBlog = ViewModelFactory.NewList(new WindowsDeveloperBlogSection());
            DeveloperVideos = ViewModelFactory.NewList(new DeveloperVideosSection());
            UWPDevForBeginners = ViewModelFactory.NewList(new UWPDevForBeginnersSection());
            Twitter = ViewModelFactory.NewList(new TwitterSection());
            AppDevSamplesForWin10 = ViewModelFactory.NewList(new AppDevSamplesForWin10Section());
            MSFTNews = ViewModelFactory.NewList(new MSFTNewsSection());
                        
        }

        private string _searchText;
        private bool _hasItems = true;

        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        public bool HasItems
        {
            get { return _hasItems; }
            set { SetProperty(ref _hasItems, value); }
        }

		public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand<string>(
                async (text) =>
                {
                    await SearchDataAsync(text);
                }, SearchViewModel.CanSearch);
            }
        }      
        public ListViewModel WindowsDeveloperBlog { get; private set; }
        public ListViewModel DeveloperVideos { get; private set; }
        public ListViewModel UWPDevForBeginners { get; private set; }
        public ListViewModel Twitter { get; private set; }
        public ListViewModel AppDevSamplesForWin10 { get; private set; }
        public ListViewModel MSFTNews { get; private set; }
        public async Task SearchDataAsync(string text)
        {
            this.HasItems = true;
            SearchText = text;
            var loadDataTasks = GetViewModels()
                                    .Select(vm => vm.SearchDataAsync(text));

            await Task.WhenAll(loadDataTasks);
			this.HasItems = GetViewModels().Any(vm => vm.HasItems);
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
		private void CleanItems()
        {
            foreach (var vm in GetViewModels())
            {
                vm.CleanItems();
            }
        }
		public static bool CanSearch(string text) { return !string.IsNullOrWhiteSpace(text) && text.Length >= 3; }
    }
}
