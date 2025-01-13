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
    public class CustomerGetAllQueryHandler : IRequestHandler<CustomerGetAllQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerService _customerService;

        public CustomerGetAllQueryHandler(ICustomerService service)
        {
            _customerService = service;
        }
        public async Task<IEnumerable<Customer>> Handle(CustomerGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _customerService.GetAllCustomers(request.search);
        }
    }
}
