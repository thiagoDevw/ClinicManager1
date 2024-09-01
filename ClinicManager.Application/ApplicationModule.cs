using ClinicManager.Application.Services.ServicesCustomer;
using ClinicManager.Application.Services.ServicesDoctor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerServiceManager>();
            services.AddScoped<IDoctorService, DoctorService>();

            return services;
        }
    }
}
