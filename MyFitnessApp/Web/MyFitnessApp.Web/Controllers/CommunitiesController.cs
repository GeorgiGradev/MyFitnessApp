namespace MyFitnessApp.Web.Controllers
{
    using System.Text;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Services.Messaging;
    using MyFitnessApp.Web.ViewModels.Communities;

    public class CommunitiesController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly IUsersService usersService;

        public CommunitiesController(
            IEmailSender emailSender,
            IUsersService usersService)
        {
            this.emailSender = emailSender;
            this.usersService = usersService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult SendEmail()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult SendEmail(SendInvitationEmailInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var html = new StringBuilder();
            html.AppendLine($"<h1>{model.EmailSubject}");
            html.AppendLine($"<h3>{model.EmailContent}");

            var userId = this.User.GetId();
            var userName = this.usersService.GetUserNameById(userId);
            var receiverEmail = model.ReceiverEmailAddress;

            // Не изпращаме от E-mailа на потребителя, тъй като SendGrid изисват вирификация на изпращача
            var userEmail = this.usersService.GetUserEmailbyId(userId);

            // В случая изпращаме от верифициран от SendGrid адрес
            var senderEmail = "joro_gradev@abv.bg";

            this.emailSender.SendEmailAsync(senderEmail, userName, receiverEmail, model.EmailSubject, model.EmailContent);

            this.TempData["Message"] = "E-mail sent successfully.";
            return this.RedirectToAction("SendEmail", "Communities");
        }
    }
}
