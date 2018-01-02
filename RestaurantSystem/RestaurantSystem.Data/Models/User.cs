namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        [Range(0, double.MaxValue)]
        public decimal Money { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public ICollection<WaiterSection> WaiterSections { get; set; } = new List<WaiterSection>();

        public ICollection<Order> OrdersAsWaiter { get; set; } = new List<Order>();
    }
}