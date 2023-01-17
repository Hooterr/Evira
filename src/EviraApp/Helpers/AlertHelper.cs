using CommunityToolkit.Maui.Views;

namespace Evira.App;

public static class AlertHelper
{
    public static Task ShowInfoAsync(string message)
    {
        return Application.Current.MainPage.DisplayAlert("Info", message, "OK");
    }
}