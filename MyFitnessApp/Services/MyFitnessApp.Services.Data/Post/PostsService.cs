namespace MyFitnessApp.Services.Data.Post
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Comment;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Comments;
    using MyFitnessApp.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<ForumCategory> forumCategoryRepository;
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IProfilesService profilesService;
        private readonly ICommentsService commentsService;

        public PostsService(
            IDeletableEntityRepository<ForumCategory> forumCategoryRepository,
            IDeletableEntityRepository<Post> postRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IProfilesService profilesService,
            ICommentsService commentsService)
        {
            this.forumCategoryRepository = forumCategoryRepository;
            this.postRepository = postRepository;
            this.userRepository = userRepository;
            this.profilesService = profilesService;
            this.commentsService = commentsService;
        }

        public IEnumerable<CategoryViewModel> GetForumCategories()
        {
            var viewModel = this.forumCategoryRepository
                .AllAsNoTracking()
                .To<CategoryViewModel>()
                .ToList();

            return viewModel;
        }

        public async Task<int> CreatePostAsync(CreatePostInputModel model, string userId)
        {
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                CategoryId = model.CategoryId,
                AddedByUserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();

            return post.Id;
        }

        public PostViewModel GetPostById(int id)
        {
            var post = this.postRepository
                .All()
                .Where(x => x.Id == id)
                .To<PostViewModel>()
                .FirstOrDefault();

            var profileId = this.profilesService.GetPofileIdByUserId(post.AddedByUserId);

            var internalImage = "/images/profileimages/" + profileId + "." + "jpg";
            post.UserProfileImage = internalImage;

            var comments = this.commentsService.GetAllPostComments(post.Id);
            post.Comments = comments;

            return post;
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = this.postRepository
                .All()
                .Where(x => x.Id == postId)
                .FirstOrDefault();

            this.postRepository.Delete(post);
            await this.postRepository.SaveChangesAsync();
        }

        public int GetCounts()
        {
            var totalPostsCount = this.postRepository
                .All()
                .Count();

            return totalPostsCount;
        }
    }
}
