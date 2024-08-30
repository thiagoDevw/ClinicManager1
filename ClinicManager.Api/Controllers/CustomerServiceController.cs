using ClinicManager.Api.Models.CustomerModels;
using ClinicManager.Application.Models;
using ClinicManager.Application.Models.CustomerModels;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public CustomerServiceController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerService
        [HttpGet]
        public IActionResult GetAll(string search = "", int page = 1, int pageSize = 3)
        {
            var query = _context.CustomerServices
                    .Include(cs => cs.Patient)  
                    .Include(cs => cs.Doctor)   
                    .Include(cs => cs.Service)
                    .AsQueryable();


            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Patient.Name.Contains(search) ||
                                         c.Doctor.Name.Contains(search) ||
                                         c.Service.Name.Contains(search));
            }

            var totalRecords = query.Count();

            var customers = query
                .OrderBy(c => c.Patient.Name)
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .Select(c => new CustomerItemViewModel(
                    c.Id,
                    c.Patient.Name,
                    c.Doctor.Name,
                    c.Service.Name,
                    c.Agreement
                ))
                .ToList();

            var result = new
            {
                TotalRecords = totalRecords,
                Page = page,
                PageSize = pageSize,
                Data = customers
            };

            return Ok(new ResultViewModel<object>(result));
        }

        // GetById api/customerService
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.CustomerServices
                .Where(c => c.Id == id)
                .Select(c => new CustomerViewModel
                {
                    Id = c.Id,
                    PatientName = c.Patient.Name,
                    DoctorName = c.Doctor.Name,
                    ServiceName = c.Service.Name,
                    Agreement = c.Agreement,
                    Start = c.Start,
                    End = c.End,
                    TypeService = c.TypeService
                })
                .FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(new ResultViewModel<CustomerViewModel>(customer));
        }

        // POST api/customerService
        [HttpPost]
        public IActionResult PostCustomer(CreateCustomerInputModel model)
        {
            var customerService = new CustomerService
            {
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                ServiceId = model.ServiceId,
                Agreement = model.Agreement,
                Start = model.Start,
                End = model.End,
                TypeService = model.TypeService
            };

            _context.CustomerServices.Add(customerService);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = customerService.Id }, model);
        }

        // PUT api/customerService
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, UpdateCustomerInputModel model)
        {
            var customerService = _context.CustomerServices.Find(id);

            if (customerService == null)
            {
                return NotFound();
            }

            customerService.PatientId = model.PatientId;
            customerService.DoctorId = model.DoctorId;
            customerService.ServiceId = model.ServiceId;
            customerService.Agreement = model.Agreement;
            customerService.Start = model.Start;
            customerService.End = model.End;
            customerService.TypeService = model.TypeService;

            _context.CustomerServices.Update(customerService);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/customerService
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerService = _context.CustomerServices.Find(id);

            if (customerService == null)
            {
                return NotFound();
            }

            _context.CustomerServices.Remove(customerService);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
