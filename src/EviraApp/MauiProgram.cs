using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Evira.App.AttachedProperties;
using Evira.App.DependencyServices;
using Evira.App.PageModels.AccountSetup;
using Evira.App.PageModels.Cart;
using Evira.App.PageModels.Debug;
using Evira.App.PageModels.Home;
using Evira.App.PageModels.Login;
using Evira.App.PageModels.Onboarding;
using Evira.App.PageModels.Orders;
using Evira.App.PageModels.Products;
using Evira.App.PageModels.Wallet;
using Evira.App.PageModels.Profile;
using Evira.App.Pages.Debug;
using Evira.App.Pages.Login;
using Evira.App.Pages.Onboarding;
using Evira.App.Pages.AccountSetup;
using Evira.App.Pages.Cart;
using Evira.App.Pages.Home;
using Evira.App.Pages.Orders;
using Evira.App.Pages.Products;
using Evira.App.Pages.Profile;
using Evira.App.Pages.Wallet;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Evira.App.Platforms;
using Evira.App.Services;

namespace Evira.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(Shell), typeof(MyShellRenderer));
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

        builder.Services.AddTransient<FillProfilePageModel>();
        builder.Services.AddTransient<CreatePinPageModel>();
        builder.Services.AddTransient<SetupBiometricsPageModel>();

        builder.Services.AddTransient<HomePageModel>();
        builder.Services.AddTransient<WhishlistPageModel>();
        builder.Services.AddTransient<SpecialOffersPageModel>();
        builder.Services.AddTransient<NotificationsPageModel>();

        builder.Services.AddTransient<ProductsDetailsPageModel>();
        builder.Services.AddTransient<SearchPageModel>();
        builder.Services.AddTransient<FilterPopupPageModel>();

        builder.Services.AddTransient<SearchPageModel>();

        builder.Services.AddTransient<CartPageModel>();

        builder.Services.AddTransient<OrdersPageModel>();
        
        builder.Services.AddTransient<WalletPageModel>();
        
        builder.Services.AddTransient<ProfilePageModel>();
        
        
        // Pages
        builder.Services.AddTransient<ControlGalleryPage>();
		builder.Services.AddTransient<WelcomePage>();
		builder.Services.AddTransient<WalkthroughPage>();
		builder.Services.AddTransient<LoginStartPage>();
		builder.Services.AddTransient<SignUpPage>();
		builder.Services.AddTransient<SignInPage>();
		builder.Services.AddTransient<ForgotPasswordMethodPage>();
		builder.Services.AddTransient<ForgotPasswordEnterCodePage>();
		builder.Services.AddTransient<ForgotPasswordCreateNewPasswordPage>();

        builder.Services.AddTransient<FillProfilePage>();
        builder.Services.AddTransient<CreatePinPage>();
        builder.Services.AddTransient<SetupBiometricsPage>();

        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<WhishlistPage>();
        builder.Services.AddTransient<SpecialOffersPage>();
        builder.Services.AddTransient<NotificationsPage>();
        
        builder.Services.AddTransient<ProductsDetailsPage>();
        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<FilterPopupPage>();

        builder.Services.AddTransient<SearchPage>();

        builder.Services.AddTransient<CartPage>();

        builder.Services.AddTransient<OrdersPage>();
        
        builder.Services.AddTransient<WalletPage>();
        
        builder.Services.AddTransient<ProfilePage>();

        builder.Services.AddSingleton<IProductService, RandomProductService>();

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

