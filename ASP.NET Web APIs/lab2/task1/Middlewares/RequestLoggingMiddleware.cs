using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace task1.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path;
        var method = context.Request.Method;

        _logger.LogInformation("[Request] {Method} {Path}", method, path);
        
        var stopwatch = Stopwatch.StartNew();

        await _next(context); 

        stopwatch.Stop();

        var statusCode = context.Response.StatusCode;
        var elapsedMs = stopwatch.ElapsedMilliseconds;

        _logger.LogInformation("[Response] {StatusCode} took {Elapsed} ms", statusCode, elapsedMs);
    }
}