using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using CustomerManagement.Application.Services.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.Handlers
{
    public class CustomerGetByIdQueryHandler : IRequestHandler<CustomerGetByIdQuery, Customer>
    {
        private readonly ICustomerService _customerService;

        public CustomerGetByIdQueryHandler(ICustomerService service)
        {
            _customerService = service;
        }

        public async Task<Customer> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomer(request.id);
        }
    }
}
