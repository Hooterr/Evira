using CommunityToolkit.Mvvm.DependencyInjection;
using Evira.App.Pages;
using Evira.App.Pages.Cart;
using Evira.App.Pages.Debug;
using Evira.App.Pages.Home;
using Evira.App.Pages.Profile;
using Evira.App.Pages.Wallet;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace Evira.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
		//MainPage = new AppShell();
		var mainPage = new MainTabbedPage();
		MainPage = mainPage;
		
		mainPage.Children.Add(new NavigationPage(IoC.Current.GetRequiredService<HomePage>())
		{
			IconImageSource = "home_light"
		});
		mainPage.Children.Add(new NavigationPage(IoC.Current.GetRequiredService<CartPage>()));
		mainPage.Children.Add(new NavigationPage(IoC.Current.GetRequiredService<HomePage>())
		{
			IconImageSource = "home_light"
		});
		mainPage.Children.Add(new NavigationPage(IoC.Current.GetRequiredService<WalletPage>()));
		mainPage.Children.Add(new NavigationPage(IoC.Current.GetRequiredService<ControlGalleryPage>())
		{
			IconImageSource = "profile_light"
		});
	}

	public ResourceDictionary Colors => colors;
}