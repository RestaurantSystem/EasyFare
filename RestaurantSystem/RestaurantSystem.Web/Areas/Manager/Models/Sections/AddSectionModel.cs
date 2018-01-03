namespace RestaurantSystem.Web.Areas.Manager.Models.Sections
{
    using RestaurantSystem.Data.Infrastructure;
    using System.ComponentModel.DataAnnotations;

    public class AddSectionModel
    {
        [Required]
        [StringLength(Constants.SectionNameMaxLength, ErrorMessage = Constants.SectionNameLengthErrorMessage, MinimumLength = Constants.SectionNameMinLength)]
        public string Name { get; set; }

        public bool IsForSmokers { get; set; }
    }
}
