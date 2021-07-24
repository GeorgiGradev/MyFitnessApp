namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class ForumCategory : BaseDeletableModel<int>
    {
        public ForumCategory()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(ForumCategoryNameMaxLength)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
