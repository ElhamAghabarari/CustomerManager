using CustomerManagement.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Inferstructure
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}