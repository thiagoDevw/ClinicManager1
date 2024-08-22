<<<<<<< HEAD
﻿using ClinicManager.Api.Models.ServiceModels;
=======
﻿using ClinicManager.Api.Models;
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
using ClinicManager.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< HEAD

    public class ServiceController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public ServiceController(ClinicDbContext context)
=======
    public class ServiceController : ControllerBase
    {
        private readonly ClinicManagerDbContext _context;
        public ServiceController(ClinicManagerDbContext context)
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        {
            _context = context;
        }

<<<<<<< HEAD

        // GET api/service
=======
        // GET: api/CustomerService
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            return Ok();
        }

<<<<<<< HEAD
        // GETBYID api/service
=======
        // GetById api/customerService
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

<<<<<<< HEAD
        // POST api/service
        [HttpPost]
        public IActionResult PostDoctor(CreateServiceInputModel model)
=======
        // POST api/customerService
        [HttpPost]
        public IActionResult PostCustomer(CreateCustomerInputModel model)
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

<<<<<<< HEAD
        // PUT api/service
        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, UpdateServiceInputModel model)
=======
        // PUT api/customerService
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, UpdateCustomerInputModel model)
>>>>>>> 116778f9091b89e4bd67ec77906d7bef112ad619
        {
            return NoContent();
        }

<<<<<<< HEAD
        // DELETE api/service
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
