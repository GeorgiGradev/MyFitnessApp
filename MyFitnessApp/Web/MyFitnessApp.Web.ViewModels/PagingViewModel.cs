namespace MyFitnessApp.Web.ViewModels
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage);

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int FirstPageNumber => 1;

        public int LastPageNumber => this.PagesCount;

        public int ItemsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
