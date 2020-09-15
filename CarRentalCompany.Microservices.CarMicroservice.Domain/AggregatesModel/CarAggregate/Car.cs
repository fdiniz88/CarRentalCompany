using CarRentalCompany.Common.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate
{
    public class Car : EntityBase<Guid>
    {

        [ForeignKey("CarModelId")]
        public Guid CarModelId { get; set; }
        //public virtual CarModel Model { get; set; }
        public bool Reserved { get; set; }
        public string Description { get; set; }        
    }
}
