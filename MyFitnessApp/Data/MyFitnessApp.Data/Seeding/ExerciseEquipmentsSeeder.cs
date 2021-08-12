namespace MyFitnessApp.Data.Seeding
{
    using System;
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

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Body only",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Exercise Ball",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Medicine Ball",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Foam Roll",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Kettlebells",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Bands",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "EZ Curl Bar",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Cable",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Machine",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Barbell",
            });
            dbContext.SaveChanges();

            dbContext.ExerciseEquipments.Add(new ExerciseEquipment
            {
                Name = "Dumbbell",
            });
            dbContext.SaveChanges();

            await dbContext.SaveChangesAsync();
        }
    }
}
