namespace RestaurantSystem.Services.Waiter.Models.Tables
{
    using RestaurantSystem.Services.Waiter.Models.Products;
    using System.Collections.Generic;
    using System.Linq;

    public class TableCheckServiceModel
    {
        public string Number { get; set; }

        public decimal TotalPrice => this.ProductsOnTable.Sum(p => p.Price);

        public ICollection<ProductWithQuantityServiceModel> ProductsOnTable { get; set; } = new List<ProductWithQuantityServiceModel>();
    }
}