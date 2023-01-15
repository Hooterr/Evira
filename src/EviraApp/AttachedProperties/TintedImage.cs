using Evira.App.Extensions;
using Microsoft.Maui.Handlers;

namespace Evira.App.AttachedProperties;

public static class TintColorMapper
{
     public static readonly BindableProperty TintColorProperty = BindableProperty.CreateAttached("TintColor", typeof(Color), typeof(Image), null);

    public static Color GetTintColor(BindableObject view) => (Color)view.GetValue(TintColorProperty);

    public static void SetTintColor(BindableObject view, Color? value) => view.SetValue(TintColorProperty, value);

    public static void ApplyTintColor()
    {
        ImageHandler.Mapper.AppendToMapping("TintColor", (handler, view) =>
        {
            var tintColor = GetTintColor((Image)handler.VirtualView);

            if (tintColor is not null)
            {
#if ANDROID
                CustomImageExtensions.ApplyColor(handler.PlatformView, tintColor);
#elif IOS
                CustomImageExtensions.ApplyColor(handler.PlatformView, tintColor);
#endif
            }
            else
            {
#if ANDROID
                CustomImageExtensions.ClearColor(handler.PlatformView);
#elif IOS
                CustomImageExtensions.ClearColor(handler.PlatformView);
#endif
            }
        });
    }
}