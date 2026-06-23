using Castle.DynamicProxy;
using System.Diagnostics;
using System.Text.Json;

namespace task1.Interceptors;

public class LoggingInterceptor : IInterceptor
{
    private readonly ILogger<LoggingInterceptor> _logger;

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        _logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
        var sw = Stopwatch.StartNew();

        _logger.LogInformation(
            "{Method} Parameters: {Params}",
            invocation.Method.Name,
            JsonSerializer.Serialize(invocation.Arguments));

        invocation.Proceed();

        sw.Stop();

        _logger.LogInformation(
            "{Method} Return Value: {Result}",
            invocation.Method.Name,
            invocation.ReturnValue);

        _logger.LogInformation(
            "{Method} Execution Time: {Time} ms",
            invocation.Method.Name,
            sw.ElapsedMilliseconds);
    }
}