using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace task1.Filters;

public class ExceptionFilterAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var response = new
        {
            message = "Internal Server Error - Exception Filter",
            details = context.Exception.Message
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}