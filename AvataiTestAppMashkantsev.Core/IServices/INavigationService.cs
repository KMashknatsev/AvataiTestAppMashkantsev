namespace AvataiTestAppMashkantsev.Core.Services;

public interface INavigationService
{
    Task NavigateToAsync(string route, IDictionary<string, object> parameters = null);
}