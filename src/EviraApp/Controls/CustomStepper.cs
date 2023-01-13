using Microsoft.Maui.Controls.Shapes;

namespace Evira.App.Controls;

public class CustomStepper : ContentView
{
	private readonly StackLayout _stackLayout;
	private readonly BoxView _currentStepView;
	private readonly int _size = 10;

	public CustomStepper()
	{
		_stackLayout = new()
		{
			Orientation = StackOrientation.Horizontal,
			Spacing = _size,
		};

		_currentStepView = new BoxView()
		{
			WidthRequest = _size * 3,
			CornerRadius = _size / 2f,
			HeightRequest = _size,
			HorizontalOptions = LayoutOptions.Start,
		};

        Content = new Grid()
		{
			_stackLayout,
			_currentStepView,
		};

        _currentStepView.SetAppTheme(BoxView.ColorProperty, Color.FromArgb("#313130"), Colors.White);
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
			_currentStepView.TranslateTo(newValue.Value * 2 * _size, 0);
		}
	}

	public static readonly BindableProperty SizeProperty = BindableProperty.Create(
		nameof(Size),
		typeof(int),
		typeof(CustomStepper),
		defaultValue: 0,
		propertyChanged: (b, o, n) => ((CustomStepper)b).SizePropertyChanged((int)o, (int)n));

	public int Size
	{
		get => (int)GetValue(SizeProperty);
		set => SetValue(SizeProperty, value);
	}


	private int? CoerceCurrentValue(int? value)
	{
		if (value == null)
		{
			return value;
		}

		if (Size == 0)
		{
			return null;
		}

		return Math.Min(value.Value, Size);
	}

    private void SizePropertyChanged(int oldValue, int newValue)
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

	private Ellipse CreateBullet()
	{
		var result = new Ellipse()
		{
			HeightRequest = _size,
			WidthRequest = _size,
		};

		result.SetAppTheme(Ellipse.FillProperty, Color.FromArgb("#E0E0E0"), Color.FromArgb("#35383F")); // TODO remove hardcoded values
		return result;
	}

}
