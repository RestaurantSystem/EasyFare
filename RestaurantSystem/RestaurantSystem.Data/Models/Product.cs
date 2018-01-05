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

        [Required]
        [Range(Constants.ProductMinPrice, Constants.ProductMaxPrice)]
        public decimal Price { get; set; }

        public bool IsCookable { get; set; }

        public ProductType Type { get; set; }

        public int? RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public string TableNumber { get; set; }

        public Table Table { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        public ICollection<TableProduct> Tables { get; set; } = new List<TableProduct>();
    }
}