namespace RestaurantSystem.Services.Cook.Models.Ingredients
{
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Infrastructure;
    using RestaurantSystem.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class IngredientEditModel : IMapFrom<Ingredient>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.IngredientNameMaxLength, ErrorMessage = Constants.IngredientNameLenghtErrorMessage, MinimumLength = Constants.IngredientNameMinLength)]
        [Display(Name = "Ingredient name")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Minimum treshold cannot be negative.")]
        [Display(Name = "Minimum stock quantity treshold")]
        public float MinStockQuantityTreshold { get; set; }
    }
}
