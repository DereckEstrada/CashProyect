using System.Security.Claims;
using Cash.BE.Dtos;
using Cash.BE.Helpers;

namespace Cash.API.Middlewares;

public class ErrorMiddleware(ILogger<ErrorMiddleware> logger) : IMiddleware
{
    private readonly ILogger<ErrorMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BadHttpRequestException ex)
        {
        }
        catch (Exception e)
        {
            ApiResponse<string> errorResponse = new ApiResponse<string>
            {
                StatusCode = StatusCode.InternalServerError,
                Message = e.Message,
            };
            _logger.LogError("{Method} {Path} {NameIdentifier} {Message}", context.Request.Method, context.Request.Path, context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? ErrorMessage.NoIdentificated, e.InnerException?.Message ?? e.Message);
           
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            await context.Response.WriteAsJsonAsync(errorResponse);
        }

    }
}