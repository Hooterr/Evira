using AsyncAwaitBestPractices;
using System.Diagnostics;

namespace Evira.App.Controls;

public partial class ProductsCardPlaceholderView : ContentView
{
    private readonly VisualElement[] _animatedElements;
	public ProductsCardPlaceholderView()
	{
		InitializeComponent();
        _animatedElements = new VisualElement[]
        {
            animationElement1,
            animationElement2,
            animationElement3,
            animationElement4,
        };
	}

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (width == -1d)
        {
            return;
        }

        AnimateAsync();
    }

    private IDispatcherTimer _timer;

    private void AnimateAsync()
    {
        _timer?.Stop();
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(1750);

        _timer.Tick += (s, e) =>
        {
            Debug.WriteLine("Timer ticked...");
            foreach (var element in _animatedElements)
            {
                element.TranslationX = -element.Width;
                element.TranslateTo(Width, 0d, length: 1250u);
            }
        };
        _timer.IsRepeating = true;
        _timer.Start();
    }

    protected override void OnParentChanged()
    {
        base.OnParentChanged();
        if (Parent == null)
        {
            _timer?.Stop();
            Debug.WriteLine("Timer stopped...");
        }
    }
}