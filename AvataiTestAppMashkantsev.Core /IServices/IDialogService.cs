namespace AvataiTestAppMashkantsev.Core.Services;

public interface IDialogService
{
    Task ShowAlert(string title, string message, string cancel);
}