using Azure.Core;
using Musala.Gateways.Domain.Entities.Devices;
using Musala.Gateways.Persistence.Contexts;
using System;
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
                    new DeviceStatus {
                        Name = "Online",
                        CreatedBy = "system",
                        CreatedDate = DateTime.UtcNow,
                        LastModifiedBy = "system",
                        ModifiedDate = DateTime.UtcNow,
                        IsActive = true
                    },

                    new DeviceStatus {
                        Name = "Offline",
                        CreatedBy = "system",
                        CreatedDate = DateTime.UtcNow,
                        LastModifiedBy = "system",
                        ModifiedDate = DateTime.UtcNow,
                        IsActive = true
                    }
                );

                db.SaveChangesAsync();
            }
        }

    }
}
