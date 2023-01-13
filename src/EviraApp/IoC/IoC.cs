namespace Evira.App;

public static class IoC
{
    public static T GetService<T>() => Current.GetService<T>();

    public static IServiceProvider Current =>
#if ANDROID
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#endif
}