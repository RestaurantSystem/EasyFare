using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantSystem.Services.Waiter.Models.Products
{
   public class ProductWithQuantityServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal SinglePrice { get; set; }

        public decimal Price => this.SinglePrice * this.Quantity;
    }
}
