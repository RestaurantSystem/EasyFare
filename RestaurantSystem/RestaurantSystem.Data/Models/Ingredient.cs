namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Infrastructure;

    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.IngredientNameMaxLength, ErrorMessage = Constants.IngredientNameLenghtErrorMessage, MinimumLength = Constants.IngredientNameMinLength)]
        public string Name { get; set; }

        [NotMapped]
        public bool InStock => this.QuantityInStock > 0;

        [Required]
        [Range(Constants.IngredientMinQuantityInStock, Constants.IngredientMaxQuantityInStock)]
        public float QuantityInStock { get; set; }

        [Required]
        [Range(Constants.IngredientMinStockQuantityThreshold, Constants.IngredientMaxStockQuantityThreshold)]
        public float MinStockQuantityThreshold { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}