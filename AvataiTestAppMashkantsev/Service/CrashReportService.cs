using AvataiTestAppMashkantsev.Core.Infastructure;
using AvataiTestAppMashkantsev.Core.Services;
using Microsoft.Extensions.Logging;

namespace AvataiTestAppMashkantsev.Service;

public class CrashReportService : ICrashReportService
{
    public void SendError(Exception ex, string message = null)
    {
        var logger = CustomServiceProvider.GetService<ILogger<CrashReportService>>();
        logger.LogCritical(ex, message);
    }

    public void SendError(ILogger logger, Exception ex, string message = null)
    {
        logger.LogError(ex, message);
    }
}