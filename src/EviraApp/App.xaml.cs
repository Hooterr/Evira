namespace Evira.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	public ResourceDictionary Colors => colors;
}

