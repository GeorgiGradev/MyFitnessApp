namespace MyFitnessApp.Web.ViewModels.Communities
{
    using System.ComponentModel.DataAnnotations;

    using static MyFitnessApp.Common.DataConstants;

    public class SendInvitationEmailInputModel
    {
        [Required(ErrorMessage = "The field is required")]
        [EmailAddress]
        [Display(Name = "E-mail address")]
        public string ReceiverEmailAddress { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(EmailSubjectMinLength, ErrorMessage = "The subject must have at least {1} letters")]
        [MaxLength(EmailSubjectMaxLength, ErrorMessage = "The subject must have maximum {1} letters")]
        [Display(Name = "Subject")]
        public string EmailSubject { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(EmailContentMinLength, ErrorMessage = "The content must have at least {1} letters")]
        [MaxLength(EmailContentMaxLength, ErrorMessage = "The content must have maximum {1} letters")]
        [Display(Name = "Content")]
        public string EmailContent { get; set; }
    }
}
