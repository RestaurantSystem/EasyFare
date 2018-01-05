namespace RestaurantSystem.Services.Waiter.Models.Tables
{
    using System.Collections.Generic;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Models.Products;

    public class TableOpenedServiceModel
    {
        public string Number { get; set; }

        public string SearchWord { get; set; }

        public IEnumerable<ProductListModel> Products { get; set; }

        public IEnumerable<Product> ProductsOnTable { get; set; }
    }
}