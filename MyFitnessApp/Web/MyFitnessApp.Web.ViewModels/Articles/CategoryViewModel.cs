namespace MyFitnessApp.Web.ViewModels.Articles
{
    //// Дава възможност да се зареди падащото меню на ArticleCategories в Action - Create New Article при визуализиране на празната форма преди попълване \\\\
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}