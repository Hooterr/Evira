using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace Evira.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
		MainPage = new AppShell();
	}

	public ResourceDictionary Colors => colors;
}

