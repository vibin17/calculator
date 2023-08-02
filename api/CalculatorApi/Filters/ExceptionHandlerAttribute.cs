using Expressions.Exceptions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace CalculatorApi.Filters;

public class ExceptionHandlerAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is IllegalInputException illegalInputException)
        {
            context.Result = new ObjectResult(new { ErrorMessage = illegalInputException.Message })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };

            return;
        }

        context.Result = new ObjectResult(new { ErrorMessage = "Processing error" })
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}