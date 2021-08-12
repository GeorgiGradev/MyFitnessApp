namespace MyFitnessApp.Services.Data.Post
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<CategoryViewModel> GetForumCategories();

        Task<int> CreatePostAsync(CreatePostInputModel model, string userId);

        PostViewModel GetPostById(int id);

        Task DeletePostAsync(int postId);

        int GetCounts();
    }
}
