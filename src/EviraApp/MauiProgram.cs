using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Evira.App.AttachedProperties;
using Evira.App.DependencyServices;
using Evira.App.PageModels.Debug;
using Evira.App.PageModels.Login;
using Evira.App.PageModels.Onboarding;
using Evira.App.Pages.Debug;
using Evira.App.Pages.Login;
using Evira.App.Pages.Onboarding;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace Evira.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMarkup()
			.ConfigureMauiHandlers(handlers =>
			{
			})
			.ConfigureFonts(fonts =>
			{
                fonts
                    .AddFont("Urbanist-Black.ttf", "UrbanistBlack")
                    .AddFont("Urbanist-Semibold.ttf", "UrbanistSemibold")
                    .AddFont("Urbanist-BlackItalic.ttf", "UrbanistBlackItalic")
                    .AddFont("Urbanist-Bold.ttf", "UrbanistBold")
                    .AddFont("Urbanist-BoldItalic.ttf", "UrbanistBoldItalic")
                    .AddFont("Urbanist-ExtraBold.ttf", "UrbanistExtraBold")
                    .AddFont("Urbanist-ExtraBoldItalic.ttf", "UrbanistExtraBoldItalic")
                    .AddFont("Urbanist-ExtraLight.ttf", "UrbanistExtraLight")
                    .AddFont("Urbanist-ExtraLightItalic.ttf", "UrbanistExtraLightItalic")
                    .AddFont("Urbanist-Italic.ttf", "UrbanistItalic")
                    .AddFont("Urbanist-Medium.ttf", "UrbanistMedium")
                    .AddFont("Urbanist-MediumItalic.ttf", "UrbanistMediumItalic")
                    .AddFont("Urbanist-Regular.ttf", "UrbanistRegular")
                    .AddFont("Urbanist-SemiBold.ttf", "UrbanistSemiBold")
                    .AddFont("Urbanist-SemiBoldItalic.ttf", "UrbanistSemiBoldItalic")
                    .AddFont("Urbanist-Thin.ttf", "UrbanistThin")
                    .AddFont("Urbanist-ThinItalic.ttf", "UrbanistThinItalic");

            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<ControlGalleryPageModel>();
		builder.Services.AddTransient<WelcomePageModel>();
		builder.Services.AddTransient<WalkthroughPageModel>();
		builder.Services.AddTransient<LoginStartPageModel>();
		builder.Services.AddTransient<SignUpPageModel>();
		builder.Services.AddTransient<SignInPageModel>();
		builder.Services.AddTransient<ForgotPasswordMethodPageModel>();
		builder.Services.AddTransient<ForgotPasswordEnterCodePageModel>();
		builder.Services.AddTransient<ForgotPasswordCreateNewPasswordPageModel>();
		
		builder.Services.AddTransient<ControlGalleryPage>();
		builder.Services.AddTransient<WelcomePage>();
		builder.Services.AddTransient<WalkthroughPage>();
		builder.Services.AddTransient<LoginStartPage>();
		builder.Services.AddTransient<SignUpPage>();
		builder.Services.AddTransient<SignInPage>();
		builder.Services.AddTransient<ForgotPasswordMethodPage>();
		builder.Services.AddTransient<ForgotPasswordEnterCodePage>();
		builder.Services.AddTransient<ForgotPasswordCreateNewPasswordPage>();

#if __IOS__
		builder.Services.AddSingleton<ISafeAreaService, Evira.App.SafeAreaService>();
#endif

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
		{
#if __ANDROID__
			handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
			handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
			handler.PlatformView.Layer.BackgroundColor = UIKit.UIColor.Clear.CGColor;
			handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
		});
		
		TintedImageEffect.ApplyTintColor();

		return builder.Build();
	}
}

