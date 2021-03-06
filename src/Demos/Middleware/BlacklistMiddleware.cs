﻿using System.Net;
using System.Threading.Tasks;
using Demos.Config;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Microsoft.Extensions.OptionsModel;

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
            //not supported by kestrel in rc1
            IHttpConnectionFeature connection = context.Features.Get<IHttpConnectionFeature>();
            var ipAddress = connection?.RemoteIpAddress.ToString();

            if (_options.Value.IpAddresses.Contains(ipAddress))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("You Shall Not Pass!!");
            }

            return _next(context);
        }
    }
}
