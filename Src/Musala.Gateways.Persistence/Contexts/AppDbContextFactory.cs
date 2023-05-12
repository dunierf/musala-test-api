using Musala.Gateways.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Musala.Gateways.Persistence.Contexts
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
