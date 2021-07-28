namespace MyFitnessApp.Services.Data.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Foods;

    public class FoodsService : IFoodsService
    {
        private readonly IDeletableEntityRepository<Food> foodsRepository;
        private readonly IDeletableEntityRepository<FoodMeal> foodMealsRepository;
        private readonly IDeletableEntityRepository<Meal> mealsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public FoodsService(
            IDeletableEntityRepository<Food> foodsRepository,
            IDeletableEntityRepository<FoodMeal> foodMealsRepository,
            IDeletableEntityRepository<Meal> mealsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.foodsRepository = foodsRepository;
            this.foodMealsRepository = foodMealsRepository;
            this.mealsRepository = mealsRepository;
            this.usersRepository = usersRepository;
        }

        public async Task CreateFoodAsync(CreateFoodInputModel model, string userId)
        {
            var food = new Food
            {
                Name = model.Name,
                ProteinIn100Grams = model.ProteinIn100Grams,
                CarbohydratesIn100Grams = model.CarbohydratesIn100Grams,
                FatIn100Grams = model.FatIn100Grams,
                AddedByUserId = userId,
            };

            await this.foodsRepository.AddAsync(food);
            await this.foodsRepository.SaveChangesAsync();
        }

        public bool DoesFoodExists(string name)
        {
            bool doesFoodExists = this.foodsRepository
                .All()
                .Any(x => x.Name == name);

            return doesFoodExists;
        }

        public IEnumerable<FoodViewModel> GetAllFoods()
        {
            var viewModel = this.foodsRepository
                .All()
                .Select(x => new FoodViewModel
                {
                    Name = x.Name,
                    ProteinIn100Grams = x.ProteinIn100Grams,
                    CarbohydratesIn100Grams = x.CarbohydratesIn100Grams,
                    FatIn100Grams = x.FatIn100Grams,
                    TotalCalories = (x.ProteinIn100Grams * 4) + (x.CarbohydratesIn100Grams * 4) + (x.FatIn100Grams * 9),
                })
                .ToList();

            return viewModel;
        }

        public async Task AddFoodToDiaryAsync(AddFoodInputModel model, string userId, string foodName)
        {
            bool doesMealExists = this.mealsRepository
                .All()
                .Any(x => x.Name == model.MealName && x.AddedByUserId == userId);

            var meal = new Meal();

            if (doesMealExists)
            {
                meal = this.mealsRepository
                    .All()
                    .Where(x => x.Name == model.MealName && x.AddedByUserId == userId)
                    .FirstOrDefault();
            }
            else
            {
                meal = new Meal
                {
                    Name = model.MealName,
                    AddedByUserId = userId,
                };
                await this.mealsRepository.AddAsync(meal);
                await this.mealsRepository.SaveChangesAsync();
            };

            var foodId = this.foodsRepository
                .All()
                .Where(x => x.Name == foodName)
                .Select(x => x.Id)
                .FirstOrDefault();

            var foodMeal = new FoodMeal
            {
                FoodId = foodId,
                MealId = meal.Id,
                ServingSizeInGrams = model.ServingSize,
            };

            await this.foodMealsRepository.AddAsync(foodMeal);
            await this.foodMealsRepository.SaveChangesAsync();

            meal.FoodMeals.Add(foodMeal);

            var searvingSize = meal.FoodMeals.Select(x => x.ServingSizeInGrams).FirstOrDefault();

            // foodMeal.Food.ProteinIn100Grams *= (double)searvingSize / 100 * foodMeal.Food.ProteinIn100Grams;
            // foodMeal.Food.CarbohydratesIn100Grams *= (double)searvingSize / 100 * foodMeal.Food.CarbohydratesIn100Grams;
            // foodMeal.Food.FatIn100Grams *= (double)searvingSize / 100 * foodMeal.Food.FatIn100Grams;
        }

        public FoodDiaryViewModel GetFoodDiary(string userId)
        {
            var breakfastFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Breakfast") && x.Meal.AddedByUserId == userId)
                .Select(x => x.Food)
                .ToList();

            var breakfastViewModel = breakfastFoods
                .Select(x => new FoodViewModel
                {
                    Name = x.Name,
                    ProteinIn100Grams = x.ProteinIn100Grams,
                    CarbohydratesIn100Grams = x.CarbohydratesIn100Grams,
                    FatIn100Grams = x.FatIn100Grams,
                    TotalCalories = (x.ProteinIn100Grams * 4) + (x.CarbohydratesIn100Grams * 4) + (x.FatIn100Grams * 9),
                });



            var lunchFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Lunch") && x.Meal.AddedByUserId == userId)
                .Select(x => x.Food)
                .ToList();

            var lunchViewModel = lunchFoods
                .Select(x => new FoodViewModel
                {
                    Name = x.Name,
                    ProteinIn100Grams = x.ProteinIn100Grams,
                    CarbohydratesIn100Grams = x.CarbohydratesIn100Grams,
                    FatIn100Grams = x.FatIn100Grams,
                    TotalCalories = (x.ProteinIn100Grams * 4) + (x.CarbohydratesIn100Grams * 4) + (x.FatIn100Grams * 9),
                });


            var snackFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Snack") && x.Meal.AddedByUserId == userId)
                .Select(x => x.Food)
                .ToList();

            var snackViewModel = snackFoods
                .Select(x => new FoodViewModel
                {
                    Name = x.Name,
                    ProteinIn100Grams = x.ProteinIn100Grams,
                    CarbohydratesIn100Grams = x.CarbohydratesIn100Grams,
                    FatIn100Grams = x.FatIn100Grams,
                    TotalCalories = (x.ProteinIn100Grams * 4) + (x.CarbohydratesIn100Grams * 4) + (x.FatIn100Grams * 9),
                });


            var dinnerFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Dinner") && x.Meal.AddedByUserId == userId)
                .Select(x => x.Food)
                .ToList();

            var dinnerViewModel = dinnerFoods
                .Select(x => new FoodViewModel
                {
                    Name = x.Name,
                    ProteinIn100Grams = x.ProteinIn100Grams,
                    CarbohydratesIn100Grams = x.CarbohydratesIn100Grams,
                    FatIn100Grams = x.FatIn100Grams,
                    TotalCalories = (x.ProteinIn100Grams * 4) + (x.CarbohydratesIn100Grams * 4) + (x.FatIn100Grams * 9),
                });

            var viewModel = new FoodDiaryViewModel
            {
                Breakfast = breakfastViewModel,
                Lunch = lunchViewModel,
                Snack = snackViewModel,
                Dinner = dinnerViewModel,
            };

            return viewModel;
        }
    }
}
