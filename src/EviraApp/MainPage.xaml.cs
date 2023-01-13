using Evira.App.Pages.Debug;

namespace Evira.App;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(ControlGalleryPage));
    }
}


