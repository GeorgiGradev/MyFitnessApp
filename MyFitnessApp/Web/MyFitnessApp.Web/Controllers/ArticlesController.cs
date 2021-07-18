namespace MyFitnessApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Article;
    using MyFitnessApp.Web.ViewModels.Articles;

    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;
        private readonly IWebHostEnvironment environment;

        public ArticlesController(
            IArticlesService articlesService,
            IWebHostEnvironment environment)
        {
            this.articlesService = articlesService;
            this.environment = environment;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel();
            viewModel.Categories = this.articlesService.GetArticleCategories();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateArticleInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.articlesService.GetArticleCategories();

                return this.View(model);
            }

            var userId = this.User.GetId();

            try
            {
                await this.articlesService.CreateArticleAsync(model, userId, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                model.Categories = this.articlesService.GetArticleCategories();
                return this.View(model);
            }

            this.TempData["Message"] = "Article added successfully.";


            return this.RedirectToAction("All", "Articles"); 

        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            var view = new AllArticlesViewModel
            {
                Articles = this.articlesService.GetAllArticles(),

            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Article(int id)
        {
            var viewNodel = this.articlesService.GetArticleById(id); // вътре са данните за визуализация
            return this.View(viewNodel);
        }
    }
}
