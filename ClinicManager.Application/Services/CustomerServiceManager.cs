using ClinicManager.Api.Models.CustomerModels;
using ClinicManager.Application.Models;
using ClinicManager.Application.Models.CustomerModels;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Services
{
    public class CustomerServiceManager : ICustomerService
    {
        private readonly ClinicDbContext _context;
        public CustomerServiceManager(ClinicDbContext context)
        {
            _context = context;
        }

        public ResultViewModel DeleteById(int id)
        {
            var customerService = _context.CustomerServices.FirstOrDefault(c => c.Id == id);

            if (customerService == null)
            {
                return new ResultViewModel(false, "Customer service not found");
            }

            _context.CustomerServices.Remove(customerService);
            _context.SaveChanges();

            return new ResultViewModel(true, "Customer service deleted saccussfully");
        }

        public ResultViewModel<List<CustomerItemViewModel>> GetAll(string search = "")
        {
            var query = _context.CustomerServices
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                .Include(c => c.Service)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Patient.Name.Contains(search) ||
                                         c.Doctor.Name.Contains(search) ||
                                         c.Service.Name.Contains(search));
            }

            var customers = query
                .Select(c => CustomerItemViewModel.FromEntity(c, c.Patient.Name, c.Doctor.Name, c.Service.Name))
                .ToList();

            return new ResultViewModel<List<CustomerItemViewModel>>(customers);
        }

        public ResultViewModel<CustomerViewModel> GetById(int id)
        {
            var customerService = _context.CustomerServices
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                .Include(c => c.Service)
                .FirstOrDefault(c => c.Id == id);

            if (customerService == null)
            {
                return new ResultViewModel<CustomerViewModel>(null, false, " Customer service not found ");
            }

            var customerViewModel = new CustomerViewModel(
                customerService.Id,
                customerService.Patient.Name,
                customerService.Doctor.Name,
                customerService.Service.Name,
                customerService.Agreement,
                customerService.Start,
                customerService.End,
                customerService.TypeService
                );

            return new ResultViewModel<CustomerViewModel>(customerViewModel);
        }

        public ResultViewModel<int> Insert(CreateCustomerInputModel model)
        {
            var customerServiceEntity = new CustomerService
            {
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                ServiceId = model.ServiceId,
                Agreement = model.Agreement,
                Start = model.Start,
                End = model.End,
                TypeService = model.TypeService
            };

            _context.CustomerServices.Add(customerServiceEntity);
            _context.SaveChanges();

            return new ResultViewModel<int>(customerServiceEntity.Id);
        }

        public ResultViewModel Update(UpdateCustomerInputModel model)
        {
            var customerService = _context.CustomerServices.Find(model.Id);

            if (customerService == null)
            {
                return new ResultViewModel(false, "Customer service not found");
            }

            customerService.PatientId = model.PatientId;
            customerService.DoctorId = model.DoctorId;
            customerService.ServiceId = model.ServiceId;
            customerService.Agreement = model.Agreement;
            customerService.Start = model.Start;
            customerService.End = model.End;
            customerService.TypeService = model.TypeService;

            _context.CustomerServices.Update(customerService);
            _context.SaveChanges();

            return new ResultViewModel(true, "Customer service update succesfully");
        }
    }
}
