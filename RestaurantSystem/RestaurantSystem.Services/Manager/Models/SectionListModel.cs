namespace RestaurantSystem.Services.Manager.Models
{
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Infrastructure;
    using RestaurantSystem.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SectionListModel : IMapFrom<Section>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.SectionNameMaxLength, ErrorMessage = Constants.SectionNameLengthErrorMessage, MinimumLength = Constants.SectionNameMinLength)]
        public string Name { get; set; }

        public bool IsForSmokers { get; set; }

        public ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}
