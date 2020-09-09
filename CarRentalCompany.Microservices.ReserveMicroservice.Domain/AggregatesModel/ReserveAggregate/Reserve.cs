using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalCompany.Common.Domain.Entities;
using CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    public class Reserve : EntityBase<Guid>
    {
        public ICollection<CarAction> Actions { get; set; }

        public Reserve()
        {
            Actions = new List<CarAction>();
        }

        public void AddAction(CarAction action)
        {
            Actions.Add(action);
        }
    }
}
