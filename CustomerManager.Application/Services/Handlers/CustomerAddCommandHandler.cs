using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using CustomerManagement.Application.Services.commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.Handlers
{
    public class CustomerAddCommandHandler : IRequestHandler<CustomerAddCommand>
    {
        private readonly ICustomerService _customerService;

        public CustomerAddCommandHandler(ICustomerService service)
        {
            _customerService = service;
        }
        public async Task Handle(CustomerAddCommand request, CancellationToken cancellationToken)
        {
            await _customerService.InsertCustomer(request.customer);
        }
    }
}
