namespace Evira.App.Controls;

public class DataTemplatedView : ContentView
{
	public DataTemplatedView()
	{
    }

    public static readonly BindableProperty DataTemplateProperty = BindableProperty.Create(
        nameof(DataTemplate),
        typeof(DataTemplate),
        typeof(DataTemplatedView),
        propertyChanged: (b, o, n) => ((DataTemplatedView)b).DataTemplatePropertyChanged((DataTemplate)o, (DataTemplate)n));

    public DataTemplate DataTemplate
    {
        get => (DataTemplate)GetValue(DataTemplateProperty);
        set => SetValue(DataTemplateProperty, value);
    }

    private void DataTemplatePropertyChanged(DataTemplate oldValue, DataTemplate newValue)
    {
        if (newValue is null)
        {
            Content = null;
            return;
        }

        var view = (View)newValue.CreateContent();
        Content = view;
    }
}
