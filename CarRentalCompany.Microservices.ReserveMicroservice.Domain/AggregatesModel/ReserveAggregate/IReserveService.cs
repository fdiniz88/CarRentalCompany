using CarRentalCompany.Common.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    public interface IReserveService
    {       
        Task<IEnumerable<Reserve>> GetCarStatement(Guid CarId);
        Task<IEnumerable<Reserve>> GetReserves();
        Task<Reserve> GetReserve(Guid id);
        Task<ReturnResult> PutReserve(Guid id, Reserve reserve);
        Task<ReturnResult> PostReserve(Reserve reserve);
        Task<ReturnResult> DeleteReserve(Guid id);        
    }
}
