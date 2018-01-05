namespace RestaurantSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Data.Infrastructure;

    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        [Range(Constants.RecipeIngredientMinQuantity, Constants.RecipeIngredientMaxQuantity)]
        public double Quantity { get; set; }
    }
}