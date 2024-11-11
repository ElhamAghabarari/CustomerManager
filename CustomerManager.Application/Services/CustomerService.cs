using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services
{
    internal class CustomerService: ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        public CustomerService(IUnitOfWork uw)
        {
            _repository = uw.GetRepository<Customer>();
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return _repository.GetById(id);
        }

        public int InsertCustomer(Customer customer)
        {
            return _repository.Add(customer);
        }
    }
}
