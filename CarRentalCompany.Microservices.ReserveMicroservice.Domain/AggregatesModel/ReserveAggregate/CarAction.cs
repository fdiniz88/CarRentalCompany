
using System;


namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    public class CarAction
    {
        public Guid CarId { get; set; }
        public string Description { get; set; }
        public CarActionType ActionType { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DevolutionDate { get; set; }
        public MoneyValue MoneyValue { get; set; }
    }
}
