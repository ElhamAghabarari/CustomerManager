using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Services.commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.Handlers
{
    public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommand>
    {
        private readonly ICustomerService _customerService;

        public CustomerDeleteCommandHandler(ICustomerService service)
        {
            _customerService = service;
        }
        public async Task Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            await _customerService.DeleteCustomer(request.id);
        }
    }
}
