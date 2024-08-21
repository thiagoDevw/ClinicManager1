using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Api.Persistence
{
    public class ClinicManagerDbContext : DbContext
    {
        public ClinicManagerDbContext(DbContextOptions<ClinicManagerDbContext> options)
            : base(options) 
        {

        }
    }
}
