using System.Diagnostics;
using System.Text.Json;
using task1.Interfaces;

namespace task1.Decorators;

public class LoggingUserService : IUserService
{
    private readonly IUserService _inner;
    private readonly ILogger<LoggingUserService> _logger;

    public LoggingUserService(IUserService inner, ILogger<LoggingUserService> logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public string GetUser(int id)
    {
        var sw = Stopwatch.StartNew();

        _logger.LogInformation(
            "Method GetUser called with parameters: {Params}",
            JsonSerializer.Serialize(new { id }));

        var result = _inner.GetUser(id);

        sw.Stop();

        _logger.LogInformation(
            "Method GetUser returned: {Result}",
            result);

        _logger.LogInformation(
            "Execution Time: {Time} ms",
            sw.ElapsedMilliseconds);

        return result;
    }
}