namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int CategoryId { get; set; }

        public ForumCategory Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
