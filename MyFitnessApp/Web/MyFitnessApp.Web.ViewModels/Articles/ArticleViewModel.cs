namespace MyFitnessApp.Web.ViewModels.Articles
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent => this.Content?.Length > 200 ? this.Content?.Substring(0, 200) + "…" : this.Content;

        public int CategoryId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Categories

        public string CategoryName { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string ImagePath { get; set; }

        public string CreatedOn { get; set; }

        public string UpdatedOn { get; set; }
    }
}
