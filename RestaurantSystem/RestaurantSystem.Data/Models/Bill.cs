namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;

    public class Bill
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}