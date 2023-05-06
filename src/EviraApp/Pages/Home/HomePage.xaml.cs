using Evira.App.Enums;
using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Home;

public partial class HomePage : BaseContentPage<HomePageModel>
{
    private readonly Thickness safeArea;

    public HomePage(HomePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
        safeArea = GetSafeAreaInsets();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
#if ANDROID
        if (width == 0 || height == 0)
        {
            return;
        }
        contentSpacer.HeightRequest = searchView.Y + searchView.Height;
#endif
    }
    
    private void ScrollUpButtonTapped(object sender, TappedEventArgs e)
    {
        mainCollection.ScrollTo(0, animate: true);
    }

    private bool reachedThreshold;
    private void MainCollection_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        //headerView.TranslationY = -Math.Min(e.VerticalOffset, headerView.Y + headerView.Height - safeArea.Top);
        searchView.TranslationY = -Math.Min(e.VerticalOffset, safeArea.Top + searchView.Padding.Top);

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

    private void MainGrid_OnSizeChanged(object sender, EventArgs e)
    {
#if IOS
        contentSpacer.HeightRequest = searchView.Y + searchView.Height;

        // Yikes...
        var mi = typeof(VisualElement).GetMethod("InvalidateMeasure", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

        mi.Invoke(headerLayout, null);
#endif
    }
}
