namespace RestaurantSystem.Services.Manager.Models
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class IngredientServiceModel : IMapFrom<Ingredient>
    {
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public float QuantityInStock { get; set; }

        public float MinStockQuantityTreshold { get; set; }
    }
}