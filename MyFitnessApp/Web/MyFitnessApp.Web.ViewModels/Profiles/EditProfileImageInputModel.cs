namespace MyFitnessApp.Web.ViewModels.Profiles
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class EditProfileImageInputModel
    {
        [Required(ErrorMessage = "Please upload profile image")]
        [Display(Name = "Image (.jpg format only)")]
        public IFormFile ImageUrl { get; set; }
    }
}
