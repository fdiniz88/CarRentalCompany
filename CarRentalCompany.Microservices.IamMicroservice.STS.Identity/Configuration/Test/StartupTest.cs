using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.Shared.DbContexts;
using CarRentalCompany.Microservices.IamMicroservice.STS.Identity.Helpers;

namespace CarRentalCompany.Microservices.IamMicroservice.STS.Identity.Configuration.Test
{
    public class StartupTest : Startup
    {
        public StartupTest(IWebHostEnvironment environment, IConfiguration configuration) : base(environment, configuration)
        {
        }

        public override void RegisterDbContexts(IServiceCollection services)
        {
            services.RegisterDbContextsStaging<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, IdentityServerDataProtectionDbContext>();
        }
    }
}





