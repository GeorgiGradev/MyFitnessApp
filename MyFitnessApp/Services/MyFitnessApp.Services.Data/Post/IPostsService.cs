namespace MyFitnessApp.Services.Data.Post
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Posts;

    public interface IPostsService
    {
        // Взима всички ForumCategories, за да се подадат на празното View при отвяряне на Create Forum Post
        IEnumerable<CategoryViewModel> GetForumCategories();

        // Създаване на Post с ASYNC Method
        Task<int> CreatePostAsync(CreatePostInputModel model, string userId);

        PostViewModel GetPostById(int id);

        Task DeletePostAsync(int postId);
    }
}
