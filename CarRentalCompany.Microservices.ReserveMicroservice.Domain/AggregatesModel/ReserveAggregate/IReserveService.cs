using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    public interface IReserveService
    {
        Task<bool> CarReserveAsync(Guid CarId, MoneyValue MoneyValue, DateTime RentalDate, DateTime DevolutionDate);
        Task<IEnumerable<Reserve>> GetCarStatement(Guid CarId);
    }
}
