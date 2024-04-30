using Microsoft.Extensions.Primitives;

namespace BankManagementSystem.Middlewares
{
    public class ApplicationKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApplicationKeyMiddleware> _logger;

        public ApplicationKeyMiddleware(RequestDelegate next, ILogger<ApplicationKeyMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //if (httpContext.Request.Headers.TryGetValue("AppKey", out StringValues key) && key.FirstOrDefault() == Program.AppKey)
            //{
                await _next(httpContext);
            //}
            //else
            //{
            //    httpContext.Response.StatusCode = 404;
            //}
        }
    }
}
