using System.Windows.Input;
using Evira.App.Models;

namespace Evira.App.Controls;

public partial class SpecialOfferView : ContentView
{
    public SpecialOfferView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty ModelProperty = BindableProperty.Create(
        nameof(Model),
        typeof(HomeSpecialOfferModel),
        typeof(SpecialOfferView),
        defaultValue: null,
        propertyChanged: (b, o, v) => ((SpecialOfferView)b).ModelPropertyChanged((HomeSpecialOfferModel)o, (HomeSpecialOfferModel)v));

    public HomeSpecialOfferModel Model
    {
        get => (HomeSpecialOfferModel)GetValue(ModelProperty);
        set => SetValue(ModelProperty, value);
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(SpecialOfferView),
        defaultValue: null);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    
    
    private void ModelPropertyChanged(HomeSpecialOfferModel oldValue, HomeSpecialOfferModel newValue)
    {
        border.BindingContext = newValue;
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        Command?.Execute(Model);
    }
}