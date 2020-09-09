using System;
using CarRentalCompany.Common.Infra.DataAccess;
using CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate;

namespace CarRentalCompany.Microservices.CarMicroservice.Infra.DataAccess.Model
{
   public class CarRepository : EntityFrameworkRepositoryBase<Guid, Car>, ICarRepository
    {
    }
}
