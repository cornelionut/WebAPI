using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI
{
    public class Startup
    {
        //Configuration object is injected and allows accesing configuration settings from appsettings.json 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Configure Services is used to add services to the built in dependency injection container and to configure those services
        //A service is a component that is intended for common consumption in an app
        //So the services we add here can later be injected into other pieces of code that live in our application.

        public void ConfigureServices(IServiceCollection services)
        {
            //AddControllers only registers those services that are typically required when building APIs like support for controllers, model binding, data annotations and formatters.
            services.AddControllers();

            //Repository is registered to the container
            services.AddScoped<IOfferListRepository, OfferListRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            //Create dependency injection for DB Context class and ConnectionString is defined in appsettings.json
            services.AddDbContext<LeasingDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("Leasing_DbConnection")));

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Configure method uses services that are registered and configured in the Configure services 
        // Configure method is used to specify how an ASP.NET application will respond to individual HTTP request.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>                          //ofera accesul React la resursele ASP
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization(); // When is not configured in Configure Services will still allow anonymous acces

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
