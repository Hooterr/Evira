using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Markup;

namespace Evira.App.Controls;

public partial class ProfileImageControl : ContentView
{
    public ProfileImageControl()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(
        nameof(Source),
        typeof(string),
        typeof(ProfileImageControl),
        defaultValue: null,
        propertyChanged: (b, o, v) => ((ProfileImageControl)b).SourcePropertyChanged((string)o, (string)v));

    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    private void SourcePropertyChanged(string oldValue, string newValue)
    {
        if (string.IsNullOrEmpty(newValue))
        {
            image.SetAppTheme(Image.SourceProperty, "profile_placeholder_light", "profile_placeholder_dark");
        }
        else
        {
            image.Source = newValue;
        }
    }
    
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(ProfileImageControl),
        defaultValue: null);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }


    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        Command?.Execute(null);
    }
}