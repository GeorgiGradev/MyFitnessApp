﻿namespace MyFitnessApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Article;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Articles;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
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
        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel
            {
                Categories = this.articlesService.GetArticleCategories(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
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

            this.TempData["Message"] = "Article created successfully.";

            return this.RedirectToAction("All", "Articles");
        }

        [HttpGet]
        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 3;

            var view = new AllArticlesViewModel
            {
                PageNumber = id,
                Articles = this.articlesService.GetAllArticles(id, itemsPerPage),
                ItemsCount = this.articlesService.GetCounts(),
                ItemsPerPage = itemsPerPage,
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Article(int id)
        {
            var viewNodel = this.articlesService.GetArticleById(id);
            return this.View(viewNodel);
        }

        [HttpGet]
        public IActionResult Categories()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.articlesService.DeleteArticleAsync(id);
            this.TempData["Message"] = "Article deleted successfully.";
            return this.RedirectToAction("All", "Articles");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new EditArticleInputModel();
            var currentArticle = this.articlesService.GetArticleById(id);

            viewModel.Title = currentArticle.Title;
            viewModel.Content = currentArticle.Content;
            viewModel.Categories = this.articlesService.GetArticleCategories();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, EditArticleInputModel model)
        {
            var userId = this.User.GetId();

            if (!this.ModelState.IsValid)
            {
                model.Categories = this.articlesService.GetArticleCategories();

                return this.View(model);
            }

            try
            {
                await this.articlesService.EditArticleAsync(model, id, $"{this.environment.WebRootPath}/images", userId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                model.Categories = this.articlesService.GetArticleCategories();
                return this.View(model);
            }

            this.TempData["Message"] = "Article updated successfully.";

            return this.Redirect($"/Articles/Article/{id}");
        }
    }
}
