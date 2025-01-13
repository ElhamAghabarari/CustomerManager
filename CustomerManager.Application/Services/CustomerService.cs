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
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Customer>();
        }

        public async Task DeleteCustomer(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Save();
            await Task.CompletedTask;
        }

        public async Task<List<Customer>> GetAllCustomers(string search)
        {
            return await Task.FromResult(_repository.GetAll((item) => item.Name.ToLower().Contains(search)));
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await Task.FromResult(_repository.GetById(id));
        }

        public async Task InsertCustomer(Customer customer)
        {
            _repository.Add(customer);
            _unitOfWork.Save();
            await Task.CompletedTask;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var cus = _repository.GetById(customer.Id);
            cus.Name = customer.Name;

            _repository.Update(cus);
            _unitOfWork.Save();
            await Task.CompletedTask;
        }
    }
}
