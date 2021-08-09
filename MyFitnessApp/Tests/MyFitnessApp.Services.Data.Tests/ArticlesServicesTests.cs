namespace MyFitnessApp.Services.Data.Tests
{
    using Moq;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;

    public class ArticlesServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<ArticleCategory>> articleCategoryRepository;
        private readonly Mock<IDeletableEntityRepository<Article>> articleRepository;

        public ArticlesServicesTests()
        {
            this.articleCategoryRepository = new Mock<IDeletableEntityRepository<ArticleCategory>>();
            this.articleRepository = new Mock<IDeletableEntityRepository<Article>>();
        }
    }
}
