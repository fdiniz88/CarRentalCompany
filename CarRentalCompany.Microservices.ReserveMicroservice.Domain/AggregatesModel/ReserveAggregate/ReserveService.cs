using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CarRentalCompany.Common.Domain.DTO;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    /// <summary>
    /// Servicos de dominio
    /// </summary>
    public class ReserveService : IReserveService
    {
        private IReserveRepository _ReserveRepository;

        public ReserveService(IReserveRepository ReserveRepository)
        {
            _ReserveRepository = ReserveRepository;
        }

        //Servicos de Dominio
        public async Task<IEnumerable<Reserve>> GetCarStatement(Guid CarId)
        {
            return await _ReserveRepository.ReadAllAsync();
        }

        public async Task<bool> CarReserveAsync(Guid CarId, MoneyValue MoneyValue, DateTime RentalDate, DateTime DevolutionDate)
        {
            Reserve Reserve = new Reserve();
            Reserve.Id = Guid.NewGuid();

            var reserve = new Reserve();
            reserve.CarId = CarId;
            reserve.ActionType = CarType.Job;
            reserve.RentalDate = RentalDate;
            reserve.DevolutionDate = DevolutionDate;
            reserve.Value = MoneyValue;

            await _ReserveRepository.CreateAsync(Reserve);
            return await _ReserveRepository.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Reserve>> GetReserves()
        {            

            return await _ReserveRepository.ReadAllAsync();
        }

        public async Task<Reserve> GetReserve(Guid id)
        {
            return await _ReserveRepository.ReadAsync(id);
        }

        public Task<ReturnResult> PutReserve(Guid id, Reserve reserve)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnResult> PostReserve(Reserve reserve)
        {      
            await _ReserveRepository.CreateAsync(reserve);
            await _ReserveRepository.SaveChangesAsync();
            ReturnResult ReturnResult = new ReturnResult();
            ReturnResult.Action = "Reserva criada com sucesso!!!";
            return ReturnResult;
        }

        public Task<ReturnResult> DeleteReserve(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<ReturnResult> IReserveService.PutReserve(Guid id, Reserve reserve)
        {
            throw new NotImplementedException();
        }           
    }

}
