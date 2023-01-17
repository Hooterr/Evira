using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Evira.App.Controls;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class VerificationCodeEntryControlItem : ObservableObject
{
    [ObservableProperty]
    private bool _isSelected;

    [ObservableProperty]
    private string _text;

}

public partial class VerificationCodeEntryControl : ContentView
{
    private double _itemWidth = (double)MaxItemWidthProperty.DefaultValue;
    public double ItemWidth
    {
        get => _itemWidth;
        set
        {
            _itemWidth = value;
            OnPropertyChanged(nameof(ItemWidth));
        }
    }

    public VerificationCodeEntryControl()
    {
        InitializeComponent();
        for (int i = 0; i < (int)CodeLengthProperty.DefaultValue; i++)
        {
            Items.Add(new VerificationCodeEntryControlItem());
        }
        BindableLayout.SetItemsSource(stack, Items);
    }

    public static readonly BindableProperty CodeProperty = BindableProperty.Create(
        nameof(Code),
        typeof(string),
        typeof(VerificationCodeEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (b, o, v) => ((VerificationCodeEntryControl)b).CodePropertyChanged((string)o, (string)v));

    public string Code
    {
        get => (string)GetValue(CodeProperty);
        set => SetValue(CodeProperty, value);
    }
    
    public static readonly BindableProperty CodeLengthProperty = BindableProperty.Create(
        nameof(CodeLength),
        typeof(int),
        typeof(VerificationCodeEntryControl),
        defaultValue: 4,
        propertyChanged: (b, o, v) => ((VerificationCodeEntryControl)b).CodeLengthPropertyChanged((int)o, (int)v));

    public int CodeLength
    {
        get => (int)GetValue(CodeLengthProperty);
        set => SetValue(CodeLengthProperty, value);
    }

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VerificationCodeEntryControl),
        defaultValue: -1,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (b, o, v) => ((VerificationCodeEntryControl)b).SelectedIndexPropertyChanged((int)o, (int)v));

    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    public static readonly BindableProperty MaxItemWidthProperty = BindableProperty.Create(
        nameof(MaxItemWidth),
        typeof(double),
        typeof(VerificationCodeEntryControl),
        defaultValue: 80d,
        propertyChanged: (b, o, v) => ((VerificationCodeEntryControl)b).MaxItemWidthPropertyChanged((double)o, (double)v));

    public double MaxItemWidth
    {
        get => (double)GetValue(MaxItemWidthProperty);
        set => SetValue(MaxItemWidthProperty, value);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        CalculateItemWidth();
    }

    private void CalculateItemWidth()
    {
        if (Width == -1.0d)
        {
            return;
        }
        ItemWidth = Math.Min(MaxItemWidth, (Width - Math.Max(CodeLength - 1, 0) * stack.Spacing) / CodeLength);
    }

    private ObservableCollection<VerificationCodeEntryControlItem> Items { get; } = new();

    private void CodePropertyChanged(string oldValue, string newValue)
    {
        if (string.IsNullOrEmpty(newValue))
        {
            foreach (var item in Items)
            {
                item.Text = string.Empty;
            }

            return;
        }
        
        for (var i = 0; i < CodeLength; i++)
        {
            var element = newValue.ElementAtOrDefault(i);
            Items[i].Text = element == default(char) ? string.Empty : element.ToString();
        }
    }
    
    private void CodeLengthPropertyChanged(int oldValue, int newValue)
    {
        if (Items.Count > newValue)
        {
            for (var i = Items.Count - 1; i > newValue - 1; i--)
            {
                Items.RemoveAt(i);
            }
        }
        else if (Items.Count < newValue)
        {
            for (var i = Items.Count; i < newValue; i++)
            {
                Items.Add(new VerificationCodeEntryControlItem());
            }
        }

        CalculateItemWidth();
    }

    private void SelectedIndexPropertyChanged(int oldValue, int newValue)
    {
        foreach (var item in Items)
        {
            item.IsSelected = false;
        }

        var element = Items.ElementAtOrDefault(newValue);
        if (element != null)
        {

            element.IsSelected = true;
        }
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        if (sender is not VisualElement element)
        {
            return;
        }

        if (element.BindingContext is not VerificationCodeEntryControlItem item)
        {
            return;
        }

        var idx = Items.IndexOf(item);
        if (idx == -1)
        {
            return;
        }

        SelectedIndex = idx;
    }

    private void MaxItemWidthPropertyChanged(double oldValue, double newValue)
    {
        CalculateItemWidth();
    }
}