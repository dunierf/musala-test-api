using Musala.Gateways.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Musala.Gateways.Persistence.Seeders;
using System;

namespace  Musala.Gateways.Application.UnitTests.Mocks.Persistence
{
    public static class  AppplicationDbContextMock
    {
        public static AppDbContext appDbContext;

        static AppplicationDbContextMock()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            
            appDbContext = new AppDbContext(optionsBuilder.Options);

            InitInMemoryDatabase();
        }

        static void InitInMemoryDatabase() 
        {
            var seeder = new AppDbContextSeeder();
            seeder.SeedEverything(appDbContext);
        }  
    }
}