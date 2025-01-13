using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.commands
{
    public record CustomerDeleteCommand(int id): IRequest;
}
