using ClinicManager.Api.Models.ServiceModels;
using ClinicManager.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ServiceController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public ServiceController(ClinicDbContext context)
        {
            _context = context;
        }


        // GET api/service
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            return Ok();
        }

        // GETBYID api/service
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/service
        [HttpPost]
        public IActionResult PostDoctor(CreateServiceInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT api/service
        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, UpdateServiceInputModel model)
        {
            return NoContent();
        }

        // DELETE api/service
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            return NoContent();
        }
    }
}
