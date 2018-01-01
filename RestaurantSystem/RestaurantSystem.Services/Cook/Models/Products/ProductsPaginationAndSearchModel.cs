namespace RestaurantSystem.Services.Cook.Models.Products
{
    using System.Collections.Generic;

    public class ProductsPaginationAndSearchModel : PaginationAndSearchModel
    {
        public IEnumerable<ProductListModel> Products { get; set; } = new List<ProductListModel>();
    }
}
