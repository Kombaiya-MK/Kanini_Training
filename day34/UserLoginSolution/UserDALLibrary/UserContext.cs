using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UserModelLibrary;
namespace UserDALLibrary
{
    public class UserContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbUserInfo21Apr2023");
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { Id = 1 , Name = "ABC" , Password = "ABC@123" , IsAdmin=true});
        }
    }
}
