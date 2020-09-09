using System;
using CarRentalCompany.Common.Infra.DataAccess;
using CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Infra.Repositories
{
   public class ReserveRepository : EntityFrameworkRepositoryBase<Guid, Reserve>, IReserveRepository
    {
    }
}
