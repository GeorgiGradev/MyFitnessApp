namespace MyFitnessApp.Services.Data.Food
{
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Web.ViewModels.Foods;

    public class FoodsService : IFoodsService
    {
        private readonly IDeletableEntityRepository<Food> foodsRepository;

        public FoodsService(IDeletableEntityRepository<Food> foodsRepository)
        {
            this.foodsRepository = foodsRepository;
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
    }
}
