namespace RestaurantSystem.Services.Waiter.Models.Tables
{
    using RestaurantSystem.Services.Cook.Models.Products;
    using RestaurantSystem.Services.Waiter.Models.Products;
    using System.Collections.Generic;

    public class TableOpenedServiceModel
    {
        public string Number { get; set; }

        public string SearchWord { get; set; }

        public IEnumerable<ProductListModel> Products { get; set; }

        public ICollection<ProductWithQuantityServiceModel> ProductsOnTable { get; set; } = new List<ProductWithQuantityServiceModel>();
    }
}