using System.Diagnostics;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    public LoggingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        Debug.WriteLine($"> Request: {context.Request.Method} {context.Request.Path}");
        context.Response.OnStarting(() =>
        {
            Debug.WriteLine($"< Response: {context.Response.StatusCode}");
            return Task.CompletedTask;
        });

        await _next(context);
    }
}