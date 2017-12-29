namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;

    public class Recipe
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}