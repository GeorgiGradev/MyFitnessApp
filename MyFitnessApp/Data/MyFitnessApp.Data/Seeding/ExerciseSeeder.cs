namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ExerciseSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Exercises.Any())
            {
                return;
            }

            var exercises = new List<Exercise>
            {
               new Exercise
               {
                  Name = "Арнолд раменни преси с дъмбели",
                  Description = "Арнолд пресата е бутащо многоставно движение с основен характер в изграждането на раменната мускулатура. Подходящо е за средно напреднали и напреднали трениращи заради сложната кинезиология на ротация в раменете по време на движението. За ползотворното му прилагане се изисква изпълнение с бавна контролирана крива. Противопоказания В случай че имате контузии в раменете, ротаторните маншони, скапулата, лактите или врата, консултирайте използването на Арнолд преса с кинезиолог, кинезитерапевт или треньор, работещ с кинезиологично издържани практики. В случай на рязка болка, крампиране или разтягане на мускулатурата дълбоко в рамото, преустановете движението. Не прибягвайте към Арнолд преса с големи килограми, преди да сте се уверили в мобилността на раменете си.",
                  EquipmentId = 11,
                  CategoryId = 5,
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                  ImageUrl = "https://bbteamcdn.com/content/originals/3697.jpg",
                  VideoUrl = "https://www.youtube.com/embed/gAS1oKgQcwU",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
            };

            foreach (var item in exercises)
            {
                await dbContext.Exercises.AddAsync(new Exercise
                {
                    Name = item.Name,
                    Description = item.Description,
                    EquipmentId = item.EquipmentId,
                    CategoryId = item.CategoryId,
                    Difficulty = item.Difficulty,
                    ImageUrl = item.ImageUrl,
                    VideoUrl = item.VideoUrl,
                    AddedByUser = item.AddedByUser,
                });
            }
        }
    }
}
