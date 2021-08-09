namespace MyFitnessApp.Services.Data.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Web.ViewModels.Foods;

    public class FoodsService : IFoodsService
    {
        private readonly IDeletableEntityRepository<Food> foodsRepository;
        private readonly IDeletableEntityRepository<FoodMeal> foodMealsRepository;
        private readonly IDeletableEntityRepository<Meal> mealsRepository;

        public FoodsService(
            IDeletableEntityRepository<Food> foodsRepository,
            IDeletableEntityRepository<FoodMeal> foodMealsRepository,
            IDeletableEntityRepository<Meal> mealsRepository)
        {
            this.foodsRepository = foodsRepository;
            this.foodMealsRepository = foodMealsRepository;
            this.mealsRepository = mealsRepository;
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

        public IEnumerable<FoodViewModel> GetAllFoods(int pageNumber, int itemsPerPage)
        {
            var viewModel = this.foodsRepository
                .All()
                .OrderByDescending(x => x.Id)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new FoodViewModel
                {
                    Name = x.Name,
                    ProteinIn100Grams = x.ProteinIn100Grams,
                    CarbohydratesIn100Grams = x.CarbohydratesIn100Grams,
                    FatIn100Grams = x.FatIn100Grams,
                    TotalCalories = (x.ProteinIn100Grams * 4) + (x.CarbohydratesIn100Grams * 4) + (x.FatIn100Grams * 9),
                    CreatedOn = x.CreatedOn,
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
            }

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
        }

        public FoodDiaryViewModel GetFoodDiary(string userId)
        {
            var breakfastFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Breakfast") && x.Meal.AddedByUserId == userId)
                .ToList();

            var breakFastViewModel = new List<FoodViewModel>();

            foreach (var item in breakfastFoods)
            {
                var viewModel = new FoodViewModel();
                var food = this.foodsRepository.All().Where(x => x.Id == item.FoodId).FirstOrDefault();
                viewModel.Name = food.Name;
                viewModel.ProteinIn100Grams = item.ServingSizeInGrams / 100 * food.ProteinIn100Grams;
                viewModel.CarbohydratesIn100Grams = item.ServingSizeInGrams / 100 * food.CarbohydratesIn100Grams;
                viewModel.FatIn100Grams = item.ServingSizeInGrams / 100 * food.FatIn100Grams;
                viewModel.TotalCalories = (viewModel.ProteinIn100Grams * 4) + (viewModel.CarbohydratesIn100Grams * 4) + (viewModel.FatIn100Grams * 9);
                viewModel.ServingSize = item.ServingSizeInGrams;
                breakFastViewModel.Add(viewModel);
            }

            var lunchFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Lunch") && x.Meal.AddedByUserId == userId)
                .ToList();

            var lunchViewModel = new List<FoodViewModel>();

            foreach (var item in lunchFoods)
            {
                var viewModel = new FoodViewModel();
                var food = this.foodsRepository.All().Where(x => x.Id == item.FoodId).FirstOrDefault();
                viewModel.Name = food.Name;
                viewModel.ProteinIn100Grams = item.ServingSizeInGrams / 100 * food.ProteinIn100Grams;
                viewModel.CarbohydratesIn100Grams = item.ServingSizeInGrams / 100 * food.CarbohydratesIn100Grams;
                viewModel.FatIn100Grams = item.ServingSizeInGrams / 100 * food.FatIn100Grams;
                viewModel.TotalCalories = (viewModel.ProteinIn100Grams * 4) + (viewModel.CarbohydratesIn100Grams * 4) + (viewModel.FatIn100Grams * 9);
                viewModel.ServingSize = item.ServingSizeInGrams;
                lunchViewModel.Add(viewModel);
            }

            var snackFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Snack") && x.Meal.AddedByUserId == userId)
                .ToList();

            var snackViewModel = new List<FoodViewModel>();

            foreach (var item in snackFoods)
            {
                var viewModel = new FoodViewModel();
                var food = this.foodsRepository.All().Where(x => x.Id == item.FoodId).FirstOrDefault();
                viewModel.Name = food.Name;
                viewModel.ProteinIn100Grams = item.ServingSizeInGrams / 100 * food.ProteinIn100Grams;
                viewModel.CarbohydratesIn100Grams = item.ServingSizeInGrams / 100 * food.CarbohydratesIn100Grams;
                viewModel.FatIn100Grams = item.ServingSizeInGrams / 100 * food.FatIn100Grams;
                viewModel.TotalCalories = (viewModel.ProteinIn100Grams * 4) + (viewModel.CarbohydratesIn100Grams * 4) + (viewModel.FatIn100Grams * 9);
                viewModel.ServingSize = item.ServingSizeInGrams;
                snackViewModel.Add(viewModel);
            }

            var dinnerFoods = this.foodMealsRepository
                .All()
                .Where(x => x.Meal.Name == Enum.Parse<MealName>("Dinner") && x.Meal.AddedByUserId == userId)
                .ToList();

            var dinnerViewModel = new List<FoodViewModel>();

            foreach (var item in dinnerFoods)
            {
                var viewModel = new FoodViewModel();
                var food = this.foodsRepository.All().Where(x => x.Id == item.FoodId).FirstOrDefault();
                viewModel.Name = food.Name;
                viewModel.ProteinIn100Grams = item.ServingSizeInGrams / 100 * food.ProteinIn100Grams;
                viewModel.CarbohydratesIn100Grams = item.ServingSizeInGrams / 100 * food.CarbohydratesIn100Grams;
                viewModel.FatIn100Grams = item.ServingSizeInGrams / 100 * food.FatIn100Grams;
                viewModel.TotalCalories = (viewModel.ProteinIn100Grams * 4) + (viewModel.CarbohydratesIn100Grams * 4) + (viewModel.FatIn100Grams * 9);
                viewModel.ServingSize = item.ServingSizeInGrams;
                dinnerViewModel.Add(viewModel);
            }

            var viewModelToAdd = new FoodDiaryViewModel
            {
                Breakfast = breakFastViewModel,
                Lunch = lunchViewModel,
                Snack = snackViewModel,
                Dinner = dinnerViewModel,
                UserId = userId,
            };

            return viewModelToAdd;
        }

        public async Task DeleteFoodDiary(string userId)
        {
            var userDiaryMeals = this.mealsRepository
                .All()
                .Where(x => x.AddedByUserId == userId)
                .ToList();

            foreach (var meal in userDiaryMeals)
            {
                this.mealsRepository.Delete(meal);
            }

            await this.mealsRepository.SaveChangesAsync();
        }

        public int GetCounts()
        {
            var totalFoodsCount = this.foodsRepository
                .All()
                .Count();

            return totalFoodsCount;
        }
    }
}
