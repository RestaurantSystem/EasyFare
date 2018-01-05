namespace RestaurantSystem.Web.Areas.Manager.Models.Sections
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Data.Infrastructure;

    public class AddSectionModel
    {
        [Required]
        [StringLength(Constants.SectionNameMaxLength, ErrorMessage = Constants.SectionNameLengthErrorMessage, MinimumLength = Constants.SectionNameMinLength)]
        public string Name { get; set; }

        public bool IsForSmokers { get; set; }
    }
}