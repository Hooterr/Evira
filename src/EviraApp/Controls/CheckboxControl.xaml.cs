using CommunityToolkit.Maui.Markup;
using Evira.App.Helpers;

namespace Evira.App.Controls;

public partial class CheckboxControl : ContentView
{
	public CheckboxControl()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(CheckboxControl),
        defaultBindingMode: BindingMode.TwoWay,
        defaultValue: false,
        propertyChanged: (b, o, n) => ((CheckboxControl)b).IsCheckedPropertyChanged((bool)o, (bool)n));

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    private void IsCheckedPropertyChanged(bool oldValue, bool newValue)
    {
        CheckIcon.IsVisible = newValue;
        if (newValue)
        {
            border.SetAppTheme(Border.BackgroundColorProperty, ColorResources.Get("Primary500"), ColorResources.Get("DarkDark3"));
        }
        else
        {
            border.BackgroundColor = Colors.Transparent;
        }
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(CheckboxControl),
        propertyChanged: (b, o, n) => ((CheckboxControl)b).TextPropertyChanged((string)o, (string)n));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private void TextPropertyChanged(string oldValue, string newValue)
    {
        TextLabel.Text = newValue;
        TextLabel.IsVisible = !string.IsNullOrEmpty(newValue);
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        IsChecked = !IsChecked;
    }
}
