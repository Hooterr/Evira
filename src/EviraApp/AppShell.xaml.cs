using Evira.App.Pages.Debug;
using Evira.App.Pages.Login;
using Evira.App.Pages.Onboarding;
using Evira.App.Pages.AccountSetup;

namespace Evira.App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		Routing.RegisterRoute(nameof(ControlGalleryPage), typeof(ControlGalleryPage));
		
		// Welcome 
		Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
		Routing.RegisterRoute(nameof(WalkthroughPage), typeof(WalkthroughPage));
		
		// Login
		Routing.RegisterRoute(nameof(LoginStartPage), typeof(LoginStartPage));
		Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
		Routing.RegisterRoute(nameof(ForgotPasswordMethodPage), typeof(ForgotPasswordMethodPage));
		Routing.RegisterRoute(nameof(ForgotPasswordEnterCodePage), typeof(ForgotPasswordEnterCodePage));
		Routing.RegisterRoute(nameof(ForgotPasswordCreateNewPasswordPage), typeof(ForgotPasswordCreateNewPasswordPage));

		// Account
		Routing.RegisterRoute(nameof(CreatePinPage), typeof(CreatePinPage));
		Routing.RegisterRoute(nameof(FillProfilePage), typeof(FillProfilePage));
		Routing.RegisterRoute(nameof(SetupBiometricsPage), typeof(SetupBiometricsPage));

        InitializeComponent();
	}
}

