namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; } // дава информация за номера на страницата, на която се намира

        public bool HasPreviousPage => this.PageNumber > 1; // Ако PageNumber > 1 значи имаме предишна страница

        public bool HasNextPage => this.PageNumber < this.PagesCount; // Ако PageNumber < от броя на всички страници, значи имаме следваща страница

        public int PagesCount => (int)Math.Ceiling((double)this.ExercisesCount / this.ItemsPerPage); // броят на всички страници

        public int PreviousPageNumber => this.PageNumber - 1;  // номер на предишната страница

        public int NextPageNumber => this.PageNumber + 1; // номер на следвашата страница

        public int ExercisesCount { get; set; } // дава информация колко е броя на всички Exercises

        public int ItemsPerPage { get; set; } // дава информация колко Exercises има на една стрница
    }
}
