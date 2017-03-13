using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WindowsDevNews.Layouts.Controls
{
    public sealed partial class AdvertisingControl : UserControl
    {
	public double BannerWidth
        {
            get
            {
                if (Window.Current.Bounds.Width >= 500)
                {
                    return 728;
                }
                else
                {
                    return 300;
                }
            }
        }

        public double BannerHeight
        {
            get
            {
                if (Window.Current.Bounds.Width >= 500)
                {
                    return 90;
                }
                else
                {
                    return 50;
                }
            }
        }

        public AdvertisingControl()
        {
            this.InitializeComponent();
        }                
    }
}
