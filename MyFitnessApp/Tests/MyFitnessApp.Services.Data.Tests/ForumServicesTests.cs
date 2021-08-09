namespace MyFitnessApp.Services.Data.Tests
{
    using System.Linq;

    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Forum;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Articles;
    using Xunit;

    public class ForumServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<ForumCategory>> forumCategoryRepository;

        public ForumServicesTests()
        {
            this.forumCategoryRepository = new Mock<IDeletableEntityRepository<ForumCategory>>();
            AutoMapperConfig.RegisterMappings(typeof(CategoryViewModel).Assembly, typeof(ForumCategory).Assembly);
        }

        [Fact]
        public void GetAllCategoriesShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var forumCategoryRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var service = new ForumsService(forumCategoryRepository);

            var category1 = new ForumCategory
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1...",
            };
            var category2 = new ForumCategory
            {
                Id = 2,
                Name = "Name2",
                Description = "Description2...",
            };

            db.ForumCategories.Add(category1);
            db.ForumCategories.Add(category2);
            db.SaveChanges();

            var result = service.GetAllCategories();

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void GetCategoryByNameShouldReturnCorectResult()
        {
            ApplicationDbContext db = GetDb();

            var forumCategoryRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var service = new ForumsService(forumCategoryRepository);

            var category1 = new ForumCategory
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1...",
            };
            var category2 = new ForumCategory
            {
                Id = 2,
                Name = "Name2",
                Description = "Description2...",
            };

            db.ForumCategories.Add(category1);
            db.ForumCategories.Add(category2);
            db.SaveChanges();

            var result = service.GetCategoryByName(category1.Name);

            Assert.Equal(category1.Id, result.Id);
        }

        [Fact]
        public void GetCategoryNameByIdShouldReturnCorectResult()
        {
            ApplicationDbContext db = GetDb();

            var forumCategoryRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var service = new ForumsService(forumCategoryRepository);

            var category1 = new ForumCategory
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1...",
            };
            var category2 = new ForumCategory
            {
                Id = 2,
                Name = "Name2",
                Description = "Description2...",
            };

            db.ForumCategories.Add(category1);
            db.ForumCategories.Add(category2);
            db.SaveChanges();

            var result = service.GetCategoryNameById(category2.Id);

            Assert.Equal(category2.Name, result);
        }
    }
}
