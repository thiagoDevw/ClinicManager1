using ClinicManager.Api.Models.DoctorModels;
using ClinicManager.Application.Models.DoctorModels;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public DoctorsController(ClinicDbContext context)
        {
            _context = context;
        }


        // GET api/doctors
        [HttpGet]
        public IActionResult GetAll()
        {
            var doctors = _context.Doctors
                .Select(d => DoctorItemViewModel.FromEntity(d))
                .ToList();

            return Ok(doctors);
        }

        // GETBYID api/doctors
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doctor = _context.Doctors
                .FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound();
            }

            var doctorViewModel = DoctorViewModel.FromEntity(doctor);
            return Ok(doctorViewModel);
        }

        // POST api/doctors
        [HttpPost]
        public IActionResult PostDoctor([FromBody] CreateDoctorInputModel model)
        {
            if(model == null)
            {
                return BadRequest("Doctor data is required.");
            }

            if (string.IsNullOrWhiteSpace(model.Name) ||
                string.IsNullOrWhiteSpace(model.LastName) ||
                string.IsNullOrWhiteSpace(model.Email) ||
                string.IsNullOrWhiteSpace(model.CPF) ||
                string.IsNullOrWhiteSpace(model.CRM))
            {
                return BadRequest("Some required fields are missing.");
            }

            var doctor = new Doctor
            {
                Name = model.Name,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Phone = model.Phone,
                Email = model.Email,
                CPF = model.CPF,
                BloodType = model.BloodType,
                Address = model.Address,
                Specialty = model.Specialty,
                CRM = model.CRM
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            var doctorViewModel = DoctorViewModel.FromEntity(doctor);

            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctorViewModel);
        }

        // PUT api/doctors
        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, [FromBody] UpdateDoctorInputModel model)
        {
            if (model == null)
            {
                return BadRequest("Doctor data is required.");
            }

            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound("Doctor not found.");
            }

            doctor.Name = model.Name;
            doctor.LastName = model.LastName;
            doctor.DateOfBirth = model.DateOfBirth;
            doctor.Phone = model.Phone;
            doctor.Email = model.Email;
            doctor.CPF = model.CPF;
            doctor.BloodType = model.BloodType;
            doctor.Address = model.Address;
            doctor.Specialty = model.Specialty;
            doctor.CRM = model.CRM;

            _context.Doctors.Update(doctor);
            _context.SaveChanges();

            var doctorViewmodel = DoctorViewModel.FromEntity(doctor);

            return Ok(doctorViewmodel);
        }

        // DELETE api/doctors
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);
            
            if (doctor == null)
            {
                return NotFound("Doctor not found.");
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return Ok(new { message = "Doctor removed successfully" });
        }
    }
}
