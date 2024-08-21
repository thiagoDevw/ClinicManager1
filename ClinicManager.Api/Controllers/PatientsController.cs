using ClinicManager.Api.Models;
using ClinicManager.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ClinicManagerDbContext _context;
        public PatientsController(ClinicManagerDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerService
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            return Ok();
        }

        // GetById api/customerService
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/customerService
        [HttpPost]
        public IActionResult PostCustomer(CreateCustomerInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT api/customerService
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, UpdateCustomerInputModel model)
        {
            return NoContent();
        }

        // DELETE api/customerService
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            return NoContent();
        }
    }
}
