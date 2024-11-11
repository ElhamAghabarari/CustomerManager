using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Extentions
{
    public static class ApplicationExtentions
    {
        public static void AddApplicationServices(this IServiceCollection services) {
            services.AddTransient<ICustomerService,CustomerService>();

        }
    }
}
