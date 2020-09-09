using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCompany.Common.Domain.DTO;

namespace CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate
{
    public class CarService : ICarService
    {
        private readonly ICarRepository CarRepository;

        public CarService(ICarRepository CarRepository)
        {
            this.CarRepository = CarRepository;
        }      
        public async Task<Car> Getcar(Guid id)
        {
            return await CarRepository.ReadAsync(id);
        }

        public async Task<IEnumerable<Car>> Getcars()
        {
            return await CarRepository.ReadAllAsync(); 
        }
        public async Task<ReturnResult> PostCar(Car car)
        {
            await CarRepository.CreateAsync(car);
            await CarRepository.SaveChangesAsync();
            ReturnResult ReturnResult = new ReturnResult();
            ReturnResult.Action = "Carro criado";
            return ReturnResult;
        }
        public async Task<ReturnResult> PutCar(Guid id, Car car)
        {
            ReturnResult ReturnResult = new ReturnResult();
            ReturnResult.Action = "Atualização de carro";

            Car Car = await CarRepository.ReadAsync(car.Id);

            if (Car == null)
            {
                ReturnResult.Inconsistencies.Add(
                    "Carro não encontrado");
            }
            else
            {
                Car.Description = car.Description;             

                CarRepository.Update(Car);
                await CarRepository.SaveChangesAsync();
            }
            return ReturnResult;
        }
        public async Task<ReturnResult> DeleteCar(Guid id)
        { 
            ReturnResult ReturnResult = new ReturnResult();
            ReturnResult.Action = "Delete car";

            Car Car = await CarRepository.ReadAsync(id);
            if (Car == null)
            {
                ReturnResult.Inconsistencies.Add(
                    "Carro não encontrado");
            }
            else
            {
                await CarRepository.DeleteAsync(id);
                await CarRepository.SaveChangesAsync();
            }
            return ReturnResult;
        }  
    }
}
