using CommunityToolkit.Maui.Views;

namespace Evira.App;

public static class AlertHelper
{
    public static Task ShowInfoAsync(this ContentPage page, string message)
    {
        return page.DisplayAlert("Info", message, "OK");
    }
}