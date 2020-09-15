using System;
using CarRentalCompany.Common.Domain.Interfaces.Repositories;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    public interface IReserveRepository : IRepository<Guid, Reserve>
    {
    }
}
