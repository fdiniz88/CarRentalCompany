using CarRentalCompany.Microservices.IamMicroservice.Shared.Configuration.Identity;
using CarRentalCompany.Microservices.IamMicroservice.STS.Identity.Configuration.Interfaces;

namespace CarRentalCompany.Microservices.IamMicroservice.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





