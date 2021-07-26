namespace MyFitnessApp.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;

    using static MyFitnessApp.Common.DataConstants;

    public class CreatePostInputModel : IMapTo<Post>
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(PostTitleMinLength, ErrorMessage = "The title must have at least {1} letters")]
        [MaxLength(PostTitleMaxLength, ErrorMessage = "The title must have maximum {1} letters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(PostContentMinLength, ErrorMessage = "The content must have at least {1} letters")]
        [MaxLength(PostContentMaxLength, ErrorMessage = "The content must have maximum {1} letters")]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
