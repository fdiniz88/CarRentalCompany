using System;
using System.Collections.Generic;

namespace CarRentalCompany.App.Application.Models.ViewModels.ReserveAggregate
{
    public class ReserveViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<CarActionViewModel> Action { get; set; }
    }
}
