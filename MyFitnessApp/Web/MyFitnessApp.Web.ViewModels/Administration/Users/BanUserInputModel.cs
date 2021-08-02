namespace MyFitnessApp.Web.ViewModels.Administration.Users
{
    using System.ComponentModel.DataAnnotations;

    using static MyFitnessApp.Common.DataConstants;

    public class BanUserInputModel
    {
        [Required]
        [MinLength(UserBanReasonMinLength)]
        [MaxLength(UserBanReasonMaxLength)]
        public string BanReason { get; set; }
    }
}
