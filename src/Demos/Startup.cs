using System;
using Demos.Config;
using Demos.Middleware;
using Demos.Services;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace Demos
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConferenceSessionService, InMemorySessionService>();

            services.Configure<CustomConfigOptions>(Configuration.GetSection("Custom"));

            services.AddCaching();
            
            services.AddSession();
            services.ConfigureSession(o =>
            {              
                o.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            services.ConfigureBlacklist(op =>
            {
                //Add your black listed IPs
                op.IpAddresses.Add("127.0.0.1");
            });

            services.AddMvc();
        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();

            app.UseBlacklist();

            app.UseSession();
            
            app.UseCookieAuthentication(options =>
            {
                options.LoginPath = "/secured/login";
                options.AuthenticationScheme = "Cookies";
                options.CookieName = "cotb.demo";

                options.CookieHttpOnly = true;
                options.CookieSecure = CookieSecureOption.SameAsRequest;
                options.AutomaticAuthentication = true;
            });

            if (env.IsDevelopment())
            {
                app.UseErrorPage();
            }
            else
            {               
                app.UseErrorHandler( "/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });          
        }
    }
}
