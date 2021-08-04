﻿namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Forum;
    using MyFitnessApp.Services.Data.Post;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Posts;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IForumsService forumsService;

        public PostsController(
            IPostsService postsService,
            IForumsService forumsService)
        {
            this.postsService = postsService;
            this.forumsService = forumsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreatePostInputModel();
            viewModel.Categories = this.postsService.GetForumCategories();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.postsService.GetForumCategories();
                return this.View(model);
            }

            var userId = this.User.GetId();
            var categoryName = this.forumsService.GetCategoryNameById(model.CategoryId);
            var postId = await this.postsService.CreatePostAsync(model, userId);

            // return this.Redirect($"/ForumCategories/ByName/{categoryName.Replace(" ", "-")}");
            this.TempData["Message"] = "Post created successfully.";

            return this.RedirectToAction("ById", new { id = postId });
        }

        [HttpGet]
        public IActionResult ById(int id)
        {
            var postViewModel = this.postsService.GetPostById(id);

            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.postsService.DeletePostAsync(id);
            return this.RedirectToAction("Categories", "Forums");
        }
    }
}
