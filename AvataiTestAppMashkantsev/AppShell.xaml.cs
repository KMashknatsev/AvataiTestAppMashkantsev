using AvataiTestAppMashkantsev.View;
using Plugin.LocalNotification;

namespace AvataiTestAppMashkantsev;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await LocalNotificationCenter.Current.RequestNotificationPermission();
    }
}