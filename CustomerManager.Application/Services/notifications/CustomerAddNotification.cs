using CustomerManagement.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.notifications
{
    public record CustomerAddNotification(Customer customer): INotification;
}
