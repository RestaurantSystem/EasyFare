namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure;

    public class Section
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.SectionNameMaxLength, ErrorMessage = Constants.SectionNameLengthErrorMessage, MinimumLength = Constants.SectionNameMinLength)]
        public string Name { get; set; }

        public bool IsForSmokers { get; set; }

        public ICollection<Table> Tables { get; set; } = new List<Table>();

        public ICollection<WaiterSection> WaiterSections { get; set; } = new List<WaiterSection>();
    }
}