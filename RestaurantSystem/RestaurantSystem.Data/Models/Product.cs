namespace RestaurantSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure;
    using RestaurantSystem.Data.Infrastructure.Enumerations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.ProductNameMaxLength, ErrorMessage = Constants.ProductNameLengthErrorMessage, MinimumLength = Constants.ProductNameMinLength)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public ProductType Type { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}