using Evira.App.DependencyServices;
using Evira.App.PageModels.Onboarding;
using Evira.App.Pages.Abstract;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Evira.App.Pages.Onboarding;

public partial class WalkthroughPage : BaseContentPage<WalkthroughPageModel>
{
	public WalkthroughPage(WalkthroughPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		On<iOS>().SetUseSafeArea(false);
        base.OnAppearing();

        var safeAreaInsets = GetSafeAreaInsets();
        wholeWrapper.Padding = new Thickness(0, safeAreaInsets.Top, 0, 0);
		bottomWrapper.Padding = new Thickness(0, 0, 0, safeAreaInsets.Bottom);
    }
}
