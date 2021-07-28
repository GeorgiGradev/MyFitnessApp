namespace MyFitnessApp.Services.Data.Food
{
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Foods;

    public interface IFoodsService
    {
        Task CreateFoodAsync(CreateFoodInputModel model, string userId);

        bool DoesFoodExists(string name);
    }
}
