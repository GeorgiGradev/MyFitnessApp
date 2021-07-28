namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class FoodsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Foods.Any())
            {
                return;
            }

            var foods = new List<Food>
            {
                new Food
                {
                    Name = "Pork Fillet Grilled",
                    ProteinIn100Grams = 21,
                    CarbohydratesIn100Grams = 0,
                    FatIn100Grams = 8,
                },
                new Food
                {
                    Name = "Oatmeal",
                    ProteinIn100Grams = 13,
                    CarbohydratesIn100Grams = 60,
                    FatIn100Grams = 7,
                },
                new Food
                {
                    Name = "White rice raw",
                    ProteinIn100Grams = 0,
                    CarbohydratesIn100Grams = 78,
                    FatIn100Grams = 1,
                },
                new Food
                {
                    Name = "Broccoli Boiled",
                    ProteinIn100Grams = 3,
                    CarbohydratesIn100Grams = 7,
                    FatIn100Grams = 0,
                },
                new Food
                {
                    Name = "Olive Oil",
                    ProteinIn100Grams = 0,
                    CarbohydratesIn100Grams = 0,
                    FatIn100Grams = 100,
                },
                new Food
                {
                    Name = "Cucumber",
                    ProteinIn100Grams = 1,
                    CarbohydratesIn100Grams = 4,
                    FatIn100Grams = 0,
                },
                new Food
                {
                    Name = "Avocado",
                    ProteinIn100Grams = 2,
                    CarbohydratesIn100Grams = 9,
                    FatIn100Grams = 15,
                },
                new Food
                {
                    Name = "Chicken Breast Grilled",
                    ProteinIn100Grams = 30,
                    CarbohydratesIn100Grams = 0,
                    FatIn100Grams = 5,
                },
                new Food
                {
                    Name = "Egg Yolk",
                    ProteinIn100Grams = 16,
                    CarbohydratesIn100Grams = 4,
                    FatIn100Grams = 27,
                },
                new Food
                {
                    Name = "Egg White",
                    ProteinIn100Grams = 11,
                    CarbohydratesIn100Grams = 1,
                    FatIn100Grams = 0,
                },
            };

            foreach (var item in foods)
            {
                await dbContext.Foods.AddAsync(new Food
                {
                    Name = item.Name,
                    ProteinIn100Grams = item.ProteinIn100Grams,
                    CarbohydratesIn100Grams = item.CarbohydratesIn100Grams,
                    FatIn100Grams = item.FatIn100Grams,
                    AddedByUser = dbContext.Users.
                                       Where(x => x.UserName == "admin")
                                       .FirstOrDefault(),
                });
            }
        }
    }
}
