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

        //[HttpGet]
        //[Authorize]
        //public IActionResult Recipes()
        //{
        //    var view = new AllArticlesViewModel
        //    {
        //        Articles = this.articlesService.Get(1),
        //    };

        //    return this.View(view);
        //}
    }
}
