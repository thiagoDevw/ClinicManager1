using ClinicManager.Api.Models.ServiceModels;
using ClinicManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Models.ServiceModels
{
    public class ServiceItemViewModel
    {
        public ServiceItemViewModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static ServiceItemViewModel FromEntity(Service entity)
        {
            return new ServiceItemViewModel(
                entity.Id,
                entity.Name,
                entity.Description
                );
        }
    }
}
