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
    }
}
