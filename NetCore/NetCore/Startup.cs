using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCore.Services;

namespace NetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //create IGreeter once for all requests by using Greeter Method
            services.AddSingleton<IGreeter, Greeter>();
            //create IRestaurantData for each incoming request and then throw it away
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env
                              ,IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
            }

            ////using func delegate to set up middleware
            ////method is executed once at startup
            //app.Use((next) =>
            //{
            //    //this is the actual middleware, which is executed with every incoming request
            //    return async context =>
            //    {
            //        logger.LogInformation("Request incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit!!");
            //            logger.LogInformation("Request handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response going out");
            //        }
            //    };
            //});

            //serve index.html
            //app.UseDefaultFiles();

            //Serve static files
            app.UseStaticFiles();

            ////alternative 
            //app.UseFileServer(); //installs Default Files and Static Files middleware

            //MVC middleware

            app.UseMvc(ConfigureRoutes);


            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessage();
                await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // Home/Index --> question mark defines optinoal parameter
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
