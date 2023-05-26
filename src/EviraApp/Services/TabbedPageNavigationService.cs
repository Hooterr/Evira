namespace Evira.App.Services;

public class TabbedPageNavigationService : INavigationService
{
    public async Task<bool> PushAsync<T>() where T : ContentPage
    {
        if (Application.Current?.MainPage is not TabbedPage tabbedPage)
        {
            return false;
        }

        var page = IoC.Current.GetService<T>();

        if (page is null)
        {
            return false;
        }
        
        await tabbedPage.CurrentPage.Navigation.PushAsync(page);
        
        return true;
    }

    public async Task<bool> PopAsync()
    {
        if (Application.Current?.MainPage is not TabbedPage tabbedPage)
        {
            return false;
        }

        await tabbedPage.CurrentPage.Navigation.PopAsync();

        return true;
    }
}