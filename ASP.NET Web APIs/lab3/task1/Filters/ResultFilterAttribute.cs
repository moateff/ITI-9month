using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace task1.Filters;

public class ResultFilterAttribute : Attribute, IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ResultFilterAttribute>>();

        logger.LogInformation("Before sending response");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ResultFilterAttribute>>();

        logger.LogInformation("After sending response");
    }
}