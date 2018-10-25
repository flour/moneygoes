using System;
using System.Linq;
using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using moneygoes.Models;
using moneygoes.Models.AppModel;
using moneygoes.Services;

namespace moneygoes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            // if (env.IsDevelopment())
            // {
            //     // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
            //     builder.AddUserSecrets<Startup>();
            // }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var mongoSettings = GetMongoConnection();
            services.AddSingleton(new Services.MongoRepository(mongoSettings));
            services.AddIdentityMongoDbProvider<AppUser, AppRole>(options =>
                {
                    options.ConnectionString = mongoSettings.ConnectionString;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSpaStaticFiles();            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private MongoConnection GetMongoConnection()
        {
            var settings = new MongoConnection();
            settings.ConnectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
            if (string.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                var userStorageKey = "UserStorage";
                var mongoSettings = Configuration.GetSection(userStorageKey);

                if (mongoSettings != null && mongoSettings.GetChildren().Count() > 0)
                {
                    settings.ConnectionString = mongoSettings.GetValue<string>("ConnectionString");
                }
                else
                {
                    settings.ConnectionString = "mongodb://localhost:27017/";
                }

            }
            settings.DatabaseName = settings.ConnectionString.Split('/').LastOrDefault();
            return settings;
        }
    }
}
