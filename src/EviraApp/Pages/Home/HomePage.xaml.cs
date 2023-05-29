using Evira.App.Enums;
using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Home;

public partial class HomePage : BaseContentPage<HomePageModel>
{
    private readonly Thickness _safeArea;
    private bool _reachedThreshold;

    public HomePage(HomePageModel pageModel) : base(pageModel)
    {
        InitializeComponent();
        _safeArea = GetSafeAreaInsets();
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
        mainCollection.ScrollTo(0, animate: false);
        searchView.TranslateTo(0, 0, 127);
        scrollButton.FadeTo(0.0, 127);
    }

    private void MainCollection_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
#if IOS
        searchView.TranslationY = -Math.Min(e.VerticalOffset, _safeArea.Top + searchView.Padding.Top);
#elif ANDROID
        searchView.TranslationY = -Math.Min(e.VerticalOffset, _safeArea.Top + searchView.Height);
#endif
        
        if (!_reachedThreshold && e.VerticalOffset > 30)
        {
            System.Diagnostics.Debug.WriteLine("Fading to 1.0");
            scrollButton.FadeTo(1.0);
            _reachedThreshold = true;
        }
        else if (_reachedThreshold && e.VerticalOffset < 30)
        {
            System.Diagnostics.Debug.WriteLine("Fading to 0.0");
            scrollButton.FadeTo(0.0);
            _reachedThreshold = false;
        }
    }

    private void MainGrid_OnSizeChanged(object sender, EventArgs e)
    {
#if IOS
        contentSpacer.HeightRequest = searchView.Y + searchView.Height;

        // Yikes...
        var methodInfo = typeof(VisualElement).GetMethod("InvalidateMeasure", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

        methodInfo?.Invoke(headerLayout, null);
#endif
    }
}
