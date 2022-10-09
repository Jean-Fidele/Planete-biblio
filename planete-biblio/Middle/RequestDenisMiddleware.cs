using planete_biblio.IntefaceMethode;
using System.Globalization;

namespace planete_biblio.Middle
{
    public class RequestDenisMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestDenisMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, Fidele fidy)
        {
            Console.WriteLine($"Data : {fidy.ToString()}");
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
    public static class RequestDenisMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestDenis(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestDenisMiddleware>();
        }
    }
}
