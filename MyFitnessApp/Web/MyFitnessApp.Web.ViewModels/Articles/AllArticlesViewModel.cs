namespace MyFitnessApp.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    using MyFitnessApp.Web.ViewModels.Exercises;

    public class AllArticlesViewModel
    {
        public IEnumerable<SingleArticleViewModel> Articles { get; set; }
    }
}
