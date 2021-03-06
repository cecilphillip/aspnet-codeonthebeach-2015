using System;
using Demos.Config;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Demos.Middleware
{
    public static class BlacklistMiddlewareExtensions
    {
        public static void ConfigureBlacklist(this IServiceCollection sevices, Action<BlacklistOptions> options)
        {
            sevices.Configure(options);
        }

        public static IApplicationBuilder UseBlacklist(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BlacklistMiddleware>();
        }
    }
}