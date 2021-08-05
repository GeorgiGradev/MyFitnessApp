namespace MyFitnessApp.Services.Data.Search
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Web.ViewModels.Search;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Food> foodsRepository;

        public SearchService(IDeletableEntityRepository<Food> foodsRepository)
        {
            this.foodsRepository = foodsRepository;
        }

        public IEnumerable<FoodViewModel> SearchFoodByKeyword(string keyword)
        {
            var foods = this.foodsRepository
                .All()
                .Where(x => x.Name.Contains(keyword))
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

            return foods;
        }
    }
}
