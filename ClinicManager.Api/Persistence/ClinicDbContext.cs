using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Api.Persistence
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options) 
        {

        }
    }
}
