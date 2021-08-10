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
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Web.ViewModels.Comments;
    using Xunit;

    public class CommentsServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Comment>> commentRepository;
        private readonly Mock<IProfilesService> profilesService;

        public CommentsServicesTests()
        {
            this.commentRepository = new Mock<IDeletableEntityRepository<Comment>>();
            this.profilesService = new Mock<IProfilesService>();
        }

        [Fact]
        public async Task CreateCommentShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDb();

            var commentRepository = new EfDeletableEntityRepository<Comment>(db);

            var service = new CommentsService(commentRepository, this.profilesService.Object);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };
            await db.Users.AddAsync(user1);
            await db.SaveChangesAsync();

            var user2 = new ApplicationUser
            {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petrov.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
            };
            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            var category = new ForumCategory
            {
                Id = 1,
                Name = "Essentials",
                Description = "Some description...",
            };
            await db.ForumCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var post = new Post
            {
                Id = 1,
                Title = "Some post title",
                Content = "Some content....",
                AddedByUserId = user1.Id,
                CategoryId = 1,
                AddedByUser = user1,
            };
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();

            var inputModel = new CreateCommentInputModel
            {
                Content = "Some comment content...",
                PostId = 1,
            };

            var resultBeforeCommentCreation = db.Posts.SelectMany(x => x.Comments).Where(y => y.Content == inputModel.Content).Select(y => y.Content).FirstOrDefault();

            await service.CreateCommentAsync(inputModel, user2.Id, post.Id);

            var resultAfterCommentCreation = db.Posts.SelectMany(x => x.Comments).Where(y => y.Content == inputModel.Content).Select(y => y.Content).FirstOrDefault();

            Assert.Null(resultBeforeCommentCreation);
            Assert.NotNull(resultAfterCommentCreation);
        }

        [Fact]
        public async Task DeleteCommentShouldDeleteComment()
        {
            ApplicationDbContext db = GetDb();

            var commentRepository = new EfDeletableEntityRepository<Comment>(db);

            var service = new CommentsService(commentRepository, this.profilesService.Object);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };
            await db.Users.AddAsync(user1);
            await db.SaveChangesAsync();

            var user2 = new ApplicationUser
            {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petrov.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
            };
            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            var category = new ForumCategory
            {
                Id = 1,
                Name = "Essentials",
                Description = "Some description...",
            };
            await db.ForumCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var post = new Post
            {
                Id = 1,
                Title = "Some post title",
                Content = "Some content....",
                AddedByUserId = user1.Id,
                CategoryId = 1,
                AddedByUser = user1,
            };
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();

            var inputModel = new CreateCommentInputModel
            {
                Content = "Some comment content...",
                PostId = 1,
            };

            await service.CreateCommentAsync(inputModel, user2.Id, post.Id);

            var resultBeforeCommentDeletion = db.Posts.SelectMany(x => x.Comments).Where(y => y.Content == inputModel.Content).Select(y => y.Content).FirstOrDefault();

            await service.DeleteCommentAsync(post.Id);

            var resultAfterCommentDeletion = db.Posts.SelectMany(x => x.Comments).Where(y => y.Content == inputModel.Content).Select(y => y.Content).FirstOrDefault();

            Assert.NotNull(resultBeforeCommentDeletion);
            Assert.Null(resultAfterCommentDeletion);
        }

        [Fact]
        public async Task GetAllPostCommentsShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var commentRepository = new EfDeletableEntityRepository<Comment>(db);

            var service = new CommentsService(commentRepository, this.profilesService.Object);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };
            await db.Users.AddAsync(user1);
            await db.SaveChangesAsync();

            var user2 = new ApplicationUser
            {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petrov.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
            };
            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            var category = new ForumCategory
            {
                Id = 1,
                Name = "Essentials",
                Description = "Some description...",
            };
            await db.ForumCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var post = new Post
            {
                Id = 1,
                Title = "Some post title",
                Content = "Some content....",
                AddedByUserId = user1.Id,
                CategoryId = 1,
                AddedByUser = user1,
            };
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();

            var resultBeforeAddingofComments = db.Posts.SelectMany(x => x.Comments).Count();

            var inputModel1 = new CreateCommentInputModel
            {
                Content = "First comment content...",
                PostId = 1,
            };

            await service.CreateCommentAsync(inputModel1, user2.Id, post.Id);

            var inputModel2 = new CreateCommentInputModel
            {
                Content = "Second comment content...",
                PostId = 1,
            };

            await service.CreateCommentAsync(inputModel2, user2.Id, post.Id);


            service.GetAllPostComments(post.Id);

            var resultAfterAddingofComments = db.Posts.SelectMany(x => x.Comments).Count();

            Assert.Equal(0, resultBeforeAddingofComments);
            Assert.Equal(2, resultAfterAddingofComments);
        }
    }
}
