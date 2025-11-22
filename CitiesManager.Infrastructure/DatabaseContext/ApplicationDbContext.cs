using CitiesManager.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;

namespace CitiesManager.WebAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext() { }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData( 
                new City() 
                { 
                    CityID = Guid.Parse("D7E0E58F-EF66-46EA-A858-93DCD06EA6FF"),
                    CityName = "Kuala Lumpur"
                });

            modelBuilder.Entity<City>().HasData(
                new City() 
                { 
                    CityID = Guid.Parse("73CEA91A-61D4-46AA-A326-8A0DE3B0C0DC"), 
                    CityName = "Ipoh" 
                });

        }

    }
}
