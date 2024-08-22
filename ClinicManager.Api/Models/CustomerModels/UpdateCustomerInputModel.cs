using ClinicManager.Api.Entities;
using ClinicManager.Api.Enums;

namespace ClinicManager.Api.Models.CustomerModels
{
    public class UpdateCustomerInputModel
    {
        public int ServiceId {  get; set; }
        public int DoctorId { get; set; }
        public string Agreement {  get; set; }
        public DateTime Start {  get; set; }
        public ServiceType TypeService { get; set; }
    }
}
