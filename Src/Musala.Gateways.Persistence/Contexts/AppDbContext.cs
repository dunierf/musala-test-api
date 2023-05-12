using Musala.Gateways.Domain.Entities.Sample;
using Microsoft.EntityFrameworkCore;
using Musala.Gateways.Domain.Entities.Gateways;
using Musala.Gateways.Domain.Entities.Devices;

namespace Musala.Gateways.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }        
        public DbSet<Todo> Todos { set; get; }
        public DbSet<TodoItem> TodoItems { set; get; }



        public DbSet<Gateway> Gateways { get; set; }

        public DbSet<DeviceStatus> DeviceStatus { get; set; }

        public DbSet<Device> Devices { get; set; }

    }
}
