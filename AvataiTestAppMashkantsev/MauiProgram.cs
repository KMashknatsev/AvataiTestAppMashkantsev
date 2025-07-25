using AvataiTestAppMashkantsev.Core.Services;
using AvataiTestAppMashkantsev.Core.ViewModel;
using AvataiTestAppMashkantsev.Service;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Plugin.LocalNotification;

namespace AvataiTestAppMashkantsev;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>().RegisterViewModels().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiCommunityToolkit()
            .UseLocalNotification()
            .RegisterViewModels()
            .RegisterAppServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<ListViewModel>();
        mauiAppBuilder.Services.AddTransient<WebViewModel>();
        mauiAppBuilder.Services.AddTransient<DetailsViewModel>();
        mauiAppBuilder.Services.AddTransient<FormViewModel>();
        
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ICrashReportService, CrashReportService>();
        mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
        mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
    
        return mauiAppBuilder;
    }
}