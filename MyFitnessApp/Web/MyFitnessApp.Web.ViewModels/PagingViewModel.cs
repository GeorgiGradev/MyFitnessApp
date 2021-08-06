﻿namespace MyFitnessApp.Web.ViewModels
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; } // дава информация за номера на страницата, на която се намира

        public bool HasPreviousPage => this.PageNumber > 1; // Ако PageNumber > 1 значи имаме предишна страница

        public bool HasNextPage => this.PageNumber < this.PagesCount; // Ако PageNumber < от броя на всички страници, значи имаме следваща страница

        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage); // броят на всички страници

        public int PreviousPageNumber => this.PageNumber - 1;  // номер на предишната страница

        public int NextPageNumber => this.PageNumber + 1; // номер на следвашата страница

        public int FirstPageNumber => 1;

        public int LastPageNumber => this.PagesCount;

        public int ItemsCount { get; set; } // дава информация колко е броя на всички Items

        public int ItemsPerPage { get; set; } // дава информация колко Items има на една стрница
    }
}
