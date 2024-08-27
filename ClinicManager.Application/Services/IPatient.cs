using ClinicManager.Api.Models.CustomerModels;
using ClinicManager.Application.Models.CustomerModels;
using ClinicManager.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManager.Application.Models.PatientsModels;
using ClinicManager.Api.Models.PatientsModels;
using ClinicManager.Infrastructure.Persistence;

namespace ClinicManager.Application.Services
{
    public interface IPatient
    {
        ResultViewModel<List<PatientItemViewModel>> GetAll(string search = "");
        ResultViewModel<PatientViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreatePatientsInputModel model);
        ResultViewModel Update(UpdatePatientsInputModel model);
        ResultViewModel DeleteById(int id);
    }

    public class Patien : IPatient
    {
        private readonly ClinicDbContext _context;
        public Patien(ClinicDbContext context)
        {
            _context = context;
        }

        public ResultViewModel DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<List<PatientItemViewModel>> GetAll(string search = "")
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<PatientViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<int> Insert(CreatePatientsInputModel model)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Update(UpdatePatientsInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
