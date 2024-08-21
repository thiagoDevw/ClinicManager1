namespace ClinicManager.Api.Entities
{
    public class CustomerService
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ServiceId { get; set; }
        public int DoctorId { get; set; }
        public string Agreement { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public ServiceType TypeService { get; set; } //Enum específico
    }

    public enum ServiceType
    {
        Consultation, 
        Surgery,
        Examination,
        Other
    }
}
