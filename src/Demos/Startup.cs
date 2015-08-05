using Demos.Config;
using Demos.Middleware;
using Demos.Services;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RethinkDb.Newtonsoft.Converters;

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

            services.Configure<CustomConfigOptions>(Configuration.GetConfigurationSection("Custom"));

            services.ConfigureBlacklist(op =>
            {

            });

            services.AddMvc();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();

            app.UseBlacklist();

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
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
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
