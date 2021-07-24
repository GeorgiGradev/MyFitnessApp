namespace MyFitnessApp.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class AllArticlesViewModel
    {
        public IEnumerable<SingleArticleViewModel> Articles { get; set; }
    }
}
