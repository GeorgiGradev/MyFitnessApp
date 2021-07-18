namespace MyFitnessApp.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static MyFitnessApp.Common.DataConstants;

    public class CreateArticleInputModel
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(ArticleTitleMMinLength, ErrorMessage = "The title must have at least {1} letters")]
        [MaxLength(ArticleTitleMaxLength, ErrorMessage = "The name must have maximum {1} letters")]
        [Display(Name = "Article title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(ArticleContentMinLength, ErrorMessage = "The content must have at least {1} letters")]
        [MaxLength(ArticleContentMaxLength, ErrorMessage = "The content must have maximum {1} letters")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Image (.jpg format only)")]
        public IFormFile Image { get; set; }

        // Нужно е на View-то
        [Display(Name = "Choose article category")]
        public int CategoryId { get; set; }

        // Dropdown Menu
        // Взима всички ArticleCategories, за да ги подаде на падащото меню
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}