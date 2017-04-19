using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.YouTube;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp;
using System.Linq;

using WindowsDevNews.Navigation;
using WindowsDevNews.ViewModels;

namespace WindowsDevNews.Sections
{
    public class DeveloperVideosSection : Section<YouTubeSchema>
    {
		private YouTubeDataProvider _dataProvider;
		
		public DeveloperVideosSection()
		{
			_dataProvider = new YouTubeDataProvider(new YouTubeOAuthTokens
			{
				ApiKey = "AIzaSyA8vY0RViK17Z_-QwjFu7wDUPk4vr8xrBw"
			});
		}

		public override async Task<IEnumerable<YouTubeSchema>> GetDataAsync(SchemaBase connectedItem = null)
        {
            var config = new YouTubeDataConfig
            {
                QueryType = YouTubeQueryType.Playlist,
                Query = @"PLIPLqGm8fkLoug_m9lMj_ReQZH_KpTaj-",
            };
            var listofvideos = (await _dataProvider.LoadDataAsync(config, MaxRecords)).ToList();
            listofvideos.Add(new YouTubeSchema()
            {
                Title = "Barbie-life in a dreamhouse",
                ImageUrl = "http://vcdn.adnxs.com/p/creative-image/1a/11/67/b3/1a1167b3-4eb0-4677-a0a7-4768be473303.jpg",
                Summary = "Awesome Story Telling App",
                VideoUrl = @"http://sin1-ib.adnxs.com/click?mpmZmZmZ2T-amZmZmZnZPwAAAAAAAAAAmpmZmZmZ2T-amZmZmZnZP9ozUy1UorQNTGvnSPL39kovo_RYAAAAAMwdmgAYAQAAGAEAAAIAAABSt_kDdBsGAAAAAABVU0QAVVNEAAEAAQAUiAAAAAABAgQCAQAAAI8AjiTAUwAAAAA./pp=${AUCTION_PRICE}//cnd=%21-Ank0AjKj_IHENLu5h8Y9LYYIAQoipykmg0xAAAAAAAAAAA./bn=71133/test=1/clickenc=https%3A%2F%2Fwww.microsoft.com%2Fen-us%2Fstore%2Fp%2Fbarbie-life-in-a-dreamhouse-hd%2F9nblggh5lnwp\"

            });

            return listofvideos;
            
        }

        public override async Task<IEnumerable<YouTubeSchema>> GetNextPageAsync()
        {
            return await _dataProvider.LoadMoreDataAsync();
        }

        public override bool HasMorePages
        {
            get
            {
                return _dataProvider.HasMoreItems;
            }
        }

        public override ListPageConfig<YouTubeSchema> ListPage
        {
            get 
            {
                var videos = new ListPageConfig<YouTubeSchema>
                {
                    Title = "Developer Videos",

                    Page = typeof(Pages.DeveloperVideosListPage),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Summary.ToSafeString();
                        viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(item.ImageUrl.ToSafeString());
                        if(item.VideoId == "__Ad__")
                        {
                            viewModel.SponsoredText = "Ad";
                        }
                    },
                    DetailNavigation = (item) =>
                    {
						return NavInfo.FromPage<Pages.DeveloperVideosDetailPage>(true);
                    }
                };

                return videos;
            }
        }

        public override DetailPageConfig<YouTubeSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, YouTubeSchema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = null;
                    viewModel.Description = item.Summary.ToSafeString();
                    viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(null);
                    viewModel.Content = item.EmbedHtmlFragment;
					viewModel.Source = item.ExternalUrl;
                });

                var actions = new List<ActionConfig<YouTubeSchema>>
                {
                    ActionConfig<YouTubeSchema>.Link("Go To Source", (item) => item.ExternalUrl.ToSafeString()),
                };

                return new DetailPageConfig<YouTubeSchema>
                {
                    Title = "Developer Videos",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }
    }
}
