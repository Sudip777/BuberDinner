using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var value = new { error = "An error occured while processing your request" }

        context.Result = new ObjectResult (value)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;

    }
}       