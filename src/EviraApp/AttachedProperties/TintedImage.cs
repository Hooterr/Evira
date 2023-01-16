using Evira.App.Extensions;
using Microsoft.Maui.Handlers;
using IImage = Microsoft.Maui.IImage;

namespace Evira.App.AttachedProperties;

public static class TintedImageEffect
{
     public static readonly BindableProperty TintColorProperty = BindableProperty
         .CreateAttached("TintColor", typeof(Color), typeof(Image), null);

    public static Color GetTintColor(BindableObject view) => (Color)view.GetValue(TintColorProperty);

    public static void SetTintColor(BindableObject view, Color? value) => view.SetValue(TintColorProperty, value);

    public static void ApplyTintColor()
    {
        ImageHandler.Mapper.ModifyMapping(nameof(Image.Source), (handler, view, old) =>
        {
            old?.Invoke(handler, view);
            ApplyTintColor(handler, view);
        });
        
        ImageHandler.Mapper.AppendToMapping("TintColor", ApplyTintColor);
    }

    private static void ApplyTintColor(IImageHandler handler, IImage view)
    {
        var tintColor = GetTintColor((Image)handler.VirtualView);

        if (tintColor is not null)
        {
            CustomImageExtensions.ApplyColor(handler.PlatformView, tintColor);
        }
        else
        {
            CustomImageExtensions.ClearColor(handler.PlatformView);
        }
    }
}