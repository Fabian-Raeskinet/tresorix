using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tresorix.Api.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public ApiExceptionFilterAttribute()
    {
        ExceptionHandlers = new Dictionary<Type, Action<ExceptionContext>?>
        {
            { typeof(ValidationException), HandleValidationException }
        };
    }

    public IDictionary<Type, Action<ExceptionContext>?> ExceptionHandlers { get; }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }

    public void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();
        if (!ExceptionHandlers.TryGetValue(type, out var value)) return;
        value?.Invoke(context);
    }

    public void HandleValidationException(ExceptionContext context)
    {
        if (context.Exception is not ValidationException exception) return;
        var errors = exception.Errors;

        context.Result = new BadRequestObjectResult(errors.Select(c => c.ErrorMessage));

        context.ExceptionHandled = true;
    }
}