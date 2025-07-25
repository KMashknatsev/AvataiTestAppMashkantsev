using AvataiTestAppMashkantsev.Core.Services;

namespace AvataiTestAppMashkantsev.Service;

public class NavigationService : INavigationService
{
    public Task NavigateToAsync(string route, IDictionary<string, object> parameters = null)
    {
        return Shell.Current.GoToAsync(route, true, parameters);
    }
}