using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvataiTestAppMashkantsev.Core.Infastructure;
using AvataiTestAppMashkantsev.Core.Services;
using Microsoft.Extensions.Logging;

namespace AvataiTestAppMashkantsev.Core.ViewModel;

public abstract class LightweightBaseViewModel : INotifyPropertyChanged
{
    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "",
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);

        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;

        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public abstract class BaseViewModel : LightweightBaseViewModel
{
    private string _backButtonText = "Back";
    private readonly ILogger _logger;
    private readonly ICrashReportService _crashReportService;

    public BaseViewModel(ILogger logger, ICrashReportService crashReportService)
    {
        _crashReportService = crashReportService;
        _logger = logger;

        LogInformation($"Initializing");
    }

    protected void SendEvent(string message)
    {
        _logger.LogInformation(message);
    }

    protected void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    protected void Log(Exception ex, string message = null)
    {
        _crashReportService.SendError(_logger, ex, message);
    }
}