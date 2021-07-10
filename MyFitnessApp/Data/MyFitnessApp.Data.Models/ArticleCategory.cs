namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class ArticleCategory : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(ArticleCategoryTitleMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
