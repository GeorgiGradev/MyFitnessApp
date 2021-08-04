namespace MyFitnessApp.Services.Data.Article
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        // Взима всички ArticleCategories, за да се подадат на празното View при отвяряне на Create New Article
        IEnumerable<CategoryViewModel> GetArticleCategories();

        // Създаване на Exercise с ASYNC Method
        Task CreateArticleAsync(CreateArticleInputModel model, string userId, string imagePath);

        // Взима всички Articles от базата
        IEnumerable<SingleArticleViewModel> GetAllArticles();

        // Взима даден Articles по Id
        SingleArticleViewModel GetArticleById(int id);

        // Get articles by CategoryId
        IEnumerable<SingleArticleViewModel> GetArticlesByCategoryId(int categoryId);

        // Премахва Article
        Task DeleteArticleAsync(int articleId);

        int GetCounts();

        Task EditArticleAsync(EditArticleInputModel model, int articleId, string imagePath, string userId);
    }
}
