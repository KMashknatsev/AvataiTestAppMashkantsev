using AvataiTestAppMashkantsev.Core.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace AvataiTestAppMashkantsev.Core.ViewModel;

public partial class FormViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;

    public FormViewModel(ILogger<FormViewModel> logger, ICrashReportService reportService, IDialogService dialogService)
        : base(logger, reportService)
    {
        LogInformation("FormViewModel initialized");
        _dialogService = dialogService;
    }

    private string _name;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string _email;

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    private string _message;

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }

    private bool _isBusy;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
                SubmitCommand.NotifyCanExecuteChanged();
        }
    }

    [RelayCommand(CanExecute = nameof(CanSubmit))]
    private async Task SubmitAsync()
    {
        if (IsBusy) return;

        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
        {
            await _dialogService.ShowAlert("Ошибка", "Имя и Email обязательны", "Ок");
            return;
        }

        try
        {
            IsBusy = true;
            await Task.Delay(1500);

            var request = new NotificationRequest
            {
                NotificationId = 1001,
                Title = "Успешно!",
                Description = "Форма успешно отправлена",
                ReturningData = "FormSubmitted",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };

            Name = string.Empty;
            Email = string.Empty;
            Message = string.Empty;

            await LocalNotificationCenter.Current.Show(request);

            await _dialogService.ShowAlert("Успешно", "Форма успешно отправлена", "OK");
        }
        catch (Exception ex)
        {
            Log(ex, "Ошибка при отправке формы");
            await _dialogService.ShowAlert("Ошибка", "Не удалось отправить", "Ок");
        }
        finally
        {
            IsBusy = false;
        }
    }

    public bool CanSubmit() => !IsBusy;
}