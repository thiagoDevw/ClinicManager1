using ClinicManager.Api.Services;

namespace ClinicManager.Api.Entities
{
    public class Doctor
    {
        private string _cpf;

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CPF
        {
            get => _cpf;
            set
            {
                if (!CPFValidator.IsValid(value))
                {
                    throw new ArgumentException("CPF inválido.");
                }
                _cpf = value;
            }
        }
        public string BloodType { get; set; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public string CRM { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}
