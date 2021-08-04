namespace MyFitnessApp.Services.Data.Article
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Web.ViewModels.Articles;

    // IDeletableEntityRepository<Article>
    public class ArticlesService : IArticlesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg"}; // позволени разширения
        private readonly IDeletableEntityRepository<ArticleCategory> articleCategoryRepository;
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticlesService(
            IDeletableEntityRepository<ArticleCategory> articleCategoryRepository,
            IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.articleRepository = articleRepository;
        }

        public IEnumerable<CategoryViewModel> GetArticleCategories()
        {
            var viewModel = this.articleCategoryRepository
                .AllAsNoTracking()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return viewModel;
        }

        public async Task CreateArticleAsync(CreateArticleInputModel model, string userId, string imagePath)
        {
            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                CategoryId = model.CategoryId,
                AddedByUserId = userId,
            };

            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();

            Directory.CreateDirectory($"{imagePath}/articles/");

            var articleId = article.Id;
            var extension = Path.GetExtension(model.Image.FileName).TrimStart('.');

            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var physicalPath = $"{imagePath}/articles/{articleId}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await model.Image.CopyToAsync(fileStream);

            article.ImageUrl = physicalPath;
            await this.articleRepository.SaveChangesAsync();

            // записваме картинката като комбинация от Id на Article и extension (123.jpeg)
        }

        public IEnumerable<SingleArticleViewModel> GetAllArticles()
        {
            var viewModel = this.articleRepository
                .All()
                .OrderByDescending(x => x.Id) // последните добавени ще излизат най-отпред в списъка
             .Select(x => new SingleArticleViewModel
             {
                 Id = x.Id,
                 Title = x.Title,
                 Content = x.Content,
                 CategoryId = x.CategoryId,
                 CategoryName = x.Category.Name,
                 ImagePath = "/images/articles/" + x.Id + "." + "jpg",
                 UserId = x.AddedByUserId,
                 CreatedOn = x.CreatedOn.ToString("f"),
                 Username = x.AddedByUser.UserName,
             })
             .ToList();

            return viewModel;
        }

        public SingleArticleViewModel GetArticleById(int id)
        {
            var viewModel = this.articleRepository
                .All()
                .Where(x => x.Id == id)
                .Select(x => new SingleArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    ImagePath = "/images/articles/" + x.Id + "." + "jpg",
                    UserId = x.AddedByUserId,
                    CreatedOn = x.CreatedOn.ToString("f"),
                    Username = x.AddedByUser.UserName,
                })
                .FirstOrDefault();

            return viewModel;
        }

        public IEnumerable<SingleArticleViewModel> GetArticlesByCategoryId(int categoryId)
        {
            var viewModel = this.articleRepository
                    .All()
                    .Where(x => x.CategoryId == categoryId)
                    .OrderByDescending(x => x.Id) // последните добавени ще излизат най-отпред в списъка
                    .Select(x => new SingleArticleViewModel
                    {
                        Id = x.Id,
                        CategoryId = x.CategoryId,
                        Title = x.Title,
                        CategoryName = x.Category.Name,
                        Content = x.Content,
                        ImagePath = "/images/articles/" + x.Id + "." + "jpg",
                        UserId = x.AddedByUserId,
                        CreatedOn = x.CreatedOn.ToString("f"),
                        Username = x.AddedByUser.UserName,
                    })
                    .ToList();

            return viewModel;
        }

        public async Task DeleteArticleAsync(int articleId)
        {
            var article = this.articleRepository
                .All()
                .Where(x => x.Id == articleId)
                .FirstOrDefault();

            this.articleRepository.Delete(article);
            await this.articleRepository.SaveChangesAsync();
        }

        public int GetCounts()
        {
            var totalArticlesCount = this.articleRepository
                .All()
                .Count();

            return totalArticlesCount;
        }

        public async Task EditArticleAsync(EditArticleInputModel model, int articleId, string imagePath, string userId)
        {
            Directory.CreateDirectory($"{imagePath}/articles/");
            var extension = Path.GetExtension(model.Image.FileName).TrimStart('.');
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var physicalPath = $"{imagePath}/articles/{articleId}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await model.Image.CopyToAsync(fileStream);

            var article = this.articleRepository
                .All()
                .Where(x => x.Id == articleId)
                .FirstOrDefault();

            article.Title = model.Title;
            article.Content = model.Content;
            article.CategoryId = model.CategoryId;
            article.ImageUrl = physicalPath;

            this.articleRepository.Update(article);
            await this.articleRepository.SaveChangesAsync();
        }
    }
}
