﻿namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Comment;
    using MyFitnessApp.Web.ViewModels.Comments;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Reply()
        {
            var viewModel = new CreateCommentInputModel();
            return this.View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.commentsService.DeleteCommentAsync(id);
            return this.RedirectToAction("Categories", "Forums");
        }
    }
}