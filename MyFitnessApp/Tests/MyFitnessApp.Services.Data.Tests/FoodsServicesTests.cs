namespace MyFitnessApp.Services.Data.Tests
{
    using Moq;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;

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
    }
}
