using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Home;

public partial class HomePage : BaseContentPage<HomePageModel>
{
	public HomePage(HomePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (width == 0 || height == 0)
        {
            return;
        }

        contentSpacer.HeightRequest = searchView.Y + searchView.Height;
    }

    private void ScrollUpButtonTapped(object sender, TappedEventArgs e)
    {
        mainCollection.ScrollTo(0, animate: true);
    }

    private bool reachedThreshold;
    private void MainCollection_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        headerView.TranslationY = -Math.Min(e.VerticalOffset, headerView.Y + headerView.Height);
        searchView.TranslationY = -Math.Min(e.VerticalOffset, searchView.Y);

        if (!reachedThreshold && e.VerticalOffset > 30)
        {
            System.Diagnostics.Debug.WriteLine("Fading to 1.0");
            scrollButton.FadeTo(1.0);
            reachedThreshold = true;
        }
        else if (reachedThreshold && e.VerticalOffset < 30)
        {
            System.Diagnostics.Debug.WriteLine("Fading to 0.0");
            scrollButton.FadeTo(0.0);
            reachedThreshold = false;
        }
    }
}
