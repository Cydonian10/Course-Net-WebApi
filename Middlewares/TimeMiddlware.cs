
namespace webapi.Middlewares
{
    public class TimeMiddlware
    {
        readonly RequestDelegate next;

        public TimeMiddlware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke( HttpContext context)
        {
            await next(context);

            if( context.Request.Query.Any( p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
        }
    }

    public static class TimeMiddlwareExtension
    {
        public static IApplicationBuilder UseTimeMiddlware( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddlware>();
        }
    }
}