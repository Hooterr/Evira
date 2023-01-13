using Microsoft.Maui.Platform;
using UIKit;

namespace Evira.App.Extensions;

public static class CustomImageExtensions
{
    public static void ApplyColor(UIImageView imageView, Color color)
    {
        imageView.Image = imageView.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
        imageView.TintColor = color.ToPlatform();
    }

    public static void ClearColor(UIImageView imageView)
    {
        imageView.Image = imageView.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
    }
}