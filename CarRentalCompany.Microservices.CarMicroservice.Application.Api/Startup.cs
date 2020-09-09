using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate;
using CarRentalCompany.Microservices.CarMicroservice.Infra.DataAccess.Model;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarRentalCompany.Microservices.CarMicroservice.Application.Api
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
            services.AddControllers();
            services.AddAuthorization();

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarRepository,CarRepository>();

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //  .AddIdentityServerAuthentication(options =>
            //  {
            //      options.Authority = "https://CarRentalCompany-fernando-iam-microservice-identity.azurewebsites.net";
            //      options.RequireHttpsMetadata = false;
            //      options.ApiName = "CarMicroservice_ResourceApi";

            //  });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
