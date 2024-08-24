using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options) 
        {

        }
    }
}
