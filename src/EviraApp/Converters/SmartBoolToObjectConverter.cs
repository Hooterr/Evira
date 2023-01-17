#nullable enable
using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace Evira.App.Converters;

// TODO respond to true and false value changes
public class SmartBoolToObjectConverter : BindableObject, IValueConverter
{
    public static readonly BindableProperty TrueValueProperty = BindableProperty.Create(
        nameof(TrueValue),
        typeof(object),
        typeof(SmartBoolToObjectConverter),
        defaultValue: null);

    public object TrueValue
    {
        get => GetValue(TrueValueProperty);
        set => SetValue(TrueValueProperty, value);
    }

    public static readonly BindableProperty FalseValueProperty = BindableProperty.Create(
        nameof(FalseValue),
        typeof(object),
        typeof(SmartBoolToObjectConverter),
        defaultValue: null);

    public object FalseValue
    {
        get => GetValue(FalseValueProperty);
        set => SetValue(FalseValueProperty, value);
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool valBool)
        {
            return valBool ? TrueValue : FalseValue;
        }

        return null;
    }
    

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}