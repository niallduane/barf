using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;
using BarfSourceName.Domain.Core;


namespace BarfSourceName.Presentation.Api.Filters;

public class ExceptionHandlerFilter : IExceptionFilter
{
    public static Dictionary<int, Type[]> HandledExceptions = new()
    {
        { StatusCodes.Status400BadRequest, new[] { typeof(ArgumentException), typeof(ArgumentNullException) } },
        { StatusCodes.Status403Forbidden, new[] { typeof(UnauthorizedAccessException) } },
        // { StatusCodes.Status404NotFound, new[] { } },
        // { StatusCodes.Status422UnprocessableEntity, new[] { } },
        { 499, new[] { typeof(TaskCanceledException) } }
    };

    private readonly ILogger<ExceptionHandlerFilter> _logger;
    public ExceptionHandlerFilter(ILogger<ExceptionHandlerFilter> logger)
    {
        _logger = logger;
    }

    public void OnException([NotNull] ExceptionContext context)
    {
        var message = context.Exception?.Message ?? "Unhandled Error";
        var response = new ApiErrorResponse(500, new Error(message, Domain.Core.Types.ErrorTypes.Invalid));


#pragma warning disable CA2254
        _logger.LogError(context.Exception, context.Exception?.Message, Array.Empty<object>());
#pragma warning restore CA2254

        var type = context.Exception?.GetType();
        var statusCodeMapping = HandledExceptions.FirstOrDefault(exception => exception.Value.Contains(type));
        if (!statusCodeMapping.Equals(default))
        {
            response.Code = statusCodeMapping.Key;
        }

        context.Result = new JsonResult(response) { StatusCode = response.Code };
    }
}
