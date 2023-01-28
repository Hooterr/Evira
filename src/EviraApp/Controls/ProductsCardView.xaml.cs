using Microsoft.Maui.Controls.Shapes;
using System.Windows.Input;

namespace Evira.App.Controls;

public partial class ProductsCardView : ContentView
{
	public ProductsCardView()
	{
		InitializeComponent();
	}

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty NameProperty = BindableProperty.Create(
        propertyName: nameof(Name),
        returnType: typeof(string),
        declaringType: typeof(ProductsCardView),
        defaultValue: null);

    public double Rating
    {
        get => (double)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }

    public static readonly BindableProperty RatingProperty = BindableProperty.Create(
        propertyName: nameof(Rating),
        returnType: typeof(double),
        declaringType: typeof(ProductsCardView),
        defaultValue: 0d,
        propertyChanged: (b, o, n) => ((ProductsCardView)b).OnRatingPropertyChanged((double)o, (double)n));

    private void OnRatingPropertyChanged(double _, double newValue)
    {
        ratingImage.Clip = new RectangleGeometry
        {
            Rect = new Rect(0, 0, newValue / 5.0d * 24, 24)
        };
    }

    public int SoldCount
    {
        get => (int)GetValue(SoldCountProperty);
        set => SetValue(SoldCountProperty, value);
    }

    public static readonly BindableProperty SoldCountProperty = BindableProperty.Create(
        propertyName: nameof(SoldCount),
        returnType: typeof(int),
        declaringType: typeof(ProductsCardView),
        defaultValue: 0);

    public double Price
    {
        get => (double)GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }

    public static readonly BindableProperty PriceProperty = BindableProperty.Create(
        propertyName: nameof(Price),
        returnType: typeof(double),
        declaringType: typeof(ProductsCardView),
        defaultValue: 0d);

    public bool IsFavourite
    {
        get => (bool)GetValue(IsFavouriteProperty);
        set => SetValue(IsFavouriteProperty, value);
    }

    public static readonly BindableProperty IsFavouriteProperty = BindableProperty.Create(
        propertyName: nameof(IsFavourite),
        returnType: typeof(bool),
        declaringType: typeof(ProductsCardView),
        defaultValue: false);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        propertyName: nameof(Command),
        returnType: typeof(ICommand),
        declaringType: typeof(ProductsCardView),
        defaultValue: null);

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        propertyName: nameof(CommandParameter),
        returnType: typeof(object),
        declaringType: typeof(ProductsCardView),
        defaultValue: null);


    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        propertyName: nameof(ImageSource),
        returnType: typeof(string),
        declaringType: typeof(ProductsCardView),
        defaultValue: null);

    public ICommand FavouriteCommand
    {
        get => (ICommand)GetValue(FavouriteCommandProperty);
        set => SetValue(FavouriteCommandProperty, value);
    }

    public static readonly BindableProperty FavouriteCommandProperty = BindableProperty.Create(
        propertyName: nameof(FavouriteCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(ProductsCardView),
        defaultValue: null);

}