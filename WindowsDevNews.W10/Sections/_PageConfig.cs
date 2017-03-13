using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using WindowsDevNews.Navigation;
using WindowsDevNews.ViewModels;

namespace WindowsDevNews.Sections
{
    public abstract class PageConfigBase
    {
        public string Title { get; set; }
    }

    public class ListPageConfig<T> : PageConfigBase where T : SchemaBase
    {
        public Type Page { get; set; }
        public Func<T, NavInfo> DetailNavigation { get; set; }
        public Action<ItemViewModel, T> LayoutBindings { get; set; }
        public OrderType OrderType { get; set; }
    }

    public class DetailPageConfig<T> : PageConfigBase where T : SchemaBase
    {
        public List<Action<ItemViewModel, T>> LayoutBindings { get; set; }
        public List<ActionConfig<T>> Actions { get; set; }
    }
}
