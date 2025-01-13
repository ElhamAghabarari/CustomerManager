using CustomerManagement.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Inferstructure
{
    public class CustomerDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(item => item.Id);

            modelBuilder.Entity<Customer>().Property(t => t.Name).IsRequired();
        }
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