namespace RestaurantSystem.Services.Manager.Models
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Infrastructure;
    using RestaurantSystem.Data.Infrastructure.Enumerations;
    using RestaurantSystem.Data.Models;

    public class ProductsListModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.ProductNameMaxLength, ErrorMessage = Constants.ProductNameLengthErrorMessage, MinimumLength = Constants.ProductNameMinLength)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public bool IsCookable { get; set; }

        public ProductType Type { get; set; }
    }
}