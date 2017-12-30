namespace RestaurantSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        [Range(0, double.MaxValue)]
        public decimal Money { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public ICollection<WaiterSection> WaiterSections { get; set; } = new List<WaiterSection>();
    }
}