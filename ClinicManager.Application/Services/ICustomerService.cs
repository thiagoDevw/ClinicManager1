using ClinicManager.Api.Models.CustomerModels;
using ClinicManager.Application.Models;
using ClinicManager.Application.Models.CustomerModels;
using ClinicManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Services
{
    public interface ICustomerService
    {
        ResultViewModel<List<CustomerItemViewModel>> GetAll(string search = "");
        ResultViewModel<CustomerViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateCustomerInputModel model);
        ResultViewModel Update(UpdateCustomerInputModel model);
        ResultViewModel DeleteById(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ClinicDbContext _context;
        public CustomerService(ClinicDbContext context)
        {
            _context = context;
        }

        public ResultViewModel DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<List<CustomerItemViewModel>> GetAll(string search = "")
        {
            var query = _context.CustomerServices.AsQueryable();

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
            throw new NotImplementedException();
        }

        public ResultViewModel<int> Insert(CreateCustomerInputModel model)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Update(UpdateCustomerInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
