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
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
