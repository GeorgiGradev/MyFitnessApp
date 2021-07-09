namespace MyFitnessApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    // Mapping table bewtween USER and POST
    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
