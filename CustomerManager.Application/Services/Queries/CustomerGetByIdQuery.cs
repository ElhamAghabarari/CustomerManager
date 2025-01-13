using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.Queries
{
    public record CustomerGetByIdQuery(int id) : IRequest<Customer>;
}
