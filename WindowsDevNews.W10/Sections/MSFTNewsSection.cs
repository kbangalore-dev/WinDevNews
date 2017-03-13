using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Twitter;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp;
using System.Linq;

using WindowsDevNews.Navigation;
using WindowsDevNews.ViewModels;

namespace WindowsDevNews.Sections
{
    public class MSFTNewsSection : Section<TwitterSchema>
    {
		private TwitterDataProvider _dataProvider;

		public MSFTNewsSection()
		{
			_dataProvider = new TwitterDataProvider(new TwitterOAuthTokens
			{
				ConsumerKey = "xMGgzBpKTq5eTlyCDBX0XeFwc",
                    ConsumerSecret = "yj0hErBh9Cd8LVy8bJK9bYLp5eDcf3S7B7QgjDcFPyWuHFz0Y5",
                    AccessToken = "15854021-TuP94fkvTkVSJvQJeaKooEgzvycP32bWWhrY3r3A1",
                    AccessTokenSecret = "xmk9JvZv1oDY89WCIhVCcBxqoLlZ2anypJDTJaNlLhPqI"
			});
		}

		public override async Task<IEnumerable<TwitterSchema>> GetDataAsync(SchemaBase connectedItem = null)
        {
            var config = new TwitterDataConfig
            {
                QueryType = TwitterQueryType.User,
                Query = @"MSFTnews"
            };
            return await _dataProvider.LoadDataAsync(config, MaxRecords);
        }

        public override async Task<IEnumerable<TwitterSchema>> GetNextPageAsync()
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

        public override ListPageConfig<TwitterSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<TwitterSchema>
                {
                    Title = "MSFT News",

                    Page = typeof(Pages.MSFTNewsListPage),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.UserName.ToSafeString();
                        viewModel.SubTitle = item.Text.ToSafeString();
                        viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(item.UserProfileImageUrl.ToSafeString());
                    },
                    DetailNavigation = (item) =>
                    {
                        return new NavInfo
                        {
                            NavigationType = NavType.DeepLink,
                            TargetUri = new Uri(item.Url)
                        };
                    }
                };
            }
        }

        public override DetailPageConfig<TwitterSchema> DetailPage
        {
            get { return null; }
        }
    }
}
