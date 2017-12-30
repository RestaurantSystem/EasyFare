namespace RestaurantSystem.Web.Areas.Manager.Models.Ingredients
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Data.Infrastructure;

    public class AddIngredientModel
    {
        [Required]
        [StringLength(Constants.IngredientNameMaxLength, ErrorMessage = Constants.IngredientNameLenghtErrorMessage, MinimumLength = Constants.IngredientNameMinLength)]
        public string Name { get; set; }
        

        [Range(0, double.MaxValue)]
        public float QuantityInStock { get; set; }

        [Range(0, double.MaxValue)]
        public float MinStockQuantityTreshold { get; set; }
    }
}
