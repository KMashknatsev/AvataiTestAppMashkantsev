using AvataiTestAppMashkantsev.Core.Services;

namespace AvataiTestAppMashkantsev.Service;

public class DialogService : IDialogService
{
    public Task ShowAlert(string title, string message, string cancel)
    {
        return Shell.Current.DisplayAlert(title, message, cancel);
    }
}