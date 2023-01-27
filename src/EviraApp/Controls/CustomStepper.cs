using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Controls.Shapes;

namespace Evira.App.Controls;

public class CustomStepper : ContentView
{
	private StackLayout _stackLayout;
	private BoxView _currentStepView;
	
	public CustomStepper()
	{
		_stackLayout = new()
		{
			Orientation = StackOrientation.Horizontal,
			Spacing = Size,
		};

		_currentStepView = new BoxView()
		{
			WidthRequest = Size * 3,
			CornerRadius = Size / 2f,
			HeightRequest = Size,
			HorizontalOptions = LayoutOptions.Start,
		};

        Content = new Grid()
		{
			_stackLayout,
			_currentStepView,
		};

        _currentStepView.Bind(BoxView.ColorProperty, IndicatorColorProperty.PropertyName, source: this);
	}

    public static readonly BindableProperty CurrentProperty = BindableProperty.Create(
		nameof(Current),
		typeof(int?),
		typeof(CustomStepper),
		coerceValue: (b, v) => ((CustomStepper)b).CoerceCurrentValue((int?)v),
		defaultValue: null,
		propertyChanged: (b, o, n) => ((CustomStepper)b).CurrentPropertyChanged((int?)o, (int?)n));

	public int? Current
	{
		get => (int?)GetValue(CurrentProperty);
		set => SetValue(CurrentProperty, value);
	}

	private void CurrentPropertyChanged(int? oldValue, int? newValue)
	{
		_currentStepView.IsVisible = newValue != null;
		if (newValue.HasValue)
		{
			_currentStepView.TranslateTo(newValue.Value * 2 * Size, 0);
		}
	}

	public static readonly BindableProperty CountProperty = BindableProperty.Create(
		nameof(Count),
		typeof(int),
		typeof(CustomStepper),
		defaultValue: 0,
		propertyChanged: (b, o, n) => ((CustomStepper)b).CountPropertyChanged((int)o, (int)n));

	public int Count
	{
		get => (int)GetValue(CountProperty);
		set => SetValue(CountProperty, value);
	}
	
	private int? CoerceCurrentValue(int? value)
	{
		if (value == null)
		{
			return value;
		}

		if (Count == 0)
		{
			return null;
		}

		return Math.Min(value.Value, Count);
	}

    private void CountPropertyChanged(int oldValue, int newValue)
	{
		_stackLayout.Children.Clear();

		if (newValue == 0)
		{
			return;
		}

		for (int i = 0; i < newValue + 1; i++)
		{
            _stackLayout.Children.Add(CreateBullet());
        }
	}

    public static readonly BindableProperty SizeProperty = BindableProperty.Create(
	    nameof(Size),
	    typeof(double),
	    typeof(CustomStepper),
	    defaultValue: 10d,
	    propertyChanged: (b, o, v) => ((CustomStepper)b).SizePropertyChanged((double)o, (double)v));

    public double Size
    {
	    get => (double)GetValue(SizeProperty);
	    set => SetValue(SizeProperty, value);
    }

    private void SizePropertyChanged(double oldValue, double newValue)
    {
	    _stackLayout.Spacing = newValue;
	    _currentStepView.WidthRequest = 3 * newValue;
	    _currentStepView.HeightRequest = newValue;
	    _currentStepView.CornerRadius = newValue / 2d;

	    foreach (var item in _stackLayout.Children)
	    {
		    if (item is not VisualElement ve)
		    {
			    continue;
		    }
		    
		    ve.HeightRequest = newValue;
		    ve.WidthRequest = newValue;
	    }

	    if (Current != null)
	    {
		    _currentStepView.TranslationX = Current.Value * 2 * newValue;
	    }
    }

    public static readonly BindableProperty IndicatorColorProperty = BindableProperty.Create(
	    nameof(IndicatorColor),
	    typeof(Color),
	    typeof(CustomStepper),
	    defaultValue: Colors.Black);

    public Color IndicatorColor
    {
	    get => (Color)GetValue(IndicatorColorProperty);
	    set => SetValue(IndicatorColorProperty, value);
    }

    
    public static readonly BindableProperty DotsColorProperty = BindableProperty.Create(
	    nameof(DotsColor),
	    typeof(Color),
	    typeof(CustomStepper),
	    defaultValue: Colors.White);

    public Color DotsColor
    {
	    get => (Color)GetValue(DotsColorProperty);
	    set => SetValue(DotsColorProperty, value);
    }

    
	private Ellipse CreateBullet()
	{
		var result = new Ellipse()
		{
			HeightRequest = Size,
			WidthRequest = Size,
		};

		result.Bind(Shape.FillProperty, nameof(DotsColor), source: this);
		return result;
	}

}
