
using System;


namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    public class Car
    {
        public Guid Id { get; set; }
        //public Guid ReserveHolderId { get; set; }
        public bool Reserved { get; set; }
        public string Description { get; set; }
    }
}
