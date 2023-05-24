using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sample1
{
    public class Context : DbContext
    {
        public Context() 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=SampleBase");
        }
        public DbSet<user> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().HasData(new user
            { id = 101 , age = 21 , name = "abc" 
            });
        }

        

    }
}
