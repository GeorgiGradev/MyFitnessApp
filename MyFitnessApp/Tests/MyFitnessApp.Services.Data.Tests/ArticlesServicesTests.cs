namespace MyFitnessApp.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Article;

    using Xunit;

    public class ArticlesServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<ArticleCategory>> articleCategoryRepository;
        private readonly Mock<IDeletableEntityRepository<Article>> articleRepository;

        public ArticlesServicesTests()
        {
            this.articleCategoryRepository = new Mock<IDeletableEntityRepository<ArticleCategory>>();
            this.articleRepository = new Mock<IDeletableEntityRepository<Article>>();
        }

        [Fact]
        public async Task GetAllArticles()
        {
            ApplicationDbContext db = GetDb();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var service = new ArticlesService(articleCategoryRepository, articleRepository);

            var articleCategory1 = new ArticleCategory
            {
                Id = 1,
                Name = "Fitness",
                ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
            };

            var articleCategory2 = new ArticleCategory
            {
                Id = 2,
                Name = "Recipes",
                ImageUrl = "/images/seededArticleCategories/" + "recipes" + "." + "jpg",
            };

            var articleCategory3 = new ArticleCategory
            {
                Id = 3,
                Name = "Nutrition",
                ImageUrl = "/images/seededArticleCategories/" + "nutrition" + "." + "jpg",
            };

            await db.ArticleCategories.AddAsync(articleCategory1);
            await db.ArticleCategories.AddAsync(articleCategory2);
            await db.ArticleCategories.AddAsync(articleCategory3);
            await db.SaveChangesAsync();

            var result = service.GetArticleCategories();

            Assert.Equal(3, result.Count());
            Assert.Equal(articleCategory1.Name, result.Where(x => x.Id == articleCategory1.Id).Select(x => x.Name).FirstOrDefault());
        }

        [Fact]
        public async Task GetAllArticlesShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var service = new ArticlesService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Fitness",
                ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

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

            var article1 = new Article
            {
                Id = 1,
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat ....",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Make-Ahead Instant Oatmeal Jars",
                Content = "Instant oatmeal packets ...",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            };

            await db.Articles.AddAsync(article1);
            await db.Articles.AddAsync(article2);
            await db.SaveChangesAsync();

            var result = service.GetAllArticles(1, 5);

            Assert.Equal(2, result.Count());
            Assert.Equal(article1.Title, result.Where(x => x.Id == article1.Id).Select(x => x.Title).FirstOrDefault());
            Assert.Equal(article2.Title, result.Where(x => x.Id == article2.Id).Select(x => x.Title).FirstOrDefault());
        }

        [Fact]
        public async Task GetArticleByIdShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var service = new ArticlesService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Fitness",
                ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

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

            var article1 = new Article
            {
                Id = 1,
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat ....",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Make-Ahead Instant Oatmeal Jars",
                Content = "Instant oatmeal packets ...",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            };

            await db.Articles.AddAsync(article1);
            await db.Articles.AddAsync(article2);
            await db.SaveChangesAsync();

            var result = service.GetArticleById(1);

            Assert.Equal(article1.Title, result.Title);
        }

        [Fact]
        public async Task GetArticleByCategoryIdShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var service = new ArticlesService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Fitness",
                ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

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

            var article1 = new Article
            {
                Id = 1,
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat ....",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Make-Ahead Instant Oatmeal Jars",
                Content = "Instant oatmeal packets ...",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            };

            await db.Articles.AddAsync(article1);
            await db.Articles.AddAsync(article2);
            await db.SaveChangesAsync();

            var result = service.GetArticlesByCategoryId(1);

            Assert.Equal(2, result.Count());
            Assert.Equal(article1.Title, result.Where(x => x.Title == article1.Title).Select(x => x.Title).FirstOrDefault());
            Assert.Equal(article2.Title, result.Where(x => x.Title == article2.Title).Select(x => x.Title).FirstOrDefault());
        }

        [Fact]
        public async Task DeleteArticleShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDb();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var service = new ArticlesService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Fitness",
                ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

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

            var article1 = new Article
            {
                Id = 1,
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat ....",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Make-Ahead Instant Oatmeal Jars",
                Content = "Instant oatmeal packets ...",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            };

            await db.Articles.AddAsync(article1);
            await db.Articles.AddAsync(article2);
            await db.SaveChangesAsync();

            var countBeforeDeletion = db.Articles.Count();

            await service.DeleteArticleAsync(1);

            var countAfterDeletion = db.Articles.Count();

            Assert.Equal(2, countBeforeDeletion);
            Assert.Equal(1, countAfterDeletion);
        }

        [Fact]
        public async Task GetCountsShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var service = new ArticlesService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Fitness",
                ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

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

            var article1 = new Article
            {
                Id = 1,
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat ....",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Make-Ahead Instant Oatmeal Jars",
                Content = "Instant oatmeal packets ...",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            };

            await db.Articles.AddAsync(article1);
            await db.Articles.AddAsync(article2);
            await db.SaveChangesAsync();

            var result = service.GetCounts();

            Assert.Equal(2, result);
        }
    }
}
