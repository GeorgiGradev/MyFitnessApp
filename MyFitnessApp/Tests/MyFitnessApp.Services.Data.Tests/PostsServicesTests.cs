namespace MyFitnessApp.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Comment;
    using MyFitnessApp.Services.Data.Post;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Posts;
    using Xunit;

    public class PostsServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<ForumCategory>> forumCategoriesRepository;
        private readonly Mock<IDeletableEntityRepository<Post>> postsRepository;
        private readonly Mock<IProfilesService> profilesService;
        private readonly Mock<ICommentsService> commentsService;

        public PostsServicesTests()
        {
            this.forumCategoriesRepository = new Mock<IDeletableEntityRepository<ForumCategory>>();
            this.postsRepository = new Mock<IDeletableEntityRepository<Post>>();
            this.profilesService = new Mock<IProfilesService>();
            this.commentsService = new Mock<ICommentsService>();
            AutoMapperConfig.RegisterMappings(typeof(CategoryViewModel).Assembly, typeof(ForumCategory).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(PostViewModel).Assembly, typeof(Post).Assembly);
        }

        [Fact]
        public void GetForumCategories()
        {
            ApplicationDbContext db = GetDb();

            var forumCategoriesRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var service = new PostsService(forumCategoriesRepository, this.postsRepository.Object, this.profilesService.Object, this.commentsService.Object);

            var forumCategory1 = new ForumCategory
            {
                Name = "Test1",
            };

            var forumCategory2 = new ForumCategory
            {
                Name = "Test2",
            };

            db.ForumCategories.Add(forumCategory1);
            db.ForumCategories.Add(forumCategory2);
            db.SaveChanges();

            var result = service.GetForumCategories().Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task CreatePostAsyncShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var postsRepository = new EfDeletableEntityRepository<Post>(db);

            var service = new PostsService(this.forumCategoriesRepository.Object, postsRepository, this.profilesService.Object, this.commentsService.Object);

            var model = new CreatePostInputModel
            {
                Title = "Title",
                Content = "Content...",
                CategoryId = 1,
            };

            var result = await service.CreatePostAsync(model, "123");
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetPostByIdShoudReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var postsRepository = new EfDeletableEntityRepository<Post>(db);

            var service = new PostsService(this.forumCategoriesRepository.Object, postsRepository, this.profilesService.Object, this.commentsService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            db.Users.Add(user);
            db.SaveChanges();

            var post = new Post
            {
                Id = 3,
                Title = "Title",
                Content = "Content.....",
                Category = new ForumCategory(),
                AddedByUserId = "x123",
            };

            db.Posts.Add(post);
            db.SaveChanges();

            var result = service.GetPostById(3);

            Assert.Equal(post.Id, result.Id);
            Assert.Equal(post.Title, result.Title);
            Assert.Equal(post.Content, result.Content);
            Assert.Equal(post.AddedByUserId, result.AddedByUserId);
        }

        [Fact]
        public async Task DeletePostAsync()
        {
            ApplicationDbContext db = GetDb();

            var postsRepository = new EfDeletableEntityRepository<Post>(db);

            var service = new PostsService(this.forumCategoriesRepository.Object, postsRepository, this.profilesService.Object, this.commentsService.Object);

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

            var post1 = new Post
            {
                Id = 3,
                Title = "Title",
                Content = "Content.....",
                Category = new ForumCategory(),
                AddedByUserId = "x123",
            };
            var post2 = new Post
            {
                Id = 4,
                Title = "Title4",
                Content = "Content4.....",
                Category = new ForumCategory(),
                AddedByUserId = "x123",
            };


            await db.Posts.AddAsync(post1);
            await db.Posts.AddAsync(post2);
            await db.SaveChangesAsync();

            await service.DeletePostAsync(3);
            Assert.True(db.Posts.Count() == 1);
        }

        [Fact]
        public void GetCountsShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var postsRepository = new EfDeletableEntityRepository<Post>(db);

            var service = new PostsService(this.forumCategoriesRepository.Object, postsRepository, this.profilesService.Object, this.commentsService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            db.Users.Add(user);
            db.SaveChanges();

            var post1 = new Post
            {
                Id = 3,
                Title = "Title",
                Content = "Content.....",
                Category = new ForumCategory(),
                AddedByUserId = "x123",
            };
            var post2 = new Post
            {
                Id = 4,
                Title = "Title4",
                Content = "Content4.....",
                Category = new ForumCategory(),
                AddedByUserId = "x123",
            };
            var post3 = new Post
            {
                Id = 6,
                Title = "Title6",
                Content = "Content6.....",
                Category = new ForumCategory(),
                AddedByUserId = "x123",
            };

            db.Posts.Add(post1);
            db.Posts.Add(post2);
            db.Posts.Add(post3);
            db.SaveChanges();

            var result = service.GetCounts();

            Assert.Equal(3, result);
        }
    }
}
