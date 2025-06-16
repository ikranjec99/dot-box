using Microsoft.Extensions.Logging;

namespace DotBox.Core.Extensions;

public static class ILoggerExtensions
{
    public static void LogTest(this ILogger logger) => logger.LogInformation("Test");
}
