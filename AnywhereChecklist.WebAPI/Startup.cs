using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Web.Helpers.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCore.Jwt;

namespace AnywhereChecklist.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowAnyOrigin()
                               .AllowCredentials();
                    }));    

            services
                .AddSwaggerDocument()
                .AddSignalR();

            services.AddAccess(Configuration, requireIdentity: true)
                    .AddBusiness()
                    .AddHelpers();

            services.AddAuthentication(c => {
                c.DefaultAuthenticateScheme = NetCoreJwtDefaults.SchemeName;
                Console.WriteLine("challenge: " + c.DefaultChallengeScheme);
                c.DefaultChallengeScheme = NetCoreJwtDefaults.SchemeName;
            })
                    .AddNetCoreJwt(o => {
                        o.Secret = Configuration["secret"];
                    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.Use(async (context, next) => {
                await next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
               .UseSwaggerUi3();

            app.UseCors("CorsPolicy");
            //app.UseAuthentication();

            app.UseSignalR(c => {
                //c.MapHub<DataUpdatesHub>("/dataUpdates");
                c.MapHub<OtherHub>("/others");
            });
            app.UseMvc();
        }
    }
}
