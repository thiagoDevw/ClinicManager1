using ClinicManager.Api.Models.CustomerModels;
using ClinicManager.Application.Models.CustomerModels;
using ClinicManager.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManager.Application.Models.DoctorModels;
using ClinicManager.Api.Models.DoctorModels;
using ClinicManager.Infrastructure.Persistence;

namespace ClinicManager.Application.Services
{
    public interface IDoctor
    {
        ResultViewModel<List<DoctorItemViewModel>> GetAll(string search = "");
        ResultViewModel<DoctorViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateDoctorInputModel model);
        ResultViewModel Update(UpdateDoctorInputModel model);
        ResultViewModel DeleteById(int id);
    }

    public class Doctor : IDoctor
    {
        private readonly ClinicDbContext _context;
        public Doctor(ClinicDbContext context)
        {
            _context = context;
        }

        public ResultViewModel DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<List<DoctorItemViewModel>> GetAll(string search = "")
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<DoctorViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<int> Insert(CreateDoctorInputModel model)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Update(UpdateDoctorInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
