using System.Diagnostics;
using Evira.App.DependencyServices;
using Evira.App.PageModels.Onboarding;
using Evira.App.Pages.Abstract;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Evira.App.Pages.Onboarding;

public partial class WelcomePage : BaseContentPage<WelcomePageModel>
{
	
	public WelcomePage(WelcomePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
		image.Source =
			"https://images.unsplash.com/photo-1552374196-1ab2a1c593e8?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80";
	}

	protected override async void OnAppearing()
	{
		On<iOS>().SetUseSafeArea(false);
		base.OnAppearing();
		var safeAreaInsets = GetSafeAreaInsets();
		LabelsContainer.Padding = new Thickness(0, 0, 0, safeAreaInsets.Bottom);
		
		await Task.Delay(250);
		await mainGrid.FadeTo(1.0);
	}
}
