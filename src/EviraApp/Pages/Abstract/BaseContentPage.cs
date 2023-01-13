using Evira.App.DependencyServices;
using Evira.App.Helpers;
using Evira.App.PageModels.Abstract;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Evira.App.Pages.Abstract;

public abstract class BaseContentPage<T> : ContentPage where T : BasePageModel
{
	// https://github.com/dotnet/maui/issues/2657
	private readonly bool _enableSafeAreaFix = true;
	private readonly ISafeAreaService _safeAreaService;
	
	protected BaseContentPage(T pageModel)
	{
		BindingContext = pageModel;
		this.SetAppTheme(BackgroundColorProperty, ColorResources.Get("OthersWhite"), ColorResources.Get("DarkDark1"));
		
		if (_enableSafeAreaFix)
		{
			_safeAreaService = IoC.Current.GetService<ISafeAreaService>();
		}
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		if (!_enableSafeAreaFix)
		{
			return;
		}

		if (On<iOS>().UsingSafeArea())
		{
			return;
		}

		var insets = GetSafeAreaInsets();
		Padding = new Thickness(-insets.Left, -insets.Top, -insets.Right, -insets.Bottom);
	}

	protected Thickness GetSafeAreaInsets()
	{
		if (_safeAreaService != null)
		{
			return _safeAreaService.GetSafeAreaInsets();
		}

		return Thickness.Zero;
	}
}
