using Expressions.Exceptions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace CalculatorApi.Filters;

public class InvalidInputExceptionAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is InvalidInputException invalidInputException)
            context.Result = new ObjectResult(new { ErrorMessage = invalidInputException.Message })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
    }
}