using CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRentalCompany.Microservices.CarMicroservice.Infra.DataAccess.Contexts
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarModel> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Car>(c =>
            //{
            //    c.ToTable("Cars");
            //    c.HasKey(c => c.Id).HasName("Id");
            //    c.Property(c => c.Id).HasColumnName("Id").HasMaxLength(450)
            //     .HasConversion(
            //     Id => Id.ToString(),
            //     Id => Guid.Parse(Id))
            //    .HasColumnName("Id");
            //    c.Property(c => c.ModelId).HasColumnName("ModelId").HasMaxLength(450)
            //    .HasConversion(
            //     ModelId => ModelId.ToString(),
            //     ModelId => Guid.Parse(ModelId))
            //    .HasColumnName("ModelId");
            //    c.Property(c => c.Reserved).HasColumnName("Reserved");

            //});


            //modelBuilder.Entity<CarModel>(c =>
            //{
            //    c.ToTable("Models");
            //    c.HasKey(c => c.Id).HasName("Id");
            //    c.Property(c => c.Id).HasColumnName("Id").HasMaxLength(450)
            //     .HasConversion(
            //     Id => Id.ToString(),
            //     Id => Guid.Parse(Id))
            //    .HasColumnName("Id");
            //    c.Property(c => c.Description).HasColumnName("Description").HasMaxLength(450);
            //});

        }
    }
}
