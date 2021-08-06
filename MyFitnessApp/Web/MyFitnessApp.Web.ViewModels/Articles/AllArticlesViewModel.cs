namespace MyFitnessApp.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class AllArticlesViewModel : PagingViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
