
using EFApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSampleApp
{
    public class CinemaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbMovies17Apr2023");
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 101, Name = "Abc", Rating = 4.5f },
                new Movie { Id = 102, Name = "XYZ", Rating = 4.8f }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 101 , Name = "Eren" , Age = 22 , Phone = "9876543210"}
                );
            modelBuilder.Entity<Booking>().HasData(
                new Booking{ BookingNumber = 1001 , MovieId = 101 , CustomerId = 101 , BookingDate = DateTime.Now}
                );
        }
    }
}