namespace MyFitnessApp.Services.Data.Post
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<ForumCategory> forumCategoryRepository;
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public PostsService(
            IDeletableEntityRepository<ForumCategory> forumCategoryRepository,
            IDeletableEntityRepository<Post> postRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.forumCategoryRepository = forumCategoryRepository;
            this.postRepository = postRepository;
            this.userRepository = userRepository;
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
    }
}
