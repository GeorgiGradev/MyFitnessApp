//// Seeder на ExerciseEquipments ////

namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ExerciseEquipmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ExerciseEquipments.Any())
            {
                return;
            }

            var exerciseEquipmentNames = new List<string>
            {
                "Bands",
                "Foam Roll",
                "Barbell",
                "Kettlebells",
                "Body Only",
                "Machine",
                "Cable",
                "Medicine Ball",
                "Dumbbell",
                "EZ Curl Bar",
                "Exercise Ball",
                "Other",
            };

            foreach (var item in exerciseEquipmentNames)
            {
                await dbContext.ExerciseEquipments.AddAsync(new ExerciseEquipment
                {
                    Name = item,
                });
            }
        }
    }
}
