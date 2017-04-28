using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;
using System.Windows.Input;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Cache;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.DataSync;
using AppStudio.DataProviders;
using AppStudio.Uwp.Navigation;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

using WindowsDevNews.Navigation;
using WindowsDevNews.Sections;
using WindowsDevNews.Services;
using AppStudio.DataProviders.YouTube;
using Microsoft.Advertising.WinRT.UI;
using Microsoft.Advertising.Shared.WinRT;

namespace WindowsDevNews.ViewModels
{
    public abstract class ListViewModel : ListViewModelBase
    {
        public abstract Task SearchDataAsync(string searchTerm);
        public abstract Task FilterDataAsync(List<string> itemsId);

		protected abstract Type ListPage { get; }

        public ListViewModel(string title, string sectionName)
        {
            Title = title;
            SectionName = sectionName;
        }

        private ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
        public ObservableCollection<ItemViewModel> Items
        {
            get { return _items; }
            protected set { SetProperty(ref _items, value); }
        }

        private bool _hasMoreItems;
        public bool HasMoreItems
        {
            get { return _hasMoreItems; }
            protected set { SetProperty(ref _hasMoreItems, value); }
        }

        private bool _hasMorePages;

        public bool HasMorePages
        {
            get { return _hasMorePages; }
            set { SetProperty(ref _hasMorePages, value); }
        }

        public RelayCommand LoadNextPageCommand
        {
            get
            {
                return new RelayCommand(
                async () =>
                {
                    if (!IsLoadingNextPage)
                    {
                        await LoadNextPageAsync();
                    }
                });
            }
        }

        public RelayCommand SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    NavigationService.NavigateToPage(ListPage);
                });
            }
        }

        public void ShareContent(DataRequest dataRequest, bool supportsHtml = true)
        {
            if (Items != null && Items.Count > 0)
            {
                ShareContent(dataRequest, Items[0], supportsHtml);
            }
        }

        internal void CleanItems()
        {
            this.Items.Clear();
            this.HasItems = false;
        }
    }

    public class ListViewModel<TSchema> : ListViewModel where TSchema : SchemaBase
    {
        private Section<TSchema> _section;
        private int _visibleItems;
        private SchemaBase _connected;
        private NativeAd ad;

        protected override Type ListPage
        {
            get
            {
                return _section.ListPage.Page;
            }
        }

        public ListViewModel(Section<TSchema> section, int visibleItems = 0) : base(section.ListPage.Title, section.Name)
        {
            _section = section;
            _visibleItems = visibleItems;

            HasLocalData = !section.NeedsNetwork;
			HasMorePages = true;

            if (_section.NeedsNetwork)
            {
				Actions.Add(new ActionInfo
				{
					Command = Refresh,
					Style = ActionKnownStyles.Refresh,
					Name = "RefreshButton",
					ActionType = ActionType.Primary
				});
            }

            if (_section.Name == "DeveloperVideosSection")
            {
                NativeAdsManager nativeAdController = new NativeAdsManager();
                nativeAdController.RequestAd("b132be36-66c2-4053-813b-abc73e9e2841", "0000000000");
                nativeAdController.AdReady += OnAdReady;
            }
        }

        void OnAdReady(object sender, object e)
        {
            ad = (NativeAd)e;
            if (ad == null)
            {
                return;
            }
        }

        public override async Task LoadDataAsync(bool forceRefresh = false, SchemaBase connected = null)
        {
            try
            {
				_connected = connected;
                HasLoadDataErrors = false;
                IsBusy = true;

                var loaderSettings = LoaderSettings.FromSection(_section, GetCacheKey(connected), forceRefresh);
                var loaderOutcome = await DataLoader.LoadAsync(loaderSettings, () => _section.GetDataAsync(connected), (items) => ParseItems(items));

                LastUpdated = loaderOutcome.Timestamp;
                _isDataProviderInitialized = loaderOutcome.IsFreshData;
                _isFirstPage = true;
            }
            catch (Exception ex)
            {
                HasLoadDataErrors = true;
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override async Task LoadNextPageAsync()
        {
            try
            {
                HasLoadDataErrors = false;
                IsLoadingNextPage = true;

                if (!_isDataProviderInitialized && _isFirstPage)
                {
                    await LoadDataAsync(true, _connected);
                    _isFirstPage = false;
                }

                await DataLoader.LoadAsync(LoaderSettings.NoCache(_section.NeedsNetwork), () => _section.GetNextPageAsync(), (items) => ParseNextPage(items));

                HasMorePages = _section.HasMorePages;
            }
            catch (Exception ex)
            {
                HasLoadDataErrors = true;
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                IsLoadingNextPage = false;
            }
        }

        public override async Task SearchDataAsync(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                try
                {
                    HasLoadDataErrors = false;
                    IsBusy = true;

                    var loaderSettings = LoaderSettings.FromSection(_section, _section.Name, true);
                    var loaderOutcome = await DataLoader.LoadAsync(loaderSettings, () => _section.GetDataAsync(), (items) => ParseItems(items, i => i.ContainsString(searchTerm)));
                    LastUpdated = loaderOutcome.Timestamp;
                }
                catch (Exception ex)
                {
                    HasLoadDataErrors = true;
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        public override async Task FilterDataAsync(List<string> itemsId)
        {
            if (itemsId != null && itemsId.Any())
            {
                try
                {
                    HasLoadDataErrors = false;
                    IsBusy = true;

                    var loaderSettings = LoaderSettings.FromSection(_section, _section.Name, true);
                    var loaderOutcome = await DataLoader.LoadAsync(loaderSettings, () => _section.GetDataAsync(), (items) => ParseItems(items, i => itemsId.Contains(i.Id)));
                    LastUpdated = loaderOutcome.Timestamp;
                }
                catch (Exception ex)
                {
                    HasLoadDataErrors = true;
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        //Native Ad Demo

        private void ParseItems(IEnumerable<TSchema> content, Func<ItemViewModel, bool> filterFunc = null)
        {
		    SourceItems.Clear();
            SourceItems.AddRange(content);

            if (_section.Name == "DeveloperVideosSection")
            {
                var contentList = content.ToList<TSchema>() as List<YouTubeSchema>;
                if (contentList != null) {
                    contentList.Insert(3, new YouTubeSchema()
                    {
                        Title = ad.Title,
                        ImageUrl = ad.MainImages[0].Url,
                        Summary = ad.Description,
                        VideoUrl = @"http://sin1-ib.adnxs.com/click?mpmZmZmZ2T-amZmZmZnZPwAAAAAAAAAAmpmZmZmZ2T-amZmZmZnZP9ozUy1UorQNTGvnSPL39kovo_RYAAAAAMwdmgAYAQAAGAEAAAIAAABSt_kDdBsGAAAAAABVU0QAVVNEAAEAAQAUiAAAAAABAgQCAQAAAI8AjiTAUwAAAAA./pp=${AUCTION_PRICE}//cnd=%21-Ank0AjKj_IHENLu5h8Y9LYYIAQoipykmg0xAAAAAAAAAAA./bn=71133/test=1/clickenc=https%3A%2F%2Fwww.microsoft.com%2Fen-us%2Fstore%2Fp%2Fbarbie-life-in-a-dreamhouse-hd%2F9nblggh5lnwp\",
                        VideoId = "__Ad__"
                    });

                    content = contentList as IEnumerable<TSchema>;
                }
            }

            var parsedItems = new List<ItemViewModel>();
            foreach (var item in GetVisibleItems(content, _visibleItems))
            {
                var parsedItem = new ItemViewModel
                {
                    Id = item._id,
                    NavInfo = _section.ListPage.DetailNavigation(item)
                };

                _section.ListPage.LayoutBindings(parsedItem, item);

                if (filterFunc == null || filterFunc(parsedItem))
                {
                    parsedItems.Add(parsedItem);
                }
            }
            Items.Sync(parsedItems);

            HasItems = Items.Count > 0;
            HasMoreItems = content.Count() > Items.Count;
        }

        private void ParseNextPage(IEnumerable<TSchema> content)
        {
			SourceItems.AddRange(content);

            foreach (var item in content)
            {
                var parsedItem = new ItemViewModel
                {
                    Id = item._id,
                    NavInfo = _section.ListPage.DetailNavigation(item)
                };
                _section.ListPage.LayoutBindings(parsedItem, item);

                Items.Add(parsedItem);
            }
        }

        private IEnumerable<TSchema> GetVisibleItems(IEnumerable<TSchema> content, int visibleItems)
        {
            if (visibleItems == 0)
            {
                return content;
            }
            else
            {
                return content.Take(visibleItems);
            }
        }

		private string GetCacheKey(SchemaBase connectedItem)
        {
            if (connectedItem == null)
            {
                return _section.Name;
            }
            else
            {
                return $"{_section.Name}_{connectedItem._id}";
            }
        }
    }
}
