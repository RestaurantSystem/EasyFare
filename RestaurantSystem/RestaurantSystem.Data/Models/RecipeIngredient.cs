namespace RestaurantSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Quantity { get; set; }
    }
}