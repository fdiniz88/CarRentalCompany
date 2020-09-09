using CarRentalCompany.Common.Domain.Interfaces.Repositories;
using System;

namespace CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate
{
    public interface ICarRepository : IRepository<Guid, Car>
    {
    }
}
