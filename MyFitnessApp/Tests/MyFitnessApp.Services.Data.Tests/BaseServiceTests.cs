namespace MyFitnessApp.Services.Data.Tests
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using MyFitnessApp.Data;

    public class BaseServiceTests
    {
        public static ApplicationDbContext GetDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new ApplicationDbContext(options);

            return db;
        }
    }
}
