<<<<<<< HEAD
﻿using ClinicManager.Api.Models.PatientsModels;
=======
﻿using ClinicManager.Api.Models;
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
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

<<<<<<< HEAD
        // GET api/patients
=======
        // GET: api/CustomerService
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            return Ok();
        }

<<<<<<< HEAD
        // GETBYID api/patients
=======
        // GetById api/customerService
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

<<<<<<< HEAD
        // POST api/patients
        [HttpPost]
        public IActionResult PostDoctor(CreatePatientsInputModel model)
=======
        // POST api/customerService
        [HttpPost]
        public IActionResult PostCustomer(CreateCustomerInputModel model)
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

<<<<<<< HEAD
        // PUT api/patients
        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, UpdatePatientsInputModel model)
=======
        // PUT api/customerService
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, UpdateCustomerInputModel model)
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        {
            return NoContent();
        }

<<<<<<< HEAD
        // DELETE api/patients
=======
        // DELETE api/customerService
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            return NoContent();
        }
    }
}
