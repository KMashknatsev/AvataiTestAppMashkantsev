namespace AvataiTestAppMashkantsev.Core.Infastructure;

public static class CustomServiceProvider
{
    public static TService GetService<TService>()
        => Current.GetService<TService>();

    public static IServiceProvider Current
        =>
#if ANDROID
            MauiApplication.Current.Services;
#elif IOS
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
}