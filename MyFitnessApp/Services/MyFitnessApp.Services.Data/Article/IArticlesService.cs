namespace MyFitnessApp.Services.Data.Article
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        IEnumerable<CategoryViewModel> GetArticleCategories();

        Task CreateArticleAsync(CreateArticleInputModel model, string userId, string imagePath);

        IEnumerable<ArticleViewModel> GetAllArticles(int pageNumber, int itemsPerPage);

        ArticleViewModel GetArticleById(int id);

        IEnumerable<ArticleViewModel> GetArticlesByCategoryId(int categoryId);

        Task DeleteArticleAsync(int articleId);

        int GetCounts();

        Task EditArticleAsync(EditArticleInputModel model, int articleId, string imagePath, string userId);
    }
}
