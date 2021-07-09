namespace MyFitnessApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    // Mapping table bewtween USER and POST
    public class Like : BaseDeletableModel<int>
    {
        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
