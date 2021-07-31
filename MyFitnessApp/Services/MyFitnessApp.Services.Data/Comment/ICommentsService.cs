namespace MyFitnessApp.Services.Data.Comment
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        Task CreateCommentAsync(CreateCommentInputModel model, string userId, int postId);

        Task DeleteCommentAsync(int postId);

        IEnumerable<CommentViewModel> GetAllPostComments(int postId);
    }
}
