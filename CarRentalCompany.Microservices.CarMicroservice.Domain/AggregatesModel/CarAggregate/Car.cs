using CarRentalCompany.Common.Domain.Entities;
using System;

namespace CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate
{
    public class Car : EntityBase<Guid>
    {
        public Guid CarId { get; set; }
        public Guid ReserveHolderId { get; set; }
        public string Description { get; set; }        
    }
}
