namespace RestaurantSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderTime { get; set; }

        [NotMapped]
        public decimal Amount => this.ProductOrders.Sum(o => o.Product.Price);

        public string WaiterId { get; set; }

        public User Waiter { get; set; }

        public int? BillId { get; set; }

        public Bill Bill { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        public ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}