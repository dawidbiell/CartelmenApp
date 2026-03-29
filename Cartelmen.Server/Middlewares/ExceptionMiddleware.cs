using System.Net;
using System.Text.Json;
using Cartelmen.Application.Errors;

namespace Cartelmen.Server.Middlewares;

public class ExceptionMiddleware(
    RequestDelegate next,
    ILogger<ExceptionMiddleware> logger,
    IHostEnvironment environment)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, "{EMessage}", e.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = environment.IsDevelopment()
                ? new ApiException(HttpStatusCode.InternalServerError, e.Message, e.StackTrace)
                : new ApiException(HttpStatusCode.InternalServerError, e.Message, "Internal server error");
            
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
                  var json = JsonSerializer.Serialize(response, jsonOptions);
            await context.Response.WriteAsync(json);
        }
    }
}