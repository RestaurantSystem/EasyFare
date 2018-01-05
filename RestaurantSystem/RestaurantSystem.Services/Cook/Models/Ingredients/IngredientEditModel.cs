namespace RestaurantSystem.Services.Cook.Models.Ingredients
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Infrastructure;
    using RestaurantSystem.Data.Models;

    public class IngredientEditModel : IMapFrom<Ingredient>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.IngredientNameMaxLength, ErrorMessage = Constants.IngredientNameLenghtErrorMessage, MinimumLength = Constants.IngredientNameMinLength)]
        [Display(Name = "Ingredient name")]
        public string Name { get; set; }

        [Range(Constants.IngredientMinStockQuantityThreshold, Constants.IngredientMaxStockQuantityThreshold, ErrorMessage = "Minimum threshold cannot be negative.")]
        [Display(Name = "Minimum stock quantity threshold")]
        public float MinStockQuantityThreshold { get; set; }
    }
}