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

        public void DeleteCustomer(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Save();
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
            _repository.Add(customer);
            _unitOfWork.Save();
            return customer.Id;
        }

        public void UpdateCustomer(Customer customer)
        {
            var cus = _repository.GetById(customer.Id);
            cus.Name = customer.Name;

            _repository.Update(cus);
            _unitOfWork.Save();
        }
    }
}
