using AvataiTestAppMashkantsev.Core.ViewModel;

namespace AvataiTestAppMashkantsev.View;

public partial class WebPage : ContentPage
{
    public WebPage(WebViewModel webViewModel)
    {
        InitializeComponent();
        BindingContext = webViewModel;
        MainWebView.Navigating += (s, e) => webViewModel.IsBusy = true;
        MainWebView.Navigated += (s, e) => webViewModel.IsBusy = false;

        VideoWebView.Navigating += (s, e) => webViewModel.IsBusy = true;
        VideoWebView.Navigated += (s, e) => webViewModel.IsBusy = false;
    }
}