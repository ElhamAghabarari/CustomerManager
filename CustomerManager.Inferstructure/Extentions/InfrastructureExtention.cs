using CustomerManagement.Application.Interfaces;
using CustomerManager.Inferstructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure.Extentions
{
    public static class InfrastructureExtention
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options =>
                            options.UseNpgsql(configuration.GetConnectionString("LocalhostConnection")));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        //public static void AddInfrastructureServices(this IHostApplicationBuilder services)
        //{
        //    services.AddDbContext<CustomerDbContext>(options =>
        //                    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalhostConnection")));
        //}
    }
}

