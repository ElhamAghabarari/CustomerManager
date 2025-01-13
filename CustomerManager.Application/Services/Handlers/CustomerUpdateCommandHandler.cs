using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Services.commands;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.Handlers
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand>
    {
        private readonly ICustomerService _customerService;
        public CustomerUpdateCommandHandler(ICustomerService service)
        {
            _customerService = service;
        }
        public async Task Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            await _customerService.UpdateCustomer(request.customer);
        }
    }
}
