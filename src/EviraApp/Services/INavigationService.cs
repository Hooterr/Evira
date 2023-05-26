namespace Evira.App.Services;

public interface INavigationService
{
    Task<bool> PushAsync<T>() where T : ContentPage;
    Task<bool> PopAsync();
}