using Microsoft.Maui.Platform;
using Color = Microsoft.Maui.Graphics.Color;
using Android.Graphics;
using Android.Widget;

namespace Evira.App.Extensions;

public static class CustomImageExtensions
{
    public static void ApplyColor(ImageView imageView, Color color)
    {
        imageView.SetColorFilter(new PorterDuffColorFilter(color.ToPlatform(), PorterDuff.Mode.SrcIn ?? throw new NullReferenceException()));
    }

    public static void ClearColor(ImageView imageView)
    {
        imageView.ClearColorFilter();
    }
}