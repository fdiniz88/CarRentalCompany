
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Infra.Contexts
{
   public class ReserveContext : DbContext
    {
        public DbSet<Domain.AggregatesModel.ReserveAggregate.Reserve> Reserves { get; set; }

        public ReserveContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //  optionsBuilder.UseSqlServer("");  CarRentalCompany-fernando-db
        }
    }
}
