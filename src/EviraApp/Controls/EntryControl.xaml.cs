using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Markup;
using Evira.App.AttachedProperties;
using Evira.App.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;

namespace Evira.App.Controls;

public partial class EntryControl : ContentView
{
    private bool _isPasswordHiden = true;

	public EntryControl()
	{
		InitializeComponent();
        entry.Bind(Entry.TextProperty, nameof(Text), source: this);
        entry.Bind(Entry.PlaceholderProperty, nameof(Placeholder), source: this);
        entry.Bind(Entry.IsPasswordProperty, nameof(IsPassword), source: this);
        EyeIcon.Bind(VisualElement.IsVisibleProperty, nameof(IsPassword), source: this);
	}

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder),
        typeof(string),
        typeof(EntryControl));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(EntryControl),
        defaultBindingMode: BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword),
        typeof(bool),
        typeof(EntryControl));

    public static readonly BindableProperty ImageProperty = BindableProperty.Create(
        nameof(Image),
        typeof(string),
        typeof(EntryControl),
        propertyChanged: (b, o, n) => ((EntryControl)b).ImagePropertyChanged((string)o, (string)n));

    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    private void ImagePropertyChanged(string oldValue, string newValue)
    {
        LeadingImage.Source = newValue;
        LeadingImage.IsVisible = !string.IsNullOrEmpty(newValue);
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    private void Entry_Focused(object sender, FocusEventArgs e)
    {
        border.SetAppTheme(Border.StrokeProperty, ColorResources.Get("DarkDark3"), ColorResources.Get("OthersWhite"));
        LeadingImage.SetAppTheme(TintColorMapper.TintColorProperty, ColorResources.Get("DarkDark3"), ColorResources.Get("OthersWhite"));
        SetEyeIconTint(true);
    }

    private void Entry_Unfocused(object sender, FocusEventArgs e)
    {
        border.SetAppTheme(Border.StrokeProperty, ColorResources.Get("Greyscale50"), ColorResources.Get("DarkDark2"));
        TintColorMapper.SetTintColor(LeadingImage, ColorResources.Get("Greyscale500"));
        SetEyeIconTint(false);
    }        

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        _isPasswordHiden = !_isPasswordHiden;
        entry.IsPassword = _isPasswordHiden;
        EyeIcon.Source = _isPasswordHiden ? "show_bold" : "hide_bold";
        // Need to set it here because updating image source doesn't trigger tint update
        TintColorMapper.SetTintColor(EyeIcon, null);
        SetEyeIconTint(entry.IsFocused);        
    }

    private void SetEyeIconTint(bool isFocused)
    {
        if (isFocused)
        {
            EyeIcon.SetAppTheme(TintColorMapper.TintColorProperty, ColorResources.Get("DarkDark3"), ColorResources.Get("OthersWhite"));
        }
        else
        {
            TintColorMapper.SetTintColor(EyeIcon, ColorResources.Get("Greyscale500"));
        }
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        entry.Focus();
    }
}
