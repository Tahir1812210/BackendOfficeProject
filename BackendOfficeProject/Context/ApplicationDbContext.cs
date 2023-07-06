using BackendOfficeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

 

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }


       public DbSet<HeadDetail> HeadDetails { get; set; }

       public DbSet<Detail> Details { get; set; }

    }
}
