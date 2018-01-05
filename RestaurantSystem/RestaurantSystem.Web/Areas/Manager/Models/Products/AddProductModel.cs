namespace RestaurantSystem.Web.Areas.Manager.Models.Products
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Data.Infrastructure;
    using RestaurantSystem.Data.Infrastructure.Enumerations;

    public class AddProductModel
    {
        [Required]
        [StringLength(Constants.ProductNameMaxLength, ErrorMessage = Constants.ProductNameLengthErrorMessage, MinimumLength = Constants.ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(Constants.ProductMinPrice, Constants.ProductMaxPrice)]
        public decimal Price { get; set; }

        public bool IsCookable { get; set; }

        public ProductType Type { get; set; }
    }
}