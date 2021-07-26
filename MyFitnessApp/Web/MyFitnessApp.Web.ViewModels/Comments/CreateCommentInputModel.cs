namespace MyFitnessApp.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using static MyFitnessApp.Common.DataConstants;

    public class CreateCommentInputModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(CommentContentMinLength, ErrorMessage = "The content must have at least {1} letters")]
        [MaxLength(CommentContentMaxLength, ErrorMessage = "The content must have maximum {1} letters")]
        public string Content { get; set; }
    }
}
