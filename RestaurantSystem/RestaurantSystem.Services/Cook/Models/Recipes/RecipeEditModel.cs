namespace RestaurantSystem.Services.Cook.Models.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Services.Cook.Models.Ingredients;

    public class RecipeEditModel
    {
        public int RecipeId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Ingredient is required.")]
        public int IngredientId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than 0.01.")] // TODOTODO: constants
        public double Quantity { get; set; }

        public IEnumerable<IngredientDropDownListModel> Ingredients { get; set; } = new List<IngredientDropDownListModel>();
    }
}