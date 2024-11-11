using CustomerManagement.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Inferstructure
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) 
        {

        }
        public DbSet<Customer> Customers;
    }
}