namespace MyFitnessApp.Services.Data.Comment
{
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task CreateCommentAsync(CreateCommentInputModel model, string userId, int postId)
        {
            var comment = new Comment
            {
                Content = model.Content,
                PostId = postId,
                AddedByUserId = userId,
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int postId)
        {
            var comment = this.commentRepository
                .All()
                .Where(x => x.Id == postId)
                .FirstOrDefault();

            this.commentRepository.Delete(comment);
            await this.commentRepository.SaveChangesAsync();
        }
    }
}
