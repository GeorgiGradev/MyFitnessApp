namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Article;
    using MyFitnessApp.Web.ViewModels.Articles;

    public class BlogsController : Controller
    {
        private readonly IArticlesService articlesService;

        public BlogsController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Recipes()
        {
            var view = new AllArticlesViewModel
            {
                Articles = this.articlesService.GetArticlesByCategoryId(1),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Fitness()
        {
            var view = new AllArticlesViewModel
            {
                Articles = this.articlesService.GetArticlesByCategoryId(2),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Nutrition()
        {
            var view = new AllArticlesViewModel
            {
                Articles = this.articlesService.GetArticlesByCategoryId(3),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Weightloss()
        {
            var view = new AllArticlesViewModel
            {
                Articles = this.articlesService.GetArticlesByCategoryId(4),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Inspiration()
        {
            var view = new AllArticlesViewModel
            {
                Articles = this.articlesService.GetArticlesByCategoryId(5),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Essentials()
        {
            var view = new AllArticlesViewModel
            {
                Articles = this.articlesService.GetArticlesByCategoryId(6),
            };

            return this.View(view);
        }
    }
}
