namespace MyFitnessApp.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Web.ViewModels.Foods;
    using Xunit;

    public class FoodsServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Food>> foodsRepository;
        private readonly Mock<IDeletableEntityRepository<FoodMeal>> foodMealsRepository;
        private readonly Mock<IDeletableEntityRepository<Meal>> mealsRepository;

        public FoodsServicesTests()
        {
            this.foodsRepository = new Mock<IDeletableEntityRepository<Food>>();
            this.foodMealsRepository = new Mock<IDeletableEntityRepository<FoodMeal>>();
            this.mealsRepository = new Mock<IDeletableEntityRepository<Meal>>();
        }

        [Fact]
        public async Task CreateFoodAsyncShouldCreateFoodCorrectly()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);

            var service = new FoodsService(foodsRepository, this.foodMealsRepository.Object, this.mealsRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var inputModel = new CreateFoodInputModel
            {
                Name = "Chicken fillet",
                ProteinIn100Grams = 21,
                CarbohydratesIn100Grams = 1,
                FatIn100Grams = 8,
            };

            await service.CreateFoodAsync(inputModel, user.Id);

            var expectedFood = db.Foods
                .Where(x => x.Name == "Chicken fillet")
                .FirstOrDefault();

            Assert.Equal(expectedFood.ProteinIn100Grams, inputModel.ProteinIn100Grams);
        }

        [Fact]
        public void DoesFoodExistsShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);

            var service = new FoodsService(foodsRepository, this.foodMealsRepository.Object, this.mealsRepository.Object);

            var food = new Food
            {
                Name = "Rice",
                ProteinIn100Grams = 3,
                CarbohydratesIn100Grams = 40,
                FatIn100Grams = 1,
            };

            db.Foods.Add(food);
            db.SaveChanges();

            bool correctResult = service.DoesFoodExists("Rice");
            bool wrongResult = service.DoesFoodExists("Chicken fillet");

            Assert.True(correctResult);
            Assert.False(wrongResult);
        }

        [Fact]
        public void GetAllFoodsShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);

            var service = new FoodsService(foodsRepository, this.foodMealsRepository.Object, this.mealsRepository.Object);

            var food1 = new Food
            {
                Name = "Rice",
                ProteinIn100Grams = 3,
                CarbohydratesIn100Grams = 40,
                FatIn100Grams = 1,
            };

            var food2 = new Food
            {
                Name = "Chicken legs",
                ProteinIn100Grams = 14,
                CarbohydratesIn100Grams = 5,
                FatIn100Grams = 17,
            };

            var food3 = new Food
            {
                Name = "Avocado",
                ProteinIn100Grams = 5,
                CarbohydratesIn100Grams = 16,
                FatIn100Grams = 30,
            };

            db.Foods.Add(food1);
            db.Foods.Add(food2);
            db.Foods.Add(food3);
            db.SaveChanges();

            var result = service.GetAllFoods(1, 5);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task AddFoodToDiaryAsyncShouldAddCorrectly()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);
            var foodMealsRepository = new EfDeletableEntityRepository<FoodMeal>(db);
            var mealsRepository = new EfDeletableEntityRepository<Meal>(db);
            var service = new FoodsService(foodsRepository, foodMealsRepository, mealsRepository);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var food = new Food
            {
                Name = "Chicken legs",
                ProteinIn100Grams = 14,
                CarbohydratesIn100Grams = 5,
                FatIn100Grams = 17,
                AddedByUserId = user.Id,
            };

            db.Foods.Add(food);
            db.SaveChanges();

            var inputModel = new AddFoodInputModel
            {
                MealName = MealName.Breakfast,
                Name = "Chicken legs",
                ServingSize = 100,
            };

            await service.AddFoodToDiaryAsync(inputModel, user.Id, food.Name);

            var result = db.FoodMeals
                .Where(x => x.Food.Name == food.Name && x.Meal.AddedByUserId == user.Id)
                .FirstOrDefault();

            Assert.Equal(result.Meal.Name, inputModel.MealName);
            Assert.Equal(result.Food.Name, inputModel.Name);
            Assert.Equal(result.ServingSizeInGrams, inputModel.ServingSize);
        }

        [Fact]
        public async Task GetFoodDiaryShouldReturnFoodDiary()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);
            var foodMealsRepository = new EfDeletableEntityRepository<FoodMeal>(db);
            var mealsRepository = new EfDeletableEntityRepository<Meal>(db);
            var service = new FoodsService(foodsRepository, foodMealsRepository, mealsRepository);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var food = new Food
            {
                Name = "Chicken legs",
                ProteinIn100Grams = 14,
                CarbohydratesIn100Grams = 5,
                FatIn100Grams = 17,
                AddedByUserId = user.Id,
            };

            db.Foods.Add(food);
            db.SaveChanges();

            var inputModel = new AddFoodInputModel
            {
                MealName = MealName.Breakfast,
                Name = "Chicken legs",
                ServingSize = 100,
            };

            await service.AddFoodToDiaryAsync(inputModel, user.Id, food.Name);

            var result = service.GetFoodDiary(user.Id);

            Assert.Equal(result.Breakfast.Select(x => x.Name).FirstOrDefault(), food.Name);
            Assert.True(result.Lunch.Select(x => x.Name).FirstOrDefault() == null);
            Assert.True(result.Snack.Select(x => x.Name).FirstOrDefault() == null);
            Assert.True(result.Dinner.Select(x => x.Name).FirstOrDefault() == null);
        }

        [Fact]
        public async Task DeleteFoodDiaryShouldDeleteAllRecords()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);
            var foodMealsRepository = new EfDeletableEntityRepository<FoodMeal>(db);
            var mealsRepository = new EfDeletableEntityRepository<Meal>(db);
            var service = new FoodsService(foodsRepository, foodMealsRepository, mealsRepository);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var food = new Food
            {
                Name = "Chicken legs",
                ProteinIn100Grams = 14,
                CarbohydratesIn100Grams = 5,
                FatIn100Grams = 17,
                AddedByUserId = user.Id,
            };

            db.Foods.Add(food);
            db.SaveChanges();

            var inputModel = new AddFoodInputModel
            {
                MealName = MealName.Breakfast,
                Name = "Chicken legs",
                ServingSize = 100,
            };

            await service.AddFoodToDiaryAsync(inputModel, user.Id, food.Name);

            await service.DeleteFoodDiary(user.Id);

            var result = service.GetFoodDiary(user.Id);

            Assert.True(result.Breakfast.Select(x => x.Name).FirstOrDefault() == null);
            Assert.True(result.Lunch.Select(x => x.Name).FirstOrDefault() == null);
            Assert.True(result.Snack.Select(x => x.Name).FirstOrDefault() == null);
            Assert.True(result.Dinner.Select(x => x.Name).FirstOrDefault() == null);
        }

        [Fact]
        public async Task GetCountsShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);
            var foodMealsRepository = new EfDeletableEntityRepository<FoodMeal>(db);
            var mealsRepository = new EfDeletableEntityRepository<Meal>(db);
            var service = new FoodsService(foodsRepository, foodMealsRepository, mealsRepository);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateFoodInputModel
            {
                Name = "Chicken fillet",
                ProteinIn100Grams = 21,
                CarbohydratesIn100Grams = 1,
                FatIn100Grams = 8,
            };
            await service.CreateFoodAsync(inputModel1, user.Id);

            var inputModel2 = new CreateFoodInputModel
            {
                Name = "Chicken legs",
                ProteinIn100Grams = 14,
                CarbohydratesIn100Grams = 5,
                FatIn100Grams = 17,
            };
            await service.CreateFoodAsync(inputModel2, user.Id);

            var inputModel3 = new CreateFoodInputModel
            {
                Name = "Avocado",
                ProteinIn100Grams = 5,
                CarbohydratesIn100Grams = 16,
                FatIn100Grams = 30,
            };
            await service.CreateFoodAsync(inputModel3, user.Id);

            var result = service.GetCounts();

            Assert.Equal(3, result);
        }
    }
}
