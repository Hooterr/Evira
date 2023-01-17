using System.Windows.Input;
using CommunityToolkit.Maui.Markup;

namespace Evira.App.Controls;

public partial class AppButton : ContentView
{
    public enum ButtonVariant
    {
        Rectangle,
        Round,
    }
    
    public AppButton()
    {
        InitializeComponent();
        RightImage.Bind(Image.SourceProperty, nameof(LeftImageSource), source: this);
        LeftImage.Bind(Image.SourceProperty, nameof(RightImageSource), source: this);
        LabelView.Bind(Label.TextProperty, nameof(Text), source: this);
    }
    
    public static readonly BindableProperty LeftImageSourceProperty = BindableProperty
        .Create(
            nameof(LeftImageSource),
            typeof(string),
            typeof(AppButton),
            defaultValue: null);

    public string LeftImageSource
    {
        get => (string)GetValue(LeftImageSourceProperty);
        set => SetValue(LeftImageSourceProperty, value);
    }

    
    public static readonly BindableProperty RightImageSourceProperty = BindableProperty
        .Create(
            nameof(RightImageSource),
            typeof(string),
            typeof(AppButton),
            defaultValue: null);

    public string RightImageSource
    {
        get => (string)GetValue(RightImageSourceProperty);
        set => SetValue(RightImageSourceProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty
        .Create(
            nameof(Text),
            typeof(string),
            typeof(AppButton),
            defaultValue: null);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public static readonly BindableProperty CommandProperty = BindableProperty
        .Create(
            nameof(Command),
            typeof(ICommand),
            typeof(AppButton),
            defaultValue: null);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty
        .Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(AppButton),
            defaultValue: null);

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        Command?.Execute(CommandParameter);
    }

    public static readonly BindableProperty VariantProperty = BindableProperty.Create(
        nameof(Variant),
        typeof(ButtonVariant),
        typeof(AppButton),
        defaultValue: ButtonVariant.Rectangle,
        propertyChanged: (b, o, v) => ((AppButton)b).VariantPropertyChanged((ButtonVariant)o, (ButtonVariant)v));

    public ButtonVariant Variant
    {
        get => (ButtonVariant)GetValue(VariantProperty);
        set => SetValue(VariantProperty, value);
    }

    private void VariantPropertyChanged(ButtonVariant oldValue, ButtonVariant newValue)
    {
        if (newValue == ButtonVariant.Rectangle)
        {
            BackgroundView.CornerRadius = 16;
        }
        else if (newValue == ButtonVariant.Round)
        {
            BackgroundView.CornerRadius = 29;
        }
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == IsEnabledProperty.PropertyName)
        {
            BackgroundView.IsEnabled = IsEnabled;
            LabelView.IsEnabled = IsEnabled;
        }
    }
}