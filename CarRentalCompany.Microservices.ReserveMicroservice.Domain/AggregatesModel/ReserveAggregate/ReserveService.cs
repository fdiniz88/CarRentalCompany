using CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    /// <summary>
    /// Servicos de dominio
    /// </summary>
    public class ReserveService : IReserveService
    {
        private IReserveRepository ReserveRepository;

        public ReserveService(IReserveRepository ReserveRepository)
        {
            this.ReserveRepository = ReserveRepository;
        }

        //Servicos de Dominio
        public async Task<IEnumerable<Reserve>> GetCarStatement(Guid CarId)
        {
            var statement = new List<Reserve>();
         
            Reserve Reserve = new Reserve();            
            Reserve.Id = Guid.NewGuid();

            var action = new CarAction();
            action.CarId = CarId;
            action.RentalDate = DateTime.Now.AddDays(5);
            action.DevolutionDate = DateTime.Now.AddDays(10);
            action.ActionType = CarActionType.Tour;
            action.MoneyValue = new MoneyValue(1000, "BRL");

            Reserve.AddAction(action);
            statement.Add(Reserve);

            return statement;
        }

        public async Task<bool> CarReserveAsync(Guid CarId, MoneyValue MoneyValue, DateTime RentalDate, DateTime DevolutionDate)
        {
            Reserve Reserve = new Reserve();            
            Reserve.Id = Guid.NewGuid();

            var action = new CarAction();
            action.CarId = CarId;
            action.ActionType = CarActionType.Job;
            action.RentalDate = RentalDate;
            action.DevolutionDate = DevolutionDate;
            action.MoneyValue = MoneyValue;

            Reserve.AddAction(action);

            await ReserveRepository.CreateAsync(Reserve);
            return await ReserveRepository.SaveChangesAsync() > 0;
        }

    }
}
