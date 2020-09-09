using CarRentalCompany.Common.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate
{
    public interface ICarService
    {        
        Task<IEnumerable<Car>> Getcars();
        Task<Car> Getcar(Guid id);
        Task<ReturnResult> PutCar(Guid id, Car car);
        Task<ReturnResult> PostCar(Car car);
        Task<ReturnResult> DeleteCar(Guid id);
    }
}
