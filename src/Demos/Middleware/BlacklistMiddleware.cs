using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Microsoft.Framework.OptionsModel;

namespace Demos.Middleware
{
    public class BlacklistMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<BlacklistOptions> _options;

        public BlacklistMiddleware(RequestDelegate next, IOptions<BlacklistOptions> options)
        {
            _next = next;
            _options = options;
        }

        public Task Invoke(HttpContext context)
        {
            IHttpConnectionFeature connection = context.GetFeature<IHttpConnectionFeature>();
            var ipAddress = connection.RemoteIpAddress.ToString();

            if (!connection.IsLocal && !_options.Options.IpAddresses.Contains(ipAddress))
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("You Shall Not Pass!!");
            }

            return _next(context);
        }
    }
}
