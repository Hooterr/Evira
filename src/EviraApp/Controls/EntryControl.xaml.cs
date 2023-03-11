using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Markup;
using Evira.App.AttachedProperties;
using Evira.App.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using System.Windows.Input;

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
        entry.Bind(Entry.ReturnTypeProperty, nameof(ReturnType), source: this);
        entry.Bind(Entry.ReturnCommandProperty, nameof(ReturnCommand), source: this);
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

    public ReturnType ReturnType
    {
        get => (ReturnType)GetValue(ReturnTypeProperty);
        set => SetValue(ReturnTypeProperty, value);
    }

    public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
        propertyName: nameof(ReturnType),
        returnType: typeof(ReturnType),
        declaringType: typeof(EntryControl),
        defaultValue: default(ReturnType));

    public ICommand ReturnCommand
    {
        get => (ICommand)GetValue(ReturnCommandProperty);
        set => SetValue(ReturnCommandProperty, value);
    }

    public static readonly BindableProperty ReturnCommandProperty = BindableProperty.Create(
        propertyName: nameof(ReturnCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(EntryControl),
        defaultValue: null);



    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword),
        typeof(bool),
        typeof(EntryControl),
        propertyChanged: (b, o, n) => ((EntryControl)b).IsPasswordPropertyChanged((bool)o, (bool)n));

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

    private void IsPasswordPropertyChanged(bool oldValue, bool newValue)
    {
        if (newValue)
        {
            EyeIcon.IsVisible = true;
            EyeIcon.Source = _isPasswordHiden ? "show_bold" : "hide_bold";
        }
        else
        {
            EyeIcon.Source = RightImage;
            EyeIcon.IsVisible = !string.IsNullOrEmpty(RightImage);
        }
    }

    public string RightImage
    {
        get => (string)GetValue(RightImageProperty);
        set => SetValue(RightImageProperty, value);
    }

    public ICommand RightImageCommand
    {
        get => (ICommand)GetValue(RightImageCommandProperty);
        set => SetValue(RightImageCommandProperty, value);
    }

    public static readonly BindableProperty RightImageCommandProperty = BindableProperty.Create(
        propertyName: nameof(RightImageCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(EntryControl),
        defaultValue: null);

    public static readonly BindableProperty RightImageProperty = BindableProperty.Create(
        propertyName: nameof(RightImage),
        returnType: typeof(string),
        declaringType: typeof(EntryControl),
        defaultValue: null,
        propertyChanged: (b, o, n) => ((EntryControl)b).RightImagePropertyChanged((string)o, (string)n));

    private void RightImagePropertyChanged(string oldValue, string newValue)
    {
        if (!IsPassword)
        {
            EyeIcon.Source = newValue;
        }
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    private void Entry_Focused(object sender, FocusEventArgs e)
    {
        border.SetAppTheme(Border.StrokeProperty, ColorResources.Get("DarkDark3"), ColorResources.Get("OthersWhite"));
        LeadingImage.SetAppTheme(TintedImageEffect.TintColorProperty, ColorResources.Get("DarkDark3"), ColorResources.Get("OthersWhite"));
        EyeIcon.SetAppTheme(TintedImageEffect.TintColorProperty, ColorResources.Get("DarkDark3"), ColorResources.Get("OthersWhite"));

    }

    private void Entry_Unfocused(object sender, FocusEventArgs e)
    {
        border.SetAppTheme(Border.StrokeProperty, ColorResources.Get("Greyscale50"), ColorResources.Get("DarkDark2"));
        TintedImageEffect.SetTintColor(LeadingImage, ColorResources.Get("Greyscale500"));
        TintedImageEffect.SetTintColor(EyeIcon, ColorResources.Get("Greyscale500"));
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (IsPassword)
        {
            _isPasswordHiden = !_isPasswordHiden;
            entry.IsPassword = _isPasswordHiden;
            EyeIcon.Source = _isPasswordHiden ? "show_bold" : "hide_bold";
        }
        else
        {
            RightImageCommand?.Execute(null);
        }
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        entry.Focus();
    }
}
