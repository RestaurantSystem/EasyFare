namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using RestaurantSystem.Data.Infrastructure;

    public class User : IdentityUser
    {
        [Range(Constants.UserMinMoney, float.MaxValue)]
        public decimal Money { get; set; }

        [Range(Constants.UserMinSalary, Constants.UserMaxSalary)]
        public decimal Salary { get; set; }

        public ICollection<WaiterSection> WaiterSections { get; set; } = new List<WaiterSection>();

        public ICollection<Order> OrdersAsWaiter { get; set; } = new List<Order>();
    }
}