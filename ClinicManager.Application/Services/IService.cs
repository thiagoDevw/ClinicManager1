using ClinicManager.Application.Models;
using ClinicManager.Application.Models.ServiceModels;
using ClinicManager.Api.Models.ServiceModels;
using ClinicManager.Infrastructure.Persistence;

namespace ClinicManager.Application.Services
{
    public interface IService
    {
        ResultViewModel<List<ServiceItemViewModel>> GetAll(string search = "");
        ResultViewModel<ServiceViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateServiceInputModel model);
        ResultViewModel Update(UpdateServiceInputModel model);
        ResultViewModel DeleteById(int id);
    }

    public class Service : IService
    {
        private readonly ClinicDbContext _context;
        public Service(ClinicDbContext context)
        {
            _context = context;
        }

        public ResultViewModel DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<List<ServiceItemViewModel>> GetAll(string search = "")
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<ServiceViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<int> Insert(CreateServiceInputModel model)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Update(UpdateServiceInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
