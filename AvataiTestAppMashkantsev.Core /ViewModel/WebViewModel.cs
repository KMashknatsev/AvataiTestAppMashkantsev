using System.Net.NetworkInformation;
using AvataiTestAppMashkantsev.Core.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace AvataiTestAppMashkantsev.Core.ViewModel;

public partial class WebViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;

    public WebViewModel(ILogger<WebViewModel> logger, ICrashReportService reportService, IDialogService dialogService) :
        base(logger, reportService)
    {
        LogInformation("WebViewModel initialized");

        _dialogService = dialogService;

        MainLabel = new Uri(AppConstants.AvataiMainUrl).Host;
        VideoLabel = new Uri(AppConstants.AvataiVideoUrl).Host;

        IsMainActive = true;
        IsVideoActive = false;
    }

    private string _mainUrl = AppConstants.AvataiMainUrl;
    private string _videoUrl = AppConstants.AvataiVideoUrl;

    private bool _isMainActive;
    private bool _isVideoActive;

    private string _mainLabel;
    private string _videoLabel;


    public bool IsMainActive
    {
        get => _isMainActive;
        set => SetProperty(ref _isMainActive, value);
    }

    public bool IsVideoActive
    {
        get => _isVideoActive;
        set => SetProperty(ref _isVideoActive, value);
    }

    public string MainUrl
    {
        get => _mainUrl;
        set => SetProperty(ref _mainUrl, value);
    }

    public string VideoUrl
    {
        get => _videoUrl;
        set => SetProperty(ref _videoLabel, value);
    }
    
    public string MainLabel
    {
        get => _mainLabel;
        set => SetProperty(ref _mainLabel, value);
    }

    public string VideoLabel
    {
        get => _videoLabel;
        set => SetProperty(ref _videoLabel, value);
    }

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }
    
    [RelayCommand]
    private async Task ShowMainSite()
    {
        await TrySwitchAsync(true);
    }

    [RelayCommand]
    private async Task ShowVideoSite()
    {
        await TrySwitchAsync(false);
    }

    private async Task TrySwitchAsync(bool showMain)
    {
        if (!IsInternetAvailable())
        {
            LogInformation("No internet connection.");
            await ShowAlert("Ошибка", "Нет подключения к интернету", "OK");
            return;
        }

        IsMainActive = showMain;
        IsVideoActive = !showMain;
    }

    private bool IsInternetAvailable()
    {
        return NetworkInterface.GetIsNetworkAvailable();
    }

    private Task ShowAlert(string title, string message, string cancel)
    {
        return _dialogService.ShowAlert(title, message, cancel);
    }
}