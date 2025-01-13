using CustomerManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers(string search);
        Task<Customer> GetCustomer(int id);
        Task InsertCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
