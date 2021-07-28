namespace MyFitnessApp.Services.Data.Food
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Foods;

    public interface IFoodsService
    {
        Task CreateFoodAsync(CreateFoodInputModel model, string userId);

        bool DoesFoodExists(string name);

        IEnumerable<FoodViewModel> GetAllFoods();

        Task AddFoodToDiaryAsync(AddFoodInputModel model, string userId, string foodName);

        FoodDiaryViewModel GetFoodDiary(string userId);
    }
}
