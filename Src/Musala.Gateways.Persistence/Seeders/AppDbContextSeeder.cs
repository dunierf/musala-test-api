using Musala.Gateways.Domain.Entities.Devices;
using Musala.Gateways.Persistence.Contexts;
using System.Linq;

namespace Musala.Gateways.Persistence.Seeders
{
    public class AppDbContextSeeder
    {        

        public void SeedEverything(AppDbContext db)
        { 
            db.Database.EnsureCreated();
            SeedDeviceStatus(db);
        }

        private void SeedDeviceStatus(AppDbContext db)
        {
            if (!db.DeviceStatus.Any())
            {
                db.DeviceStatus.AddRange(
                    new DeviceStatus { Id = 1, Name = "Online" },
                    new DeviceStatus { Id = 2, Name = "Offline" }
                );
            }
        }

    }
}
