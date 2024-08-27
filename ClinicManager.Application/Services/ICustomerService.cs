using ClinicManager.Api.Models.CustomerModels;
using ClinicManager.Application.Models;
using ClinicManager.Application.Models.CustomerModels;

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
}
