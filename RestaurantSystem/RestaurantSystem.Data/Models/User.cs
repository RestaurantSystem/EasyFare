namespace RestaurantSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        [Range(0, double.MaxValue)]
        public decimal Money { get; set; }
    }
}