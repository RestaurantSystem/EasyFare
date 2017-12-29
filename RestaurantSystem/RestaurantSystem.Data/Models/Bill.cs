namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Bill
    {
        public int Id { get; set; }

        [NotMapped]
        public decimal Amount => this.Orders.Sum(o => o.Amount);

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}