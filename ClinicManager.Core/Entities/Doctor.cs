
namespace ClinicManager.Core.Entities
{
    public class Doctor : BaseEntity
    {
        public Doctor() { }
        public Doctor(string name, string lastName, string cpf)
        {
            Name = name;
            LastName = lastName;
            CPF = cpf;
        }
 
        private string _cpf;

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string BloodType { get; set; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public string CRM { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}
