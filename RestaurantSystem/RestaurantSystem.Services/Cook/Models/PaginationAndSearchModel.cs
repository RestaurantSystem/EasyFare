namespace RestaurantSystem.Services.Cook.Models
{
    public class PaginationAndSearchModel
    {
        public int ItemsCount { get; set; }

        public int Page { get; set; }

        public int TotalPages { get; set; }

        public string Search { get; set; }
    }
}