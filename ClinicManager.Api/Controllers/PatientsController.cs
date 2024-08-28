using ClinicManager.Api.Models.PatientsModels;
using ClinicManager.Application.Models.PatientsModels;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers
{
    [ApiController]
    [Route("api/patients")]
    
    public class PatientsController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public PatientsController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET api/patients
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var patients = _context.Patients
                .Where(p => string.IsNullOrEmpty(query) ||
                            p.Name.Contains(query) ||
                            p.LastName.Contains(query) ||
                            p.Email.Contains(query) ||
                            p.CPF.Contains(query))
                .Select(p => PatientItemViewModel.FromEntity(p))
                .ToList();

            return Ok(patients);
        }
        
        // GETBYID api/patients
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var patient = _context.Patients
                .FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound(new {  message = "Paciente não encontrado." });
            }

            var patientViewModel = PatientViewModel.FromEntity(patient);

            return Ok(patientViewModel);
        }

        // POST api/patients
        [HttpPost]
        public IActionResult PostPatients([FromBody] CreatePatientsInputModel model) 
        { 
            if (model == null)
            {
                return BadRequest("Dados do paciente não fornecidos.");
            }

            if (_context.Patients.Any(p => p.CPF == model.CPF))
            {
                return Conflict("Paciente com este CPF já existe.");
            }

            var patient = new Patient
            {
                Name = model.Name,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Phone = model.Phone,
                Email = model.Email,
                CPF = model.CPF,
                BloodType = model.BloodType,
                Height = model.Height,
                Weight = model.Weight,
                Address = model.Address
            };

            _context.Patients.Add(patient);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, PatientViewModel.FromEntity(patient));
        }


        // PUT api/patients
        [HttpPut("{id}")]
        public IActionResult PutPatients(int id, [FromBody] UpdatePatientsInputModel model)
        {
            if (model == null)
            {
                return BadRequest("Dados do paciente não fornecidos.");
            }

            var existingPatient = _context.Patients.Find(id);
            if (existingPatient == null)
            {
                return NotFound($"Paciente com ID {model.Id} não encontrado.");
            }

            existingPatient.Name = model.Name;
            existingPatient.LastName = model.LastName;
            existingPatient.DateOfBirth = model.DateOfBirth;
            existingPatient.Phone = model.Phone;
            existingPatient.Email = model.Email;
            existingPatient.CPF = model.CPF;
            existingPatient.BloodType = model.BloodType;
            existingPatient.Height = model.Height;
            existingPatient.Weight = model.Weight;
            existingPatient.Address = model.Address;

            _context.Patients.Update(existingPatient);
            _context.SaveChanges();

            return Ok(PatientViewModel.FromEntity(existingPatient));
        }

        // DELETE api/patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.SingleOrDefault(d => d.Id == id);

            if (patient == null)
            {
                return NotFound("Paciente não encontrado.");
            }

            _context.Patients.Remove(patient);  
            _context.SaveChanges();

            return Ok(new { message = "Paciente removido com sucesso." });
        }
    }
}
