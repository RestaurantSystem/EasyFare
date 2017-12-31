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

        [Range(0, double.MaxValue, ErrorMessage = "Quantity in stock cannot be negative.")]
        [Display(Name = "Quantity in stock")]
        public float QuantityInStock { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Minimum treshold cannot be negative.")]
        [Display(Name = "Minimum stock quantity treshold")]
        public float MinStockQuantityTreshold { get; set; }
    }
}