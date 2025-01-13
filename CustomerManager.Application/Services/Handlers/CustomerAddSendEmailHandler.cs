using CustomerManagement.Application.Services.notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.Handlers
{
    public class CustomerAddSendEmailHandler : INotificationHandler<CustomerAddNotification>
    {
        public async Task Handle(CustomerAddNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"sending Email for adding customer: {notification.customer.Name} #{notification.customer.Id}");
            await Task.CompletedTask;
        }
    }
}
