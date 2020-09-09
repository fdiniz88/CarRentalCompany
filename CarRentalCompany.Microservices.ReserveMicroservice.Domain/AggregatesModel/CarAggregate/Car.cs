using System;

namespace CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid ReserveHolderId { get; set; }    
        public string Description { get; set; }        
    }
}
