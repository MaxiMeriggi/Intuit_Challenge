using System.Net;
using System.Text.Json;

public sealed class ExceptionInterceptor
{
    private readonly RequestDelegate _next;

    public ExceptionInterceptor(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await WriteErrorAsync(context, ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    private static Task WriteErrorAsync(HttpContext context, string message, HttpStatusCode status)
    {
        var payload = new
        {
            status = (int)status,
            error = "Ocurrio un error al realizar el request. Detalle: " + message,
            traceId = context.TraceIdentifier
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(JsonSerializer.Serialize(payload));
    }
}