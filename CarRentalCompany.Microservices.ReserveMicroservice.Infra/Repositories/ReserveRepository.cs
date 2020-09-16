using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalCompany.Common.Infra.DataAccess;
using CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate;
using CarRentalCompany.Microservices.ReserveMicroservice.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Infra.Repositories
{
   public class ReserveRepository : EntityFrameworkRepositoryBase<Guid, Reserve>, IReserveRepository
    {        
        private readonly DbContext _DbContext;

        public ReserveRepository(DbContext DbContext)//, ReserveContext ReserveContext)
      : base(db: DbContext)
        {
        }    
    }
}
