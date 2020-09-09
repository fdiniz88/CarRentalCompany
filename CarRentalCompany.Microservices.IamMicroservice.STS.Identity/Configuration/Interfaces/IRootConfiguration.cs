using CarRentalCompany.Microservices.IamMicroservice.Shared.Configuration.Identity;

namespace CarRentalCompany.Microservices.IamMicroservice.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}





