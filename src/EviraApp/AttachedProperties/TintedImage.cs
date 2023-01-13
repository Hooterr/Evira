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
        ImageHandler.Mapper.Add("TintColor", (handler, view) =>
        {
            var tintColor = GetTintColor((Image)handler.VirtualView);

            if (tintColor is not null)
            {
#if ANDROID
                // Note the use of Android.Widget.ImageView which is an Android-specific API
                // You can find the Android implementation of `ApplyColor` here: https://github.com/pictos/MFCC/blob/1ef490e507385e050b0cfb6e4f5d68f0cb0b2f60/MFCC/TintColorExtension.android.cs#L9-L12
                CustomImageExtensions.ApplyColor(handler.PlatformView, tintColor);
#elif IOS
                // Note the use of UIKit.UIImage which is an iOS-specific API
                // You can find the iOS implementation of `ApplyColor` here: https://github.com/pictos/MFCC/blob/1ef490e507385e050b0cfb6e4f5d68f0cb0b2f60/MFCC/TintColorExtension.ios.cs#L7-L11
                CustomImageExtensions.ApplyColor(handler.PlatformView, tintColor);
#endif
            }
            else
            {
#if ANDROID
                // Note the use of Android.Widget.ImageView which is an Android-specific API
                // You can find the Android implementation of `ClearColor` here: https://github.com/pictos/MFCC/blob/1ef490e507385e050b0cfb6e4f5d68f0cb0b2f60/MFCC/TintColorExtension.android.cs#L14-L17
                CustomImageExtensions.ClearColor(handler.PlatformView);
#elif IOS
                // Note the use of UIKit.UIImage which is an iOS-specific API
                // You can find the iOS implementation of `ClearColor` here: https://github.com/pictos/MFCC/blob/1ef490e507385e050b0cfb6e4f5d68f0cb0b2f60/MFCC/TintColorExtension.ios.cs#L13-L16
                CustomImageExtensions.ClearColor(handler.PlatformView);
#endif
            }
        });
    }
}