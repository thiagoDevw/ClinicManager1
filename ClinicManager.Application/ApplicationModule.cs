using ClinicManager.Application.Services.ServicesCustomer;
using ClinicManager.Application.Services.ServicesDoctor;
using ClinicManager.Application.Services.ServicesPatient;
using ClinicManager.Application.Services.ServicesService;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IService, ServiceManager>();
            return services;
        }

    }
}
