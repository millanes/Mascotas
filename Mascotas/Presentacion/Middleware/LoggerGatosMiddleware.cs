
using Microsoft.AspNetCore.Http.Extensions;

namespace Mascotas.Middleware
{
    public class LoggerGatosMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggerGatosMiddleware> logger;
        public LoggerGatosMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<LoggerGatosMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            this.logger.LogInformation($"Method: {context.Request.Method}, URL: {context.Request.GetDisplayUrl()}");
            await this.next.Invoke(context);
            this.logger.LogInformation($"Status Code: {context.Response.StatusCode}, Content-Type: {context.Response.ContentType}");
        }
    }
}
