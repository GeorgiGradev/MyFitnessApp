namespace MyFitnessApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class UserImage : BaseDeletableModel<string>
    {
        public UserImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Url { get; set; }

        public string Extension { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
