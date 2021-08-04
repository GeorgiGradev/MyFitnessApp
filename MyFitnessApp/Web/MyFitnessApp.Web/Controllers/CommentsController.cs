namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Comment;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Comments;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpGet]
        public IActionResult Reply()
        {
            var viewModel = new CreateCommentInputModel();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Reply(int id, CreateCommentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.GetId();
            await this.commentsService.CreateCommentAsync(model, userId, id);

            return this.RedirectToAction("ById", "Posts", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int commentId, int postId)
        {
            await this.commentsService.DeleteCommentAsync(commentId);
            return this.RedirectToAction("ById", "Posts", new { id = postId });
        }
    }
}
