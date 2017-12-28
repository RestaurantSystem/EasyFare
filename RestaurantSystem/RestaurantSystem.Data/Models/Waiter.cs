namespace RestaurantSystem.Data.Models
{
    using Infrastructure;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Waiter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.WaiterNameMaxLength, ErrorMessage = Constants.WaiterNameLengthErrorMessage, MinimumLength = Constants.WaiterNameMinLength)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public ICollection<WaiterSection> WaiterSections { get; set; } = new List<WaiterSection>();
    }
}
