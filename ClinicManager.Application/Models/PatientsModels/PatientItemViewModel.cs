using ClinicManager.Api.Models.PatientsModels;
using ClinicManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Models.PatientsModels
{
    public class PatientItemViewModel
    {
        public PatientItemViewModel(int id, string name, string lastName, string email, string cPF, string address)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            CPF = cPF;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }

        public static PatientItemViewModel FromEntity(Patient entity)
        {
            return new PatientItemViewModel(
                entity.Id,
                entity.Name,
                entity.LastName,
                entity.Email,
                entity.CPF,
                entity.Address
                );
        }

    }
}
