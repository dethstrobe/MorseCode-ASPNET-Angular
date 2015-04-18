using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Security.Cookies;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.SqlServer;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using WebApp.Models;

namespace WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {

            var mono = Type.GetType("Mono.Runtime") != null;
            // Add EF services to the services container if not using Mono
            // consider using Azure SQL or non local store for xplat until EF7 has full ASP.NET 5 support
            if (!mono)
            {
                services.AddEntityFramework(Configuration)
                        .AddInMemoryStore()
                        .AddDbContext<MorseCodeContext>();
            }

            // Add Identity services to the services container.
            services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
                .AddEntityFrameworkStores<MorseCodeContext>();

            // Add MVC services to the services container.
            services.AddMvc();

            // Uncomment the following line to add Web API servcies which makes it easier to port Web API 2 controllers.
            // You need to add Microsoft.AspNet.Mvc.WebApiCompatShim package to project.json
            // services.AddWebApiConventions();

        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerfactory.AddConsole();

            // Add the following to the request pipeline only in development environment.
            if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });
        }

        private static async Task CreateSampleData(IServiceProvider applicationService)
        {
            using (var dbContext = applicationService.GetService<MorseCodeContext>())
            {
                var sqlServerDatabase = dbContext.Database as SqlServerDatabase;
                if (sqlServerDatabase != null)
                {
                    sqlServerDatabase.EnsureCreatedAsync().Wait();
                }
    
                // add some movies
                var morse = new List<Morse> {
                    new Morse {id=1, name="Billy", gender="male"},
                    new Morse {id=2, name="Joe", gender="male"},
                    new Morse {id=3, name="Sue", gender="female"},
                    new Morse {id=4, name="Lara", gender="female"}
                };
                morse.ForEach(m => dbContext.Morse.AddAsync(m));
            }
        }
    }
}
