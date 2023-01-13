using System;
using CommunityToolkit.Mvvm.Input;
using Evira.App.PageModels.Abstract;
using Evira.App.Pages.Login;
using Evira.App.Pages.Onboarding;

namespace Evira.App.PageModels.Debug
{
	public partial class ControlGalleryPageModel : BasePageModel
	{
		public ControlGalleryPageModel()
		{
			Title = "Control gallery";
		}

		[RelayCommand]
		public async Task OpenWelcome()
		{
			await Shell.Current.GoToAsync(nameof(WelcomePage));
		}

		[RelayCommand]
		public async Task OpenLoginStart()
		{
			await Shell.Current.GoToAsync(nameof(LoginStartPage));
		}

	}
}

