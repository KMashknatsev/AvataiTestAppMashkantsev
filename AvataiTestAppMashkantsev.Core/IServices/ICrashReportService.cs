using AvataiTestAppMashkantsev.Core.Infastructure;
using Microsoft.Extensions.Logging;

namespace AvataiTestAppMashkantsev.Core.Services;

public interface ICrashReportService
{
    void SendError(ILogger logger, Exception ex, string message = null);

    void SendError(Exception ex, string message = null);
}