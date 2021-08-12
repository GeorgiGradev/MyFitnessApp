namespace MyFitnessApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    // Self-referencing relationship between ApplicationUser and ApplicationUser
    public class FollowerFollowee : BaseDeletableModel<int>
    {
        [Required]
        public string FollowerId { get; set; }

        public virtual ApplicationUser Follower { get; set; }

        [Required]
        public string FolloweeId { get; set; }

        public virtual ApplicationUser Followee { get; set; }
    }
}
