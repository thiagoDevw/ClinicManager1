using ClinicManager.Api.Models.ServiceModels;
using ClinicManager.Application.Models.ServiceModels;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure.Persistence;
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
            var services = _context.Services
                .Where(s => string.IsNullOrEmpty(query) ||
                            s.Name.Contains(query) ||
                            s.Description.Contains(query))
                .Select(s => ServiceItemViewModel.FromEntity(s))
                .ToList();

            return Ok(services);
        }

        // GETBYID api/service
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _context.Services
                .FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return NotFound(new { message = "Serviço não encontrado." });
            }

            var serviceViewModel = ServiceViewModel.FromEntity(service);

            return Ok(serviceViewModel);
        }


        // POST api/service
        [HttpPost]
        public IActionResult PostService([FromBody] CreateServiceInputModel model)
        {
            if (model == null)
            {
                return BadRequest("Dados do serviço não fornecidos.");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(_context.Services.Any(s => s.Name == model.Name))
            {
                return Conflict("Já existe um serviço com este nome.");
            }

            var service = new Service
            {
                Name = model.Name,
                Description = model.Description,
                Value = model.Value,
                Duration = model.Duration
            };

            _context.Services.Add(service);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = service.Id }, ServiceViewModel.FromEntity(service));
        }

        // PUT api/service
        [HttpPut("{id}")]
        public IActionResult PutService(int id, [FromBody] UpdateServiceInputModel model)
        {
            if (model == null)
            {
                return BadRequest("Dados do serviço não fornecidos.");
            }

            if (id != model.Id)
            {
                return BadRequest("Id do serviço não corresponde ao ID fornecido no modelo.");
            }

            var existingService = _context.Services.Find(id);
            if (existingService == null)
            {
                return NotFound($"Serviço com ID {id} não encontrado.");
            }

            existingService.Name = model.Name;
            existingService.Description = model.Description;
            existingService.Value = model.Value;
            existingService.Duration = model.Duration;

            _context.Services.Update(existingService);
            _context.SaveChanges();

            return Ok(ServiceViewModel.FromEntity(existingService));
        }

        // DELETE api/service
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.SingleOrDefault(s => s.Id == id);

            if (service == null)
            {
                return NotFound("Serviço não encontrado.");
            }

            _context.Services.Remove(service);
            _context.SaveChanges();


            return Ok(new { message = "Serviço removido com sucesso." });
        }
    }
}
