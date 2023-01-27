using System.Windows.Input;

namespace Evira.App.Controls;

public interface IChipItem
{
    public bool IsSelected { get; }
}

public partial class ChipCarouselView : ContentView
{
	public ChipCarouselView()
	{
		InitializeComponent();
	}
    public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
        nameof(ItemTemplate),
        typeof(DataTemplate),
        typeof(ChipCarouselView),
        defaultValue: new DataTemplate());

    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IEnumerable<IChipItem>),
        typeof(ChipCarouselView));

    public IEnumerable<IChipItem> ItemsSource
    {
        get => (IEnumerable<IChipItem>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
        nameof(ItemSelectedCommand),
        typeof(ICommand),
        typeof(ChipCarouselView));

    public ICommand ItemSelectedCommand
    {
        get => (ICommand)GetValue(ItemSelectedCommandProperty);
        set => SetValue(ItemSelectedCommandProperty, value);
    }


    void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is not BindableObject ve)
        {
            return;
        }

        ItemSelectedCommand?.Execute(ve.BindingContext);
    }

}
