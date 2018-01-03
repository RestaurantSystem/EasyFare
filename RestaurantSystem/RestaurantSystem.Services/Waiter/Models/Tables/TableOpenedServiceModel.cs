namespace RestaurantSystem.Services.Waiter.Models.Tables
{
    using RestaurantSystem.Services.Cook.Models.Products;
    using System.Collections.Generic;

    public class TableOpenedServiceModel
    {
        public string Number { get; set; }

        public string WaiterId { get; set; }

        public IEnumerable<ProductListModel> ListOfAllProducts { get; set; }

        public IEnumerable<ProductListModel> CurrentListOfProducts { get; set; } = new List<ProductListModel>();
    }
}