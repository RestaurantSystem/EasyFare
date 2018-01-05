namespace RestaurantSystem.Services.Cook.Models.Ingredients
{
    using AutoMapper;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class IngredientListModel : IMapFrom<Ingredient>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool InStock { get; set; }

        public float QuantityInStock { get; set; }

        public float MinStockQuantityThreshold { get; set; }

        public int UsedInProductsCount { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Ingredient, IngredientListModel>()
                .ForMember(m => m.UsedInProductsCount, cfg => cfg.MapFrom(i => i.RecipeIngredients.Count));
        }
    }
}