using ClinicManager.Api.Models;
using ClinicManager.Api.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly ClinicManagerDbContext _context;
        public DoctorsController(ClinicManagerDbContext context)
        {
            _context = context;
        }


        // GET api/doctors
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            return Ok();
        }

        // GETBYID api/doctors
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/doctors
        [HttpPost]
        public IActionResult PostDoctor(CreateDoctorInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT api/doctors
        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, UpdateDoctorInputModel model)
        {
            return NoContent();
        }

        // DELETE api/
    }
}
