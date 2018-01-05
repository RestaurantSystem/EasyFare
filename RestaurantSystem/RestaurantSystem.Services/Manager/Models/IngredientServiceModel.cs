namespace RestaurantSystem.Services.Manager.Models
{
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class IngredientServiceModel : IMapFrom<Ingredient>
    {
        public string Name { get; set; }

        public float QuantityInStock { get; set; }

        public float MinStockQuantityThreshold { get; set; }
    }
}