namespace MyFitnessApp.Web.ViewModels.Exercises
{
    //// Дава възможност да се зареди падащото меню на ExerciseCategories в Action - CREATE NEW EXCERCISE при визуализиране на празната форма преди попълване \\\\
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
