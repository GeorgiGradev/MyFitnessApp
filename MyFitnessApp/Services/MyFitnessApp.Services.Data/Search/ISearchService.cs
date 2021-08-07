namespace MyFitnessApp.Services.Data.Search
{
    using System.Collections.Generic;

    using MyFitnessApp.Web.ViewModels.Search;

    public interface ISearchService
    {
        IEnumerable<FoodViewModel> SearchFoodByKeyword(string keyword);

        IEnumerable<ArticleViewModel> SearchArticleByKeyword(string keyword);

        IEnumerable<ExerciseViewModel> SearchExerciseByKeyword(string keyword);

        IEnumerable<UserViewModel> SearchUserByUsername(string username);

        IEnumerable<UserViewModel> SearchUserByEmail(string email);
    }
}
