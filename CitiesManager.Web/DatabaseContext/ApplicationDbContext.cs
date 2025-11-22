using CitiesManager.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;

namespace CitiesManager.Web.DatabaseContext
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

            //Seed DB Table
            try
            {
                //string countiresJson = File.ReadAllText("countries.json");
                //List<Country> countries = JsonSerializer.Deserialize<List<Country>>(countiresJson);

                //foreach (Country country in countries)
                //    modelBuilder.Entity<Country>().HasData(country);

                //string personsJson = File.ReadAllText("persons.json");
                //List<Person> persons = JsonSerializer.Deserialize<List<Person>>(countiresJson);

                //foreach (Person peson in persons)
                //    modelBuilder.Entity<Country>().HasData(peson);
            }
            catch (Exception ex) { }

            //Fluent API
            try
            {
               
            }
            catch (Exception ex) { }

        }

    }
}
