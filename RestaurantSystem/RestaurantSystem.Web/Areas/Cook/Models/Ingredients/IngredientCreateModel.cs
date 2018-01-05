namespace RestaurantSystem.Web.Areas.Cook.Models.Ingredients
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Data.Infrastructure;

    public class IngredientCreateModel
    {
        [Required]
        [StringLength(Constants.IngredientNameMaxLength, ErrorMessage = Constants.IngredientNameLenghtErrorMessage, MinimumLength = Constants.IngredientNameMinLength)]
        [Display(Name = "Ingredient name")]
        public string Name { get; set; }

        [Range(Constants.IngredientMinQuantityInStock, Constants.IngredientMaxQuantityInStock, ErrorMessage = "Quantity in stock cannot be negative.")]
        [Display(Name = "Quantity in stock")]
        public float QuantityInStock { get; set; }

        [Range(Constants.IngredientMinStockQuantityThreshold, Constants.IngredientMaxStockQuantityThreshold, ErrorMessage = "Minimum threshold cannot be negative.")]
        [Display(Name = "Minimum stock quantity threshold")]
        public float MinStockQuantityThreshold { get; set; }
    }
}