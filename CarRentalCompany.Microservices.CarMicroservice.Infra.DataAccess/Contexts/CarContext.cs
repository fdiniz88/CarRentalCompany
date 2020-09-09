using CarRentalCompany.Microservices.CarMicroservice.Infra.DataAccess.Model;
using CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCompany.Microservices.CarMicroservice.Infra.DataAccess.Contexts
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<DbMoneyValue> Moneys { get; set; }

        public CarContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
          //  optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Car>()
                .Property(account => account.Description)
                .HasColumnName("Description");

            //modelBuilder
            //    .Entity<DbMoneyValue>()
            //    .Property(dbMoney => dbMoney)
            //    //.HasConversion(
            //    //    value => value,
            //    //    currency => currency,
            //    //    money => new MoneyValue(value, currency))
            //    .HasColumnName("Money");
        }
    }
}
