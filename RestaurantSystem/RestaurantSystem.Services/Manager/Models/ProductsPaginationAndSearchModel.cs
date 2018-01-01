namespace RestaurantSystem.Services.Manager.Models
{
    using System.Collections.Generic;
    using RestaurantSystem.Services.Cook.Models;

    public class ProductsPaginationAndSearchModel : PaginationAndSearchModel
    {
        public IEnumerable<ProductsListModel> Products { get; set; } = new List<ProductsListModel>();
    }
}