using ClinicManager.Api.Models.PatientsModels;
﻿using ClinicManager.Api.Models;
using ClinicManager.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok();
        }
        
        // GETBYID api/patients
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/patients
        [HttpPost]
        public IActionResult PostPatients(CreatePatientsInputModel model) 
        { 

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }


        // PUT api/patients
        [HttpPut("{id}")]
        public IActionResult PutPatients(int id, UpdatePatientsInputModel model)
        {
            return NoContent();
        }

        // DELETE api/patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            return NoContent();
        }
    }
}
